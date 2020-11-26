using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace PathfinderTest
{
    public class Tests
    {
        TilemapGrid grid;
        TilemapCell start;
        TilemapCell target;

        [SetUp]
        public void Setup()
        {
            char [,] tilemap = new char[10, 10]
            {
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' }, // 0
                { '.', '.', '.', '.', '#', '#', '#', '#', '#', '.' }, // 1
                { '.', '.', '.', '.', '#', '#', '#', '#', '.', '.' }, // 2
                { '.', '#', '#', '.', '#', '#', '.', '.', '.', '.' }, // 3
                { '.', '#', '#', '.', '#', '#', 'T', '.', '.', '.' }, // 4
                { '.', '#', '#', '.', '#', '#', '.', '.', '.', '.' }, // 5
                { '.', '#', '#', '.', '#', '#', '#', '#', '#', '#' }, // 6
                { '.', '.', '.', '.', '#', '#', '#', '#', '#', '.' }, // 7
                { '.', '.', '.', 'S', '#', '#', '#', '#', '#', '.' }, // 8
                { '.', '.', '.', '.', '.', '.', '.', '.', '.', '.' }, // 9
                // 0    1    2    3    4    5    6    7    8    9
            };

            grid = new TilemapGrid(tilemap);
            start = new TilemapCell(3, 8, 0);
            target = new TilemapCell(6, 4, 0);
        }

        [Test]
        public void TestWalkablePath()
        {
            List<Cell> expectedPath = new List<Cell>()
            {
                new TilemapCell(3, 7, 0),
                new TilemapCell(3, 6, 0),
                new TilemapCell(3, 5, 0),
                new TilemapCell(3, 4, 0),
                new TilemapCell(3, 3, 0),
                new TilemapCell(3, 2, 0),
                new TilemapCell(3, 1, 0),
                new TilemapCell(4, 0, 0),
                new TilemapCell(5, 0, 0),
                new TilemapCell(6, 0, 0),
                new TilemapCell(7, 0, 0),
                new TilemapCell(8, 0, 0),
                new TilemapCell(9, 1, 0),
                new TilemapCell(8, 2, 0),
                new TilemapCell(7, 3, 0),
                new TilemapCell(6, 4, 0),
            };

            List<Cell> walkablePath = Pathfinder.GetWalkablePath(grid, start, target);

            foreach (var cell in walkablePath)
            {
                Console.WriteLine(cell.X + "," + cell.Y);
            }

            Assert.AreEqual(expectedPath.Count, walkablePath.Count);

            for (int i = 0; i < walkablePath.Count; ++i)
            {
                Assert.IsTrue(walkablePath[i].Equals(expectedPath[i]));
            }
        }


        [Test]
        public void TestGridCollisionCells()
        {
            Assert.False(grid.IsWalkable(new TilemapCell(1, 3, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(1, 4, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(1, 5, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(1, 6, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(2, 3, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(2, 4, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(2, 5, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(2, 6, 0)));

            Assert.False(grid.IsWalkable(new TilemapCell(4, 1, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(4, 2, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(4, 3, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(4, 4, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(4, 5, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(4, 6, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(4, 7, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(4, 8, 0)));

            Assert.False(grid.IsWalkable(new TilemapCell(5, 1, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(5, 2, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(5, 3, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(5, 4, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(5, 5, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(5, 6, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(5, 7, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(5, 8, 0)));

            Assert.False(grid.IsWalkable(new TilemapCell(6, 1, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(6, 2, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(6, 6, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(6, 7, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(6, 8, 0)));

            Assert.False(grid.IsWalkable(new TilemapCell(7, 1, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(7, 2, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(7, 6, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(7, 7, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(7, 8, 0)));

            Assert.False(grid.IsWalkable(new TilemapCell(8, 1, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(8, 6, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(8, 7, 0)));
            Assert.False(grid.IsWalkable(new TilemapCell(8, 8, 0)));

            Assert.False(grid.IsWalkable(new TilemapCell(9, 6, 0)));
        }

        [Test]
        public void TestGridWalkableCells()
        {
            Assert.True(grid.IsWalkable(new TilemapCell(3, 7, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(3, 6, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(3, 5, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(3, 4, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(3, 3, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(3, 2, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(3, 1, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(4, 0, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(5, 0, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(6, 0, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(7, 0, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(8, 0, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(9, 1, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(8, 2, 0)));
            Assert.True(grid.IsWalkable(new TilemapCell(7, 3, 0)));
        }

        [Test]
        public void TestGridStartNeighbors()
        {
            List<Cell> startNeighbors = grid.GetNeighbors(start);

            int walkable = 0;
            int collision = 0;

            foreach (var neighbor in startNeighbors)
            {
                if (grid.IsWalkable(neighbor))
                {
                    ++walkable;
                }

                if (!grid.IsWalkable(neighbor))
                {
                    ++collision;
                }
            }

            Assert.AreEqual(8, startNeighbors.Count);
            Assert.AreEqual(2, collision);
            Assert.AreEqual(6, walkable);
        }
    }
}