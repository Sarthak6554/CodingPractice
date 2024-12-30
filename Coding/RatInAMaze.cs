using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class RatInAMaze
    {
        public RatInAMaze()
        {
            int mazeSize = 4;
            int[,] maze = new int[,] {
                {1, 0, 0, 0 },
                {1, 1, 0, 1 },
                {1, 1, 0, 0 },
                {0, 1, 1, 1 }
            };

            findPath(maze, mazeSize);
        }

        void findPath(int[,] maze, int mazeSize)
        {
            // This is required because if we are at [1,0] then again the traversing logic
            // will pick [0,0] as its is Upward and it will become a repetative procedure
            // of up and down from [0,0] to [1,0] then again [1,0] to [0,0]
            int[,] visted = new int[mazeSize, mazeSize];

            List<string> paths = new List<string>();


            if (maze[0, 0] == 1)
            {
                GetPathInAMaze(0, 0, ref maze, ref visted, mazeSize, "", ref paths);
            }
        }

        /// <summary>
        /// Time Complexity: O(4^(m*n)), because on every cell we need to try 4 different directions
        /// Space Complexity:  O(m*n) ,Maximum Depth of the recursion tree(auxiliary space)
        /// </summary>
        void GetPathInAMaze(int x, int y, ref int[,] maze, ref int[,] visted, int mazeSize, string path, ref List<string> paths)
        {
            if (x == mazeSize - 1 && y == mazeSize - 1)
            {
                paths.Add(path);
                return;
            }

            // We want the path in lexiological order that is DLRU

            // Down movement
            if (x + 1 < mazeSize && visted[x + 1, y] == 0 && maze[x + 1, y] == 1)
            {
                visted[x, y] = 1;
                GetPathInAMaze(x + 1, y, ref maze, ref visted, mazeSize, path + "D", ref paths);
                visted[x, y] = 0;
            }

            // Left movement
            if (y - 1 >= 0 && visted[x, y - 1] == 0 && maze[x, y - 1] == 1)
            {
                visted[x, y] = 1;
                GetPathInAMaze(x, y - 1, ref maze, ref visted, mazeSize, path + "L", ref paths);
                visted[x, y] = 0;
            }

            // Right movement
            if (y + 1 < mazeSize && visted[x, y + 1] == 0 && maze[x, y + 1] == 1)
            {
                visted[x, y] = 1;
                GetPathInAMaze(x, y + 1, ref maze, ref visted, mazeSize, path + "R", ref paths);
                visted[x, y] = 0;
            }

            // Up movement
            if (x - 1 >= 0 && visted[x - 1, y] == 0 && maze[x - 1, y] == 1)
            {
                visted[x, y] = 1;
                GetPathInAMaze(x - 1, y, ref maze, ref visted, mazeSize, path + "U", ref paths);
                visted[x, y] = 0;
            }
        }
    }
}
