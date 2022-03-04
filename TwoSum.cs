//Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

//You may assume that each input would have exactly one solution, and you may not use the same element twice.

//You can return the answer in any order.

 

//Example 1:

//Input: nums = [2,7,11,15], target = 9
//Output: [0,1]
//Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].




//SOLUTION

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Hashtable ht = new Hashtable();
        for (int i = 0; i < nums.Count(); i++)
        {
            if (!ht.ContainsKey(nums[i]))
                ht.Add(nums[i], i);
            
            int compliment = target - nums[i];
            if (ht.ContainsKey(compliment) && (int)ht[compliment] != i)
                return new int[] { (int)ht[compliment], i };
        }
        
        throw new ArgumentException("No two sum found");
    }
}