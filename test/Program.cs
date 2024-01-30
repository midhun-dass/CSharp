using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        // var power = Power(2, 10);
        // Console.WriteLine("##################" + power);

        // var sumUptoN = SumUptoN(5);
        // Console.WriteLine("##################" + sumUptoN);

        // var factorial = Factorial(5);
        // Console.WriteLine("##################" + factorial);

        // var fibonacci = Fibonacci(9);
        // Console.WriteLine("##################" + fibonacci);

        // var longestCommonPrefix = LongestCommonPrefix(new string[]{"flower","flow","flight"});

        var groupAnagrams = GroupAnagrams1(new string[]{"eat","tea","tan","ate","nat","bat"});

        // var reverseString = ReverseString("Hellow World");

        // var reverseWords = ReverseWords("a good   example");

        // var removeDuplicateChar = RemoveDuplicateChar("aabbccaa");

        // var removeDuplicateChar1 = RemoveDuplicateChar1("aabbccaa");

        // var countConsicutiveChar = CountConsicutiveChar("AABBCCADBB");

        // var validPalindrom = IsPalindrome("ab2a");

        // var test = Test();

        var reomveSpaceInString = ReomveSpaceInString(" Hellow World");

        var revserseWordsInString = RevserseWordsInString(" Hellow World");

        var fascinating = Fascinating(192);

        TestString();
    }

    public static int Power(int a, int b)
    {
        if (b == 0)
        {
            return 1;
        }
        else
        {
            return a * Power(a, b - 1);
        }
    }

    public static int SumUptoN(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        else
        {
            return n + SumUptoN(n - 1);
        }
    }

    public static long Factorial(int n)
    {
        if (n == 0 || n == 1)
        {
            return 1;
        }
        else
        {
            return n * Factorial(n - 1);
        }
    }

    public static int Fibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }

    public static bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> set = new HashSet<int>();

        foreach(int x in nums)
        {
            if (set.Contains(x)) return true;
            set.Add(x);
        }

        return false;
    }

    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        if (s == t) return true;

        Dictionary<char, int> countS = new Dictionary<char, int>();
        Dictionary<char, int> countT = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            countS[s[i]] = 1 + (countS.ContainsKey(s[i]) ? countS[s[i]] : 0);
            countT[t[i]] = 1 + (countT.ContainsKey(t[i]) ? countT[t[i]] : 0);
        }

        foreach(char c in countS.Keys)
        {
            int tCount = countT.ContainsKey(c) ? countT[c] : 0;
            if (countS[c] != tCount) return false;
        }

        return true;
    }

    public static int[] ReplaceElements(int[] arr)
    {
        int max = -1;

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            int newMax = Math.Max(arr[i], max);
            arr[i] = max;
            max = newMax;
        }

        return arr;
    }

    public static bool IsSubsequence(string s, string t)
    {
        int i = 0;
        int j = 0;

        while ( (i < s.Length) && (j < t.Length))
        {
            if (s[i] == t[j])
            {
                i ++;
            }

            j++;
        }

        if (i == s.Length) return true;
        else return false;
    }

    public static int LengthOfLastWord(string s)
    {
        s = s.TrimEnd();
        string[] arr = s.Split(' ');

        return arr[arr.Length - 1].Length;

    }

    public static int[]? TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> prevMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            if (prevMap.ContainsKey(diff)) return new int[] { prevMap[diff], i};

            prevMap[nums[i]] = i;
        }

        return null;
    }

    public static string LongestCommonPrefix(string[] strs)
    {
        string result = "";
        int charIndex = 0;

        int maxCharIndex = strs[0].Length;
        for (int i = 1; i < strs.Length; i ++)
        {
            maxCharIndex = Math.Min(maxCharIndex, strs[i].Length);
        }

        while (charIndex < maxCharIndex)
        {
            char c = strs[0][charIndex];
            for (int i = 1; i < strs.Length; i++)
            {
                if (c == strs[i][charIndex])
                    continue;
                else
                    return result.Substring(0, charIndex);
            }

            charIndex++;
            result += c;

        }
        
        return result.Substring(0, charIndex);
    }

    public static string LongestCommonPrefix1(string[] strs)
    {
        string res = "";

        if (strs == null || strs.Length == 0)
            return res;
        
        for (int i = 0; i < strs[0].Length; i++)
        {
            foreach(string s in strs)
            {
                if (i == s.Length || strs[0][i] != s[i])
                    return res;
            }
            res += strs[0][i];
        }
        return res;
    }

    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var groups = new Dictionary<string, IList<string>>();

        foreach(string s in strs)
        {
            char[] hash = new char[26];

            string key1 = string.Join(',', hash);       // just to understand what it is exactly
            foreach(char c in s)
            {
                hash[c - 'a']++;
            }

            string key = new string(hash);

            if (!groups.ContainsKey(key))
                groups[key] = new List<string>();

            groups[key].Add(s);
        }

        return groups.Values.ToList();
    }

    public static IList<IList<string>> GroupAnagrams1(string[] strs)
    {
        var groups = new Dictionary<string, IList<string>>();

        foreach(string s in strs)
        {
            int[] hash = new int[26];

            foreach(char c in s)
            {
                hash[c - 'a']++;
            }
            var key = string.Join(',', hash); 

            if (!groups.ContainsKey(key))
                groups[key] = new List<string>();

            groups[key].Add(s);
        }

        return groups.Values.ToList();
    }

    public static int[] ProductExceptSelf(int[] nums)
    {
        int prefix = 1, postfix = 1;
        int[] res = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            res[i] = prefix;
            prefix *= nums[i];
        }

        for (int i = nums.Length - 1; i >= 0; i--)
        {
            res[i] *= postfix;
            postfix *= nums[i];
        }

        return res;
    }

    public static int LongestConsecutive(int[] nums)
    {
        if (nums.Length < 2) return nums.Length;

        var set = new HashSet<int>(nums);
        var longest = 0;

        foreach(var n in set)
        {
            if(!set.Contains(n - 1))
            {
                var length = 0;

                while (set.Contains(n + length))
                {
                    length++;
                    longest = Math.Max(longest, length);
                }
            }
        }

        return longest;
    }

    public static string ReverseString(string str)
    {
        StringBuilder builder = new StringBuilder(str);
        var test = builder[0];
        var test1 = builder[1];
        builder[0] = builder[1];
        builder[1] = test;
        var test2 = builder[0];
        var test3 = builder[1];

        int l = 0;
        int r = str.Length - 1;

        while (l < r)
        {
            var temp = builder[l];
            builder[l++] = builder[r];
            builder[r--] = temp;
        }

        return builder.ToString();
    }

    public static int ReverseInteger(int x)
    {
        int temp = x;
        int res = 0;

        while (temp != 0)
        {
            int rem = temp % 10;
            res = res * 10 + rem;
            temp = temp /10;
        }
        
        return res;
    }

    public int ReverseInteger1(int x) 
    {
        int temp = x;
        int res = 0;

        while (temp != 0)
        {
            int rem = temp % 10;
            int tempRes = res * 10 + rem;

            if ((tempRes - rem) / 10 != res)
                return 0;
            res = tempRes;
            temp = temp /10;
        }
        
        return res;
    }

    public static string ReverseWords(string s) {
        string[] strs = s.Split(' ');
        string res = "";

        for(int i = strs.Length - 1; i >= 0; i-- )
        {
            if (strs[i] == "")
                continue;
            string temp = strs[i].TrimStart();
            temp = temp.TrimEnd();
            res = res + temp + " ";
        }

        return res.TrimEnd().TrimStart();
    }

    public static string ReverseWords1(string s) {
        string[] strs = s.Split(' ');
        string res = "";

        for(int i = strs.Length - 1; i >= 0; i-- )
        {
            if (strs[i] == "")
                continue;

            string temp = strs[i].Trim();
            res = res + temp + " ";
        }

        return res.TrimEnd();
    }

    public string ReverseWords2(string s) {
        string[] strs = s.Split(' ');
        StringBuilder sb = new StringBuilder();

        for(int i = strs.Length - 1; i >= 0; i-- )
        {
            if (strs[i] == "")
                continue;

            if (i == 0)
            {
                sb.Append(strs[i].Trim());
                continue;
            }

            sb.Append(strs[i].Trim() + " ");
        }

        return sb.ToString();
    }

    public static string RemoveDuplicateChar(string s)
    {
        StringBuilder sb = new StringBuilder();

        foreach(char c in s)
        {
            if (sb.ToString().IndexOf(c) == -1)
                sb.Append(c);
        }

        return sb.ToString();
    }

    public static string? RemoveDuplicateChar1(string s)
    {
        string res = "";
        char[] chars = s.ToCharArray();
        HashSet<char> set = new HashSet<char>(chars);

        // return set.ToString();

        foreach(char c in set)
        {
            res += c;
        }

        return res;
    }

    public static string CountConsicutiveChar(string s)
    {
        StringBuilder sb = new StringBuilder();
        int count = 1;
        
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                sb.Append(s[i - 1]);
                sb.Append(count);
                count = 1;
            }
        }

        sb.Append(s[s.Length - 1]);
        sb.Append(count);

        return sb.ToString();
    }

    public static bool IsPalindrome(string s) {
        var temp = s.ToLower();
        int l = 0;
        int r = s.Length - 1;
        if(s.Length == 0) {
            return true;
        } 

        while (l < r)
        {
            while (l < r && (!(temp[l] >= 'a' && temp[l] <= 'z') && !(temp[l] >= '0' && temp[l] <= '9')))
            {
                l++;
            }
            while (l < r && (!(temp[r] >= 'a' && temp[r] <= 'z') && !(temp[r] >= '0' && temp[r] <= '9')))
            {
                r--;
            }
            
            if (temp[l] != temp[r]) return false;
            
            l++;
            r--;
        }


        return true;
    }

    public static bool Test()
    {
        // temp will return true if the parse is successfull j return the parsed value.
        // temp will return false if the parse if fail j return 0.
        var temp = Int32.TryParse("-10 5", out int j);
        if (temp)
        {
            Console.WriteLine(j);
        }
        else
        {
            Console.WriteLine("String could not be parsed.");
        }

        return true;
    }


    public static string ReomveSpaceInString(string str)
    {
        if (str == null || str.Length < 2) return str;

        int i = 0;
        int j = 0;
        string res = "";

        while (i < str.Length && j <= i)
        {
            while (j < str.Length && !((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))) {
                j++;
                i++;
            }

            while (i < str.Length && ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))) 
            {
                i++;
            }

            res += str[j..i];
            // res += str.Substring(j, i - j);
            j = i;
        }

        return res;
    }

    public static string RevserseWordsInString(string str)
    {
        if (str == null || str.Length < 2) return str;

        int i = 0;
        int j = 0;
        string res = "";

        while (i < str.Length && j <= i)
        {
            while (j < str.Length && !((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))) {
                j++;
                i++;
            }

            while (i < str.Length && ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))) i++;

            int k = j;
            int l = i;
            while (k <= l)
            {
                res += str[--l];
            }
            j = i;
        }

        return res.TrimEnd();
    }


    public static bool Fascinating(int n)
    {
        if (n.ToString().Length < 3) return false;
        
        var p1 = n * 2;
        var p2 = n * 3;
        
        var res = n.ToString() + p1.ToString() + p2.ToString();

        if (res.Length != 9) return false;

        if (res.Length == 9)
        {
            HashSet<char> set = new HashSet<char>(res);
            if (set.Count() != 9) return false;

            foreach(char c in res)
            {
                if (c == '0') return false;
            }
        }
        
        return true;
    }

    public static void TestString()
    {
        string test = "HellowWorld";
        string test1 = "";
        string test2 = "Hellow&World";
        StringBuilder stringBuilder = new StringBuilder("Hellow World");
        
        var res1 = test
            .ToLower()
            .All(c => ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9')));
        var res2 = test1
            .ToLower()
            .All(c => ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9')));
        var res3 = test2
            .ToLower()
            .All(c => ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9')));

        var res4 = test2.Any(c => c == '&');

        var res5 = test.Contains('&');
        
        var res6 = "AAAbbbaaaBBB".Distinct();

        var res7 = test.IndexOf('&');
        var res8 = test2.IndexOf('&');

        int[] ints = new int[]{1, 2, 3, 4};
        
        int length = ints.Length;
        int length1 = ints.Count();

        int ln = test.Length;
        int ln1 = test.Count();
    }

    public static int[] Rotate(int[] nums, int k) 
    {
        int l = 0;
        int r = nums.Length - 1;

        k = k % nums.Length;

        while (l < r)
        {
            int temp = nums[l];
            nums[l++] = nums[r];
            nums[r--] = temp;
        }

        l = 0;
        r = k - 1;
        while (l < r)
        {
            int temp = nums[l];
            nums[l++] = nums[r];
            nums[r--] = temp;
        }

        l = k;
        r = nums.Length - 1;
        while (l < r)
        {
            int temp = nums[l];
            nums[l++] = nums[r];
            nums[r--] = temp;
        }

        return nums;
    }



}