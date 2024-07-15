# Enter your code here. Read input from STDIN. Print output to STDOUT
from collections import Counter
shoes_n = int(input())

shoe_sizes=list(map(int, input().split()))
shoe_count = Counter(shoe_sizes)

customer_n = int(input())
customer_order=[]

for i in range(customer_n):
    shoe_size, shoe_price = map(int, input().split())
    customer_order.append((shoe_size,shoe_price))

total=0
for i in customer_order:
    if(shoe_count[i[0]]>0):
        shoe_count[i[0]]-=1
        total+=i[1]
print(total)