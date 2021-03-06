﻿namespace LeetCode.Array2D
{
    public class ReshapeTheMatrix
    {
        public int[][] MatrixReshapeOneLoop(int[][] nums, int r, int c)
        {
            if (nums == null || nums.Length == 0 || nums[0].Length == 0
                || nums.Length * nums[0].Length != r * c
                || (nums.Length == r && nums[0].Length == c))
            {
                return nums;
            }

            int[][] newNums = new int[r][];
            int m = nums[0].Length;

            for (int i = 0; i < r*c; i++)
            {
                if(newNums[i / c] == null) newNums[i / c] = new int[c];
                newNums[i / c][i % c] = nums[i / m][i % m];
            }

            return newNums;
        }


        public int[][] MatrixReshape(int[][] nums, int r, int c)
        {
            if (nums == null || nums.Length == 0 || nums[0].Length == 0
                || nums.Length * nums[0].Length != r * c
                || (nums.Length == r && nums[0].Length == c))
            {
                return nums;
            }

            int cnt = 0;
            int[][] newNums = new int[r][];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[0].Length; j++)
                {
                    if(newNums[cnt / c] == null) newNums[cnt / c] = new int[c];
                    newNums[cnt / c][cnt % c] = nums[i][j];
                    cnt++;
                }
            }

            return newNums;
        }



        public int[][] MatrixReshapeCheck(int[][] nums, int r, int c)
        {
            if (nums == null || nums.Length == 0 || nums[0].Length == 0 
                || nums.Length * nums[0].Length != r * c
                || (nums.Length == r && nums[0].Length == c))
            {
                return nums;
            }

            int row = 0;
            int col = 0;
            int[][] newNums = new int[r][];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums[0].Length; j++)
                {
                    if (newNums[row] == null)
                    {
                        newNums[row] = new int[c];
                    }

                    newNums[row][col] = nums[i][j];

                    col++;
                    if (col == c)
                    {
                        col = 0;
                        row++;
                    }
                }
            }

            return newNums;
        }
    }
}