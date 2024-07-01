class InvalidNameException(Exception):
    def __init__(self, *args: object) -> None:
        super().__init__(*args)
        self.message="Invalid Name. Name must contain only characters and spaces with a min-length of 3."
       

class InvalidDOBExecption(Exception):
    def __init__(self, *args: object) -> None:
        super().__init__(*args)
        self.message="Invalid DOB.Proper Format is DD.MM.YYYY"

class InvalidAgeExecption(Exception):
    def __init__(self, *args: object) -> None:
        super().__init__(*args)
        self.message="Invalid Age. Must be minimum 18."

class InvalidPhoneNumberExecption(Exception):
    def __init__(self, *args: object) -> None:
        super().__init__(*args)
        self.message="Invalid Phone Number.Must contain only 10 digits."

class InvalidEmailExecption(Exception):
    def __init__(self, *args: object) -> None:
        super().__init__(*args)
        self.message="Invalid Email. Provide proper Email."