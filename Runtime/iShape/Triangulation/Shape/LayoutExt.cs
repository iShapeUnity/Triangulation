using Unity.Collections;
using UnityEngine.Assertions;
using iShape.Geometry;
using iShape.Support;

namespace iShape.Triangulation.Shape {

    public static class LayoutExt {

        private struct Sub {
            internal Link next;          // top branch
            internal Link prev;          // bottom branch
            internal readonly bool isEmpty;

            internal Sub(bool isEmpty) {
                this.isEmpty = isEmpty;
                this.next = Link.empty;
                this.prev = Link.empty;
            }

            internal Sub(Link link) {
                this.isEmpty = false;
                this.next = link;
                this.prev = link;
            }

            internal Sub(Link next, Link prev) {
                this.isEmpty = false;
                this.next = next;
                this.prev = prev;
            }
        }

        private struct DualSub {
            internal readonly Sub nextSub;        // top branch
            internal readonly Sub prevSub;        // bottom branch

            internal DualSub(Sub nextSub, Sub prevSub) {
                this.nextSub = nextSub;
                this.prevSub = prevSub;
            }
        }

        private struct Bridge {
            internal readonly Link a;
            internal readonly Link b;
            internal Slice Slice => new Slice(a.vertex.index, b.vertex.index);

            internal Bridge(Link a, Link b) {
                this.a = a;
                this.b = b;
            }
        }

