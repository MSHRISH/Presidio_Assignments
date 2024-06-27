p=int(input("Enter a Number: "))

def is_prime(p):
    if(p>1):
        for i in range(2,int(p/2)+1):
            if(p%i==0):
                return False
        return True
    return False

print(is_prime(p))