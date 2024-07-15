#!/bin/python3

import math
import os
import random
import re
import sys
from collections import Counter


if __name__ == '__main__':
    s = input()
    character_count = Counter(list(s))
    sorted_char_count = sorted(character_count.items(), key=lambda x: (-x[1], x[0]))
    top_three = sorted_char_count[:3]
    for char, count in top_three:
        print(f"{char} {count}")
    