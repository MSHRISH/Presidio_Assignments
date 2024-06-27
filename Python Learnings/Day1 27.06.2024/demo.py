print("Hello world")


import sys
import fileinput


sys.stdin=open('test.txt','r',encoding='utf-8')
sys.stdout=open('Output.txt','w',encoding='utf-8')

with fileinput.input(files=sys.stdin, encoding="utf-8") as f:
        for line in f:
            print("Line: ",f.lineno(),line,end="")

