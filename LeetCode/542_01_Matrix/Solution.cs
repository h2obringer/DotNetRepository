using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _542_01_Matrix
{
    public class Solution
    {
        private const int _NOT_VISITED_ = -1;

        public int[][] UpdateMatrix(int[][] mat)
        {
            int N = mat.Length;
            int M = mat[0].Length;
            int[][] result = new int[N][];

            //initialize the array
            for(int i = 0; i < N; i++)
            {
                result[i] = new int[M];
                for(int j = 0; j < M; j++)
                {
                    result[i][j] = _NOT_VISITED_; //NOT VISITED
                }
            }

            Queue<Tuple<int, int, int>> neighbors = new Queue<Tuple<int, int, int>>(); //row, col, current distance

            //Add all 0 entries in mat to result
            for (int row=0; row < mat.Length; row++)
            {
                for (int col=0; col < mat[row].Length; col++)   
                {
                    if (mat[row][col] == 0)
                    {
                        result[row][col] = 0;
                        if (row + 1 < N) neighbors.Enqueue(new Tuple<int, int, int>(row + 1, col, 1));
                        if (row - 1 >= 0) neighbors.Enqueue(new Tuple<int, int, int>(row - 1, col, 1));
                        if (col + 1 < M) neighbors.Enqueue(new Tuple<int, int, int>(row, col + 1, 1));
                        if (col - 1 >= 0) neighbors.Enqueue(new Tuple<int, int, int>(row, col - 1, 1));
                    }
                }
            }

            //begin depth-first search
            while (neighbors.Count > 0)
            {
                Tuple<int, int, int> pos = neighbors.Dequeue();
                if (result[pos.Item1][pos.Item2] == _NOT_VISITED_)
                {
                    result[pos.Item1][pos.Item2] = pos.Item3; //mark distance to this node

                    //add neighbors of this node...
                    if (pos.Item1 + 1 < N) neighbors.Enqueue(new Tuple<int, int, int>(pos.Item1 + 1, pos.Item2, pos.Item3 + 1));
                    if (pos.Item1 - 1 >= 0) neighbors.Enqueue(new Tuple<int, int, int>(pos.Item1 - 1, pos.Item2, pos.Item3 + 1));
                    if (pos.Item2 + 1 < M) neighbors.Enqueue(new Tuple<int, int, int>(pos.Item1, pos.Item2 + 1, pos.Item3 + 1));
                    if (pos.Item2 - 1 >= 0) neighbors.Enqueue(new Tuple<int, int, int>(pos.Item1, pos.Item2 - 1, pos.Item3 + 1));
                }
            }

            return result;
        }
    }
}
