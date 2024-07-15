from collections import Counter

def merge_the_tools(string, k):
    # your code goes here    
    for i in range(0,len(string),k):
        value = ""
        count = Counter(list(string[i:(i+k)]))
        for x in count.keys():
            value += x
        print(value)