class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if(numRows==1 or numRows>=len(s)):
            return s

        row_index=0
        direction=1 
        
        rows=[[] for _ in range(numRows)]

        for i in s:
            rows[row_index].append(i)
            if(row_index==0):
                direction=1
            elif(row_index==numRows-1):
                direction=-1
            row_index+=direction
        for i in range(numRows):
            rows[i]=''.join(rows[i])
        return ''.join(rows)
