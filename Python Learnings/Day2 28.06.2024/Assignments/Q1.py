# Longest Substring Without Repeating Characters. That is in a given string find the longest substring
#  that does not contain any character twice.

def solution(str):
    char_index = {}
    max_length = 0
    start = 0
    longest_substring = ""

    for i, char in enumerate(str):
        if char in char_index and char_index[char] >= start:
            start = char_index[char] + 1
        char_index[char] = i
        current_length = i - start + 1
        if current_length > max_length:
            max_length = current_length
            longest_substring = str[start:i + 1]

    return longest_substring
    
a=input("Enter String Value: ")
print(solution(a))