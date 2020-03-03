namespace iShape.Triangulation.Shape {

    public enum TriangulationStrategy {
        delaunay = 0,
        plain = 1
    }
    
    public static class TriangulationStrategyExtension {
        public static string[] Enums = {TriangulationStrategy.delaunay.ToString(), TriangulationStrategy.plain.ToString()};
    }

}