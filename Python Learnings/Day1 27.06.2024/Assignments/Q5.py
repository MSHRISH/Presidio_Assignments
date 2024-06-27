def validate_name(name):
    return name.isalpha()

from datetime import datetime,date

def calculate_age(dob):
    dob=datetime.strptime(dob, "%d.%m.%Y").date()
    today = date.today()
    calculated_age = today.year - dob.year
    if (today.month, today.day) < (dob.month, dob.day):
        calculated_age -= 1
    return calculated_age

def validate_dob(dob):
    try:
        datetime.strptime(dob, "%d.%m.%Y")
        if(calculate_age(dob)<18):
            return False
        return True
    except ValueError:
        return False

def validate_age(dob,age):
    calculated_age=calculate_age(dob)
    if(calculated_age!=int(age)):
        return False
    return True
        
def validate_phone(phone):
    return (phone.isalnum() and len(phone)==10)

while(True):
    name=input("Enter Your Name: ")
    dob=input("Enter Your DOB (DD.MM.YYYY): ")
    age=input("Enter Your age: ")
    phone=input("Enter Your Phone Number (Only 10 Digits): ")
    print("\n")
    flag=True
    if(not validate_name(name)):
        print("Enter Proper Name!")
        flag=False
    if(not validate_dob(dob)):
        print("Enter Proper DOB")
        flag=False
    if(not validate_age(dob,age)):
        print("Enter Valid AGE")
        flag=False
    if(not validate_phone(phone)):
        print("Enter valid Phone Number")
        flag=False
    if(flag):
        print("Name: {} \nDOB: {}\nAge: {}\nPhone: {}".format(name,dob,age,phone))
        break
