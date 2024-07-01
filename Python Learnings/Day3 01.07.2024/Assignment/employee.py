from CustomExecptions import *
import re
from datetime import datetime,date

class Employee:
    def __init__(self,name,dob,phone,email) -> None:
        self.errors=[]
        
        self.name=self.validate_name(name)
        self.dob=self.validate_dob(dob)
        if(self.dob!=None):
            self.age=self.calculate_age(dob)
        self.phone=self.validate_phone(phone)
        self.email=self.validate_email(email)
        
        if(self.errors):
            raise Exception(self.errors)
    # Validates Name
    def validate_name(self,name):
         pattern = re.compile(r'^[A-Za-z ]{3,}$')
         if(bool(pattern.match(name))):
             return name
         else:
             self.errors.append(InvalidNameException())
             return None
    
    # Validate dob
    def validate_dob(self,dob):
        try:
            datetime.strptime(dob, "%d.%m.%Y")
            return dob
        except:
            self.errors.append(InvalidDOBExecption())
            return None
        
    #Calculate and Validate Age
    def calculate_age(self,dob):
        dob=datetime.strptime(dob, "%d.%m.%Y").date()
        today = date.today()
        calculated_age = today.year - dob.year
        if (today.month, today.day) < (dob.month, dob.day):
            calculated_age -= 1
        if(calculated_age<18):
            self.errors.append(InvalidAgeExecption())
        return calculated_age
    
    # Validate Phone number
    def validate_phone(self,phone):
        pattern = re.compile(r'^\d{10}$')
        if(bool(pattern.match(phone))):
            return phone
        else:
            self.errors.append(InvalidPhoneNumberExecption())
    
    #Validate email
    def validate_email(self,email):
        pattern = re.compile(r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$')
        if(bool(pattern.match(email))):
            return email
        else:
            self.errors.append(InvalidEmailExecption())