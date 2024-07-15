class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        def dfs(opened, closed, s):
            if len(s) == n * 2:
                result.append(s)
                return 

            if opened < n:
                dfs(opened + 1, closed, s + '(')

            if closed< opened:
                dfs(opened, closed + 1, s + ')')
        result=[]
        dfs(0,0,'')
        return result