        public static MonotoneLayout Split(this iShape.Geometry.PlainShape shape, Allocator allocator) {
            var navigator = shape.GetNavigator(Allocator.Temp);
            var links = new DynamicArray<Link>(navigator.links, allocator);
            var natures = navigator.natures;
			var sortIndices = navigator.indices;

            int n = sortIndices.Length;

            var subs = new DynamicArray<Sub>(8, Allocator.Temp);
            var dSubs = new DynamicArray<DualSub>(8, Allocator.Temp);
            var indices = new DynamicArray<int>(16, allocator);
            var slices = new DynamicArray<Slice>(16, allocator);

            int i = 0;
            int j;

        nextNode:
            while(i < n) {
                int sortIndex = sortIndices[i];
                var node = links[sortIndex];
                var nature = natures[sortIndex];

                switch(nature) {

                    case LinkNature.start:
                        subs.Add(new Sub(node));
                        ++i;
                        goto nextNode;

                    case LinkNature.merge:

                        var newNextSub = new Sub(true);
                        var newPrevSub = new Sub(true);

                        j = 0;

                        while(j < dSubs.Count) {

                            var dSub = dSubs[j];

                            if(dSub.nextSub.next.next == node.self) {
                                var a = node.self;
                                var b = dSub.prevSub.next.self;
                                var bridge = links.Connect(a, b);

                                indices.Add(links.FindStart(bridge.a.self));

                                slices.Add(bridge.Slice);

                                var prevSub = new Sub(links[a], dSub.prevSub.prev);

                                if(!newNextSub.isEmpty) {
                                    dSubs[j] = new DualSub(newNextSub, prevSub);
                                    ++i;
                                    goto nextNode;
                                }

                                dSubs.Exclude(j);

                                newPrevSub = prevSub;
                                continue;
                            } else if(dSub.prevSub.prev.prev == node.self) {

                                var a = dSub.nextSub.prev.self;
                                var b = node.self;

                                var bridge = links.Connect(a, b);

                                indices.Add(links.FindStart(bridge.a.self));
                                slices.Add(bridge.Slice);

                                var nextSub = new Sub(dSub.nextSub.next, links[b]);

                                if(!newPrevSub.isEmpty) {
                                    dSubs[j] = new DualSub(nextSub, newPrevSub);
                                    ++i;
                                    goto nextNode;
                                }
                                dSubs.Exclude(j);

                                newNextSub = nextSub;
                                continue;
                            }

                            ++j;

                        }   //  while dSubs

                        j = 0;

                        while(j < subs.Count) {
                            var sub = subs[j];

                            if(sub.next.next == node.self) {
                                sub.next = node;

                                subs.Exclude(j);

                                if(!newNextSub.isEmpty) {
                                    dSubs.Add(new DualSub(newNextSub, sub));
                                    ++i;
                                    goto nextNode;
                                }

                                newPrevSub = sub;
                                continue;
                            } else if(sub.prev.prev == node.self) {
                                sub.prev = node;
                                subs.Exclude(j);

                                if(!newPrevSub.isEmpty) {
                                    dSubs.Add(new DualSub(sub, newPrevSub));
                                    ++i;
                                    goto nextNode;
                                }

                                newNextSub = sub;
                                continue;
                            }

                            ++j;
                        }
                        break;
                    case LinkNature.split:

                        j = 0;

                        while(j < subs.Count) {
                            var sub = subs[j];


                            var pA = sub.next.vertex.point;

                            var pB = links[sub.next.next].vertex.point;

                            var pC = links[sub.prev.prev].vertex.point;

                            var pD = sub.prev.vertex.point;


                            var p = node.vertex.point;

                            if(IsTetragonContain(p, pA, pB, pC, pD)) {
                                var a0 = sub.next.self;
                                var a1 = sub.prev.self;
                                var b = node.self;

                                if(pA.x > pD.x) {

                                    var bridge = links.Connect(a0, b);

                                    subs.Add(new Sub(bridge.b, links[a1]));

                                    slices.Add(bridge.Slice);
                                } else {
                                    var bridge = links.Connect(a1, b);

                                    subs.Add(new Sub(bridge.b, bridge.a));
                                    slices.Add(bridge.Slice);
                                }
                                subs[j] = new Sub(links[a0], links[b]);
                                ++i;
                                goto nextNode;
                            }

                            ++j;
                        }

                        j = 0;

                        while(j < dSubs.Count) {

                            var dSub = dSubs[j];

                            var pA = dSub.nextSub.next.vertex.point;

                            var pB = links[dSub.nextSub.next.next].vertex.point;
                            var pC = links[dSub.prevSub.prev.prev].vertex.point;
                            var pD = dSub.prevSub.prev.vertex.point;
                            var p = node.vertex.point;

                            if(IsTetragonContain(p, pA, pB, pC, pD)) {
                                var a = dSub.nextSub.prev.self;

                                var b = node.self;
                                var bridge = links.Connect(a, b);

                                subs.Add(new Sub(dSub.nextSub.next, links[b]));
                                subs.Add(new Sub(bridge.b, dSub.prevSub.prev));
                                slices.Add(bridge.Slice);
                                dSubs.Exclude(j);

                                ++i;
                                goto nextNode;
                            }

                            ++j;

                        }   //  while dSubs

                        break;
                    case LinkNature.end:

                        j = 0;

                        while(j < subs.Count) {
                            var sub = subs[j];

                            // second condition is useless because it repeats the first
                            if(sub.next.next == node.self) /* || sub.prev.prev.index == node.this */ {
                                indices.Add(links.FindStart(node.self));

                                subs.Exclude(j);

                                ++i;
                                goto nextNode;
                            }

                            ++j;
                        }

                        j = 0;

                        while(j < dSubs.Count) {

                            var dSub = dSubs[j];

                            // second condition is useless because it repeats the first
                            if(dSub.nextSub.next.next == node.self) /*|| dSub.prevSub.prev.prev.index == node.this*/ {
                                var a = dSub.nextSub.prev.self;
                                var b = node.self;
                                var bridge = links.Connect(a, b);

                                indices.Add(links.FindStart(a));
                                indices.Add(links.FindStart(bridge.a.self));
                                slices.Add(bridge.Slice);

                                dSubs.Exclude(j);

                                // goto next node
                                ++i;
                                goto nextNode;
                            }

                            ++j;

                        }   //  while dSubs

                        break;

                    case LinkNature.simple: 

                        j = 0;

                        while(j < subs.Count) {
                            var sub = subs[j];

                            if(sub.next.next == node.self) {
                                sub.next = node;
                                subs[j] = sub;

                                ++i;
                                goto nextNode;
                            } else if(sub.prev.prev == node.self) {
                                sub.prev = node;
                                subs[j] = sub;
                                // goto next node
                                ++i;
                                goto nextNode;
                            }

                            ++j;
                        }

                        j = 0;

                        while(j < dSubs.Count) {

                            var dSub = dSubs[j];

                            if(dSub.nextSub.next.next == node.self) {

                                var a = dSub.nextSub.prev.self;
                                var b = node.self;

                                var bridge = links.Connect(a, b);

                                indices.Add(links.FindStart(node.self));
                                slices.Add(bridge.Slice);

                                var newSub = new Sub(bridge.b, dSub.prevSub.prev);
                                subs.Add(newSub);

                                dSubs.Exclude(j);

                                // goto next node
                                ++i;
                                goto nextNode;
                            } else if(dSub.prevSub.prev.prev == node.self) {

                                var a = node.self;
                                var b = dSub.prevSub.next.self;

                                var bridge = links.Connect(a, b);

                                indices.Add(links.FindStart(node.self));
                                slices.Add(bridge.Slice);

                                var newSub = new Sub(links[dSub.nextSub.next.self], bridge.a);
                                subs.Add(newSub);

                                dSubs.Exclude(j);

                                // goto next node
                                ++i;
                                goto nextNode;
                            }

                            ++j;

                        }   //  while dSubs
                        break;
                }   // switch
            }

            subs.Dispose();
            dSubs.Dispose();
            navigator.Dispose();

            return new MonotoneLayout(links.Convert(), slices.Convert(), indices.Convert());
        }

