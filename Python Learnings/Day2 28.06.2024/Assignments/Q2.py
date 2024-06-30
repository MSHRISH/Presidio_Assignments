# Print the list of prime numbers up to a given number

def primes_till_n(n):
    primes_bin = [True for i in range(n+1)]
    p = 2

    while (p * p <= n):
        if (primes_bin[p] == True):
            for i in range(p * p, n+1, p):
                primes_bin[i] = False
        p += 1
    return primes_bin

n=int(input("Enter a N value: "))

primes=primes_till_n(n)
for i in range(2,n+1):
    if(primes[i]):
        print(i,end="\n")