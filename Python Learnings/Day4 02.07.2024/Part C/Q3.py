class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:
        n=len(nums)
        nums.sort()
        difference=20001
        result=0
        for i in range(n):
            start=i+1
            end=n-1
            while(start<end):
                triple_sum=nums[i]+nums[start]+nums[end]
                distance=abs(triple_sum-target)
                if(distance<difference):
                    difference=distance
                    result=triple_sum
                if(triple_sum==target):
                    return triple_sum
                elif(triple_sum<target):
                    start+=1
                else:
                    end-=1
            
        return result