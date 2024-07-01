from datetime import datetime,date
def validate_dob(dob):
    try:
        datetime.strptime(dob, "%d.%m.%Y")
        return dob
    except:
        raise Exception

validate_dob("03.07.2024s")