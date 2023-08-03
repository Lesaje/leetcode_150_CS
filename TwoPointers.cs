public static class TwoPointers
{
    public static bool IsPalindrome(string s) 
    {
        var clean = s.ToLower().Where(x => char.IsLetterOrDigit(x));
        return clean.Reverse().SequenceEqual(clean);
    }
}