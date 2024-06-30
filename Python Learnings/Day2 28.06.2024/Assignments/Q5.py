# Credit card validation - Luhn check algorithm

def luhn_check_algo(card_no):
    card_digits = len(card_no)
    sum = 0
    is_second = False
    for i in range(card_digits - 1, -1, -1):
        d=ord(card_no[i]) - ord('0')
        if (is_second == True):
            d = d * 2
        sum += d // 10
        sum += d % 10

        is_second = not is_second
    if (sum % 10 == 0):
        return True
    else:
        return False

a=luhn_check_algo(input("Enter Credit card No.: "))
if(a):
    print("Valid Card Number")
else:
    print("Not Valid Card Number")