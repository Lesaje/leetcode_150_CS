public static class ArraysAndHashing {
    public static bool isAnagram(string s, string t)
    {
        var sortedStringS = new String(s.OrderBy(c => c).ToArray());
        var sortedStringT = new String(t.OrderBy(c => c).ToArray());

        return sortedStringS == sortedStringT;
    }
}