def swap(str_list,left,i):
    temp=str_list[left]
    str_list[left]=str_list[i]
    str_list[i]=temp

def perumations(str_list,left,right):
    if(left==right):
        print(''.join(str_list))
    else:
        for i in range(left,right):
            swap(str_list,left,i)

            perumations(str_list,left+1,right)

            swap(str_list,left,i)


a=input("Enter a String: ")
perumations(list(a),0,len(a))

    

