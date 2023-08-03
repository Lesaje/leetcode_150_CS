public static class BinarySearch 
{

    static public int Search(int[] nums, int target) {
        GC.Collect();
        var L = 0;
        var R = nums.Length - 1;

        if (nums[0] == target) return 0;

        while (L < R) {
            var m = (L+R)/2;
            if (nums[m] < target) {
                L += 1;
            }
            else if (nums[m] > target) {
                R -= 1;
            }
            else return m;
        }

        if (nums[R] == target) return R;
        return -1;
    }
}