        private static Bridge Connect(this ref DynamicArray<Link> links, int ai, int bi) {
            var aLink = links[ai];
            var bLink = links[bi];

            var count = links.Count;

            var newLinkA = new Link(aLink.prev, count, count + 1, aLink.vertex);

            links.Add(newLinkA);

            var aPrev = links[aLink.prev];
            aPrev.next = count;
            links[aLink.prev] = aPrev;

            var newLinkB = new Link(count, count + 1, bLink.next, bLink.vertex);

            links.Add(newLinkB);
            var bNext = links[bLink.next];
            bNext.prev = count + 1;
            links[bLink.next] = bNext;


            aLink.prev = bi;
            links[ai] = aLink;

            bLink.next = ai;
            links[bi] = bLink;

            return new Bridge(newLinkA, newLinkB);

        }
        
        private static long Sign(IntVector a, IntVector b, IntVector c) {
            return (a.x - c.x) * (b.y - c.y) - (b.x - c.x) * (a.y - c.y);
        }

        private static bool IsTriangleContain(IntVector p, IntVector a, IntVector b, IntVector c) {
            var d1 = Sign(p, a, b);
            var d2 = Sign(p, b, c);
            var d3 = Sign(p, c, a);

            bool has_neg = d1 < 0 || d2 < 0 || d3 < 0;
            bool has_pos = d1 > 0 || d2 > 0 || d3 > 0;

            return !(has_neg && has_pos);
        }

        private static bool IsTetragonContain(IntVector p, IntVector a, IntVector b, IntVector c, IntVector d) {
            return IsTriangleContain(p, a, b, c) || IsTriangleContain(p, a, c, d);
        }

    }

    internal static class DynamicArrayExtension {
        internal static void Exclude<T>(this ref DynamicArray<T> array, int index) where T : struct {
            int lastIndex = array.Count - 1;
            if(lastIndex != index) {
                array[index] = array[lastIndex];
            }
            array.RemoveLast();
        }

        internal static int FindStart(this DynamicArray<Link> array, int index) {
            var self = array[index];
            var next = array[self.next];
            var prev = array[self.prev];

            var bit = self.vertex.point.BitPack;
            var aBit = next.vertex.point.BitPack;
            var bBit = prev.vertex.point.BitPack;

            if(aBit < bit) {
                do {
                    next = array[next.next];
                    bit = aBit;
                    aBit = next.vertex.point.BitPack;
                } while(aBit < bit);

                return next.prev;
            } else if(bBit < bit) {
                do {
                    prev = array[prev.prev];
                    bit = bBit;
                    bBit = prev.vertex.point.BitPack;
                } while(bBit < bit);

                return prev.next;
            } else {
                return index;
            }
        }
    }

}