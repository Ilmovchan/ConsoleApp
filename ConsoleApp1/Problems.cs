using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Problems
    {

        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> table = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int match = target - nums[i];

                if (table.ContainsKey(match))
                {
                    return new int[] { table[match], i };
                }
                table.Add(nums[i], i);
            }

            throw new Exception("Error");
        }

        public static bool SearchMatrix(int[][] matrix, int target, int min = 0, int max = -999)
        {
            if (max == -999) max = matrix.Length - 1;
            if (min > max || min < 0 || max > matrix.Length - 1) return false;

            int pivot = (min + max) / 2;

            if (matrix[pivot][0] <= target && matrix[pivot][matrix[pivot].Length - 1] >= target)
            {
                return SearchNumber(matrix[pivot], target, 0, matrix[pivot].Length - 1);
            }

            else if (matrix[pivot][matrix[pivot].Length - 1] < target)
            {
                return SearchMatrix(matrix, target, pivot + 1, max);
            }

            else return SearchMatrix(matrix, target, min, pivot - 1);
        }

        public static bool SearchNumber(int[] nums, int target, int min, int max)
        {
            if (min > max || min < 0 || max > nums.Length - 1) return false;
            int pivot = (min + max) / 2;

            if (nums[pivot] == target) return true;

            else if (nums[pivot] < target) return SearchNumber(nums, target, pivot + 1, max);

            else return SearchNumber(nums, target, min, pivot - 1);
        }
/*        public static int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];
            int j = 0;
            int i = numbers.Length - 1;
            while (j < i)
            {
                if (numbers[j] + numbers[i] > target) i--;
                else if (numbers[j] + numbers[i] < target) j++;
                else if (numbers[j] + numbers[i] == target)
                {
                    result[0] = j + 1;
                    result[1] = i + 1;
                    break;
                }
            }
            return result;
        }*/

        public static bool IsPalindrome(string s)
        {
            string str = "";
            foreach (char c in s)
            {
                if (Char.IsLetter(c) || Char.IsNumber(c)) str += c;
            }

            str = str.ToLower();

            for (int start = 0, end = str.Length - 1; start < end; start++, end--)
            {
                if (str[start] != str[end]) return false;
            }
            return true;
        }
        public static int[] DailyTemperatures(int[] temperatures)
        {
            int[] result = new int[temperatures.Length];
            Stack<KeyValuePair<int, int>> stack = new Stack<KeyValuePair<int, int>>();

            for (int i = 0; i < temperatures.Length; i++)
            {

                while (stack.Count > 0 && temperatures[i] > stack.Peek().Value)
                {
                    result[stack.Peek().Key] = i - stack.Peek().Key;
                    stack.Pop();
                }

                stack.Push(new KeyValuePair<int, int>(i, temperatures[i]));
            }

            return result;
        }

        public static Dictionary<string, Func<int, int, int>> operations = new Dictionary<string, Func<int, int, int>>
    {
        { "+", (int a, int b) => a + b },
        { "-", (int a, int b) => a - b },
        { "*", (int a, int b) => a * b },
        { "/", (int a, int b) => a / b },
    };

        public static int EvalRPN(string[] tokens)
        {
            Stack<string> stack = new Stack<string>();

            foreach (string c in tokens)
            {
                if (operations.ContainsKey(c))
                {
                    int a = Convert.ToInt32(stack.Pop());
                    int b = Convert.ToInt32(stack.Pop());

                    int result = operations[c](b, a);
                    stack.Push(Convert.ToString(result));
                }

                else stack.Push(c);
            }
            return Convert.ToInt32(stack.Pop());
        }

        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> table = new Dictionary<char, char>
        {
            {')', '('},
            {']', '['},
            {'}', '{'},
        };

            foreach (char c in s)
            {
                if (table.ContainsKey(c))
                {
                    if (stack.Count != 0 && stack.Peek() == table[c]) stack.Pop();
                    else return false;
                }
                else stack.Push(c);
            }

            if (stack.Count == 0) return true;
            else return false;
        }
        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];
            int counter = 1;

            for (int j = 0; j < nums.Length; j++)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (i != j) counter *= nums[i];
                }

                result[j] = counter;
                counter = 1;
            }

            return result;
        }

        public static int LongestConsecutive(int[] nums)
        {
            Array.Sort(nums);

            int currentLength = 1;
            int maxLength = 1;

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i + 1] - nums[i] == 1)
                {
                    currentLength++;
                }
                else if (nums[i + 1] - nums[i] > 1)
                {
                    currentLength = 1;
                }
                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                }

            }
            return maxLength;
        }

        public static bool IsValidSudoku(char[][] board)
        {
            char[] col = new char[board.Length];
            char[] square = new char[board.Length];

            for (int i = 0; i < board.Length; i++)
            {
                if (IsValid(board[i]) == false) return false; // ROW CHECK
            }

            for (int j = 0; j < board.Length; j++)
            {
                for (int i = 0; i < board.Length; i++)
                {
                    col[i] = board[i][j];
                }

                if (IsValid(col) == false) return false; // COL CHECK
            }

            for (int blockRow = 0; blockRow < 9; blockRow += 3)
            {
                for (int blockCol = 0; blockCol < 9; blockCol += 3)
                {
                    int index = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            square[index] = board[blockRow + i][blockCol + j];
                            index++;
                        }
                    }

                    if (IsValid(square) == false) return false; // SQUARE CHECK
                }
            }

            return true;
        }

        public static bool IsValid(char[] row)
        {
            Dictionary<char, int> numCounter = new Dictionary<char, int>();

            foreach (char element in row)
            {
                if (!numCounter.ContainsKey(element))
                {
                    numCounter.Add(element, 0);
                }
                numCounter[element]++;
            }

            foreach (var element in numCounter)
            {
                if (element.Value > 1 && element.Key != '.') return false;
            }

            return true;
        }
        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> numCounter = new Dictionary<int, int>();

            foreach (int number in nums)
            {
                if (!numCounter.ContainsKey(number))
                {
                    numCounter.Add(number, 0);
                }
                numCounter[number]++;
            }

            var sortedNumCounter = numCounter.OrderByDescending(x => x.Value)
                                           .ToDictionary(pair => pair.Key, pair => pair.Value);

            int[] result = sortedNumCounter.Keys.Take(k).ToArray();

            return result;
        }


        static List<List<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> anagramGroups = new Dictionary<string, List<string>>();

            foreach (string word in strs)
            {
                string sortedWord = SortString(word);

                if (!anagramGroups.ContainsKey(sortedWord))
                {
                    anagramGroups[sortedWord] = new List<string>();
                }

                anagramGroups[sortedWord].Add(word);
            }



            return anagramGroups.Values.ToList();
        }

        public static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        public static bool IsAnagram(string s, string t)
        {
            List<char> list = t.ToList();

            for (int j = 0; j < s.Length; j++)
            {
                if (list.Contains(s[j]))
                {
                    list.Remove(s[j]);
                }
            }

            if (list.Count == 0) return true;
            else return false;
        }
    }
}
