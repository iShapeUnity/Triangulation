# Triangulation [Port](https://github.com/iShape-Swift/iShapeTriangulation/)
Complex polygon triangulation, tessellation and split into convex polygons. A fast O(n*log(n)) algorithm based on "Triangulation of monotone polygons". The result can be represented as a Delaunay triangulation.
## Delaunay triangulation
<p align="center">
<img src="https://github.com/iShapeUnity/Triangulation/blob/master/Readme/star_triangle.svg" width="500"/>
</p>

## Triangulation with extra points
<p align="center">
<img src="https://github.com/iShapeUnity/Triangulation/blob/master/Readme/eagle_triangles_extra_points.svg" width="800" />
</p>

## Tessellation
<p align="center">
<img src="https://github.com/iShapeUnity/Triangulation/blob/master/Readme/eagle_tessellation.svg" width="800" />
</p>

## Centroid net
<p align="center">
<img src="https://github.com/iShapeUnity/Triangulation/blob/master/Readme/eagle_centroid.svg" width="800" />
</p>

## Features

💡 Fast O(n*log(n)) algorithm based on "Triangulation of monotone polygons"

💡 All code is written to suit "Data Oriented Design". No reference type like class, just structs.

💡 Supports polygons with holes

💡 Supports plain and Delaunay triangulation

💡 Supports tesselation

💡 Supports building centroid net

💡 Same points is not restricted

💡 Polygon must not have self intersections

💡 Use integer geometry for calculations

💡 More then 100 tests

## Installation

To use iShape.Triangulation in your Unity project, follow these steps:

- Open your Unity project.
- In the top menu, select "Window" > "Package Manager".
- Click on the "+" button in the top-left corner of the Package Manager window.
- Select "Add package from git URL...".
- Enter the following URL: https://github.com/iShapeUnity/Geometry.git
- Click the "Add" button.
- Wait for the package to be imported.
- After repeat all for https://github.com/iShapeUnity/Triangulation.git

## Demo

The [TriangulationDebug](https://github.com/iShapeUnity/TriangulationDebug) project is a samll demo project with some showcases.

