﻿/* https://leetcode.com/problems/01-matrix/
 
 Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.

The distance between two adjacent cells is 1.

Example 1:

Input: mat = [[0,0,0],[0,1,0],[0,0,0]]
Output: [[0,0,0],[0,1,0],[0,0,0]]

Example 2:

Input: mat = [[0,0,0],[0,1,0],[1,1,1]]
Output: [[0,0,0],[0,1,0],[1,2,1]]

Constraints:

m == mat.length
n == mat[i].length
1 <= m, n <= 104
1 <= m * n <= 104
mat[i][j] is either 0 or 1.
There is at least one 0 in mat.

 */

namespace _542_01_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] test1 = new int[4][];
            test1[0] = new int[3] { 0, 1, 1 };
            test1[1] = new int[3] { 1, 1, 1 };
            test1[2] = new int[3] { 1, 1, 1 };
            test1[3] = new int[3] { 1, 1, 1 };

            int[][] result = s.UpdateMatrix(test1);
            for (int row = 0; row < result.Length; row++)
            {
                for (int col = 0; col < result[row].Length; col++)
                {
                    Console.Write($"{result[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}