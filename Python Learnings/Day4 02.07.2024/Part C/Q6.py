class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        anagram_dict=dict()
        for i in strs:
            i_list=list(i)
            i_list.sort()
            i_list=''.join(i_list)
            if(i_list in anagram_dict):
                anagram_dict[i_list].append(i)
            else:
                anagram_dict[i_list]=[i]
        result=[]
        for i in anagram_dict:
            result.append(anagram_dict[i])
        return result