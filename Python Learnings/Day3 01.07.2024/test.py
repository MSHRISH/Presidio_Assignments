class custome_execption(Exception):
    def __init__(self, *args: object) -> None:
        super().__init__(*args)
        self.message="This is a custom execption"

class Test:
    test_attribute=1
    def new_method(self):
        print("hello world")
    def execption_method(self):
        try:
            raise custome_execption
        except Exception as execp:
            print(execp.message)



a=Test()
a.execption_method()


# print(a.test_attribute)

# # del a.test_attribute

# # print(a.test_attribute)

# a.new_attribute=34
# print(a.new_attribute)

# Test.new_method(a)

# b=Test()
# b.test_attribute=90

# print(b.test_attribute)
# print(a.test_attribute)