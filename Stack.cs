namespace Leetcode150;

public static class Stack
{
    public static bool IsValid(string s)
    {
        var closeToOpen = new Dictionary<char, char>();
        closeToOpen.Add(')', '(');
        closeToOpen.Add('}', '{');
        closeToOpen.Add(']', '[');

        if (s.Length == 1) return false;

        var stack = new Stack<char>();

        for (var i = 0; i < s.Length; i++)
        {
            if (closeToOpen.ContainsKey(s[i]))
            {
                if (stack.Count != 0 && stack.Peek() == closeToOpen[s[i]]) stack.Pop();
                else return false;
            }
            else stack.Push(s[i]);
        }

        if (stack.Count == 0) return true;
        else return false;
    }
}