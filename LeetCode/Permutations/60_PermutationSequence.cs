﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Permutations
{
    class PermutationSequence
    {
        [Test]
        public void Example1()
        {
            int n = 3;
            int k = 3;
            string expected = "213";
            Assert.That(GetPermutation(n,k), Is.EqualTo(expected));
        }

        [Test]
        public void Example2()
        {
            int n = 4;
            int k = 9;
            string expected = "2314";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_13()
        {
            int n = 4;
            int k = 13;
            string expected = "3124";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_14()
        {
            int n = 4;
            int k = 14;
            string expected = "3142";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_1()
        {
            int n = 4;
            int k = 1;
            string expected = "1234";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_2()
        {
            int n = 4;
            int k = 2;
            string expected = "1243";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_3()
        {
            int n = 4;
            int k = 3;
            string expected = "1324";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_4()
        {
            int n = 4;
            int k = 4;
            string expected = "1342";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_5()
        {
            int n = 4;
            int k = 5;
            string expected = "1423";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_6()
        {
            int n = 4;
            int k = 6;
            string expected = "1432";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_7()
        {
            int n = 4;
            int k = 7;
            string expected = "2134";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_19()
        {
            int n = 4;
            int k = 19;
            string expected = "4123";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Example4_24()
        {
            int n = 4;
            int k = 24;
            string expected = "4321";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Test1()
        {
            int n = 1;
            int k = 1;
            string expected = "1";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Test2_2()
        {
            int n = 2;
            int k = 2;
            string expected = "21";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Test2_1()
        {
            int n = 2;
            int k = 1;
            string expected = "12";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Test3_6()
        {
            int n = 3;
            int k = 6;
            string expected = "321";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        [Test]
        public void Test3_1()
        {
            int n = 3;
            int k = 1;
            string expected = "123";
            Assert.That(GetPermutation(n, k), Is.EqualTo(expected));
        }

        public string GetPermutation(int n, int k)
        {
            // The set [1,2,3,...,n] contains a total of n! unique permutations.
            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++) numbers.Add(i);

            string result = "";
            int position = k - 1;
            int factorial = Fact(n - 1);
            int factor = n - 1;

            while (position > 0) // Optimization: If position == 0 no need to proceed, all further characters are in the appropriate order 
            {
                int range = position / factorial + 1; // range == index of the character
                result += numbers.ElementAt(range - 1);  // - 1 due to zero indexes
                numbers.RemoveAt(range - 1);  // - 1 due to zero indexes
                position = position % factorial + 1 - 1; // next position

                factorial /= factor;
                factor--;
            }

            foreach (var number in numbers)
            {
                result += number;
            }

            return result;
        }

        public string GetPermutationLeetCode(int n, int k)
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++) numbers.Add(i);

            string result = "";
            int remain = k - 1;

            int factorial = Fact(n - 1);
            int factor = n - 1;

            for (int i = 1; i < n; i++)
            {
                int index = remain / factorial;
                remain = remain % factorial;
                result += numbers[index];

                numbers.RemoveAt(index);

                if (remain == 0) break;

                factorial /= factor;
                factor--;
            }

            foreach (var num in numbers) result += num;

            return result;
        }

        public int Fact(int n)
        {
            if (n <= 0) return 0;

            int result = n;
            int sum = n;
            int addend = n - 2;

            while (addend > 1)
            {
                sum = sum + addend;
                result = result * sum;
                addend = addend - 2;
            }

            if (n % 2 != 0)
            {
                result = result * (n / 2 + 1);
            }

            return result;
        }
    }
}
