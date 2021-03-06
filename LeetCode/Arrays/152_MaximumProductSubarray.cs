﻿using System;
using System.Linq;
using NUnit.Framework;

// #max_contiguous_subarray #kadanes_algorithm

namespace LeetCode.Arrays
{
    public class MaximumProductSubarray
    {
        [Test]
        public void Example1()
        {
            int[] nums = { 2, 3, -2, 4 };
            int expected = 6;
            Assert.That(MaxProduct(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int[] nums = { -2, 0, -1 };
            int expected = 0;
            Assert.That(MaxProduct(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int[] nums = { -2, -3, -1 };
            int expected = 6;
            Assert.That(MaxProduct(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test2()
        {
            int[] nums = { -2, -3, -1, -10 };
            int expected = 60;
            Assert.That(MaxProduct(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test3()
        {
            int[] nums = { -2, -3, 2, -10 };
            int expected = 60;
            Assert.That(MaxProduct(nums), Is.EqualTo(expected));
        }

        [Test]
        public void Test4()
        {
            int[] nums = { -2 };
            int expected = -2;
            Assert.That(MaxProduct(nums), Is.EqualTo(expected));
        }


        public int MaxProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return int.MinValue;
            }

            int maxProduct = nums[0];
            int imax = maxProduct;
            int imin = maxProduct;

            for (int i = 1; i < nums.Length; i++)
            {
                // in adddition to max value-so-far we also keep min  (especially, negative) value-so-far
                // since once negative value is muliplied by negative value it may become higher than max value-so-far
                // Also we search for max/main value among three of them since once negative value-so-far is multiplied by negative value
                // min becomes max and vise versa
                var candidates = new int[] { nums[i], imax * nums[i], imin * nums[i] };
                imax = candidates.Max();
                imin = candidates.Min();

                maxProduct = Math.Max(maxProduct, imax);
            }

            return maxProduct;
        }

        public int MaxProductLeetCode(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return int.MinValue;
            }

            int maxProduct = nums[0];
            int imax = maxProduct;
            int imin = maxProduct;

            //candidates = (A[i], imax * A[i], imin * A[i])
            //imax = max(candidates)
            //imin = min(candidates)

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < 0)
                {
                    // swap(imax, imin);
                    int tmp = imax;
                    imax = imin;
                    imin = tmp;
                }

                imax = Math.Max(nums[i], imax * nums[i]);
                imin = Math.Min(nums[i], imin * nums[i]);

                maxProduct = Math.Max(maxProduct, imax);
            }


            return maxProduct;
        }

        public int MaxProductNN(int[] nums) // Time Limit Exceeded
        {
            if (nums == null || nums.Length == 0)
            {
                return int.MinValue;
            }

            int maxProduct = int.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                int product = 1;
                for (int j = i; j < nums.Length; j++)
                {
                    product *= nums[j];
                    maxProduct = Math.Max(product, maxProduct);
                }
            }

            return maxProduct;
        }
    }
}