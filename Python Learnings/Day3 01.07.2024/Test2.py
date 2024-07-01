# from test import Test

class Test2:
    test_attribute_2=2
    def create_Test_obj(self):
        # import test
        from test import Test
        # this is  a local import
        a=Test()
        print(a.test_attribute)
        x=dir(Test)
        print(x)

b=Test2()
b.create_Test_obj()

