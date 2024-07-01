from employee import Employee
from fpdf import FPDF
import csv

class App():
    def __init__(self) -> None:
        self.employee_list=[] #List of employees
    
    # Add employee to the list
    def add_employee(self,name,dob,phone,email):
        try:
            employee_instance=Employee(name=name,phone=phone,dob=dob,email=email)
        except Exception as inst:
            print("Employee Not added due to errors")
            for i in inst.args[0]:
                print("\t",i.message)
            raise Exception
        else:
            self.employee_list.append(employee_instance)
            print("Employee Added!\n")
    
    #Print employees on console
    def show_employees(self):
        print("Employees:\n")
        for i in self.employee_list:
            print("Name: {}\nDOB: {}\nAge: {}\nPhone: {}\nEmail: {}\n"
                  .format(i.name,i.dob,i.age,i.phone,i.email))
    
    # Export employee list accordingly
    def export_employees(self):
        print("1. Excel\n2. PDF\n3. Text")
        file_type=int(input("Enter File Type: "))
        match file_type:
            case 1:
                self.export_to_excel()
                print("Exported to excel.\n")
            case 2:
                self.export_to_PDF()
                print("Exported to PDF.\n")
            case 3:
                self.export_to_text()
                print("Exported to text file.\n")
            case _:
                print("Invalid Input!")
    
    #Export to Excel
    def export_to_excel(self):
        with open("Employees.csv", mode='w', newline='') as file:
            writer = csv.writer(file)
            writer.writerow(["Name", "Date of Birth", "Age", "Phone", "Email"])

            for employee in self.employee_list:
                 writer.writerow([employee.name, employee.dob, employee.age, employee.phone, employee.email])
    
    # Export to PDF
    def export_to_PDF(self):
        pdf = FPDF()
        pdf.add_page()
        pdf.set_font("Arial", size=12)
        column_widths = [40, 30, 10, 40, 70]
        headers = ["Name", "Date of Birth", "Age", "Phone", "Email"]
        def add_header():
            for i, header in enumerate(headers):
                pdf.cell(column_widths[i], 10, header, 1, 0, 'C')
            pdf.ln()
        add_header()
        for employee in self.employee_list:
            pdf.cell(column_widths[0], 10, employee.name, 1)
            pdf.cell(column_widths[1], 10, employee.dob, 1)
            pdf.cell(column_widths[2], 10, str(employee.age), 1)
            pdf.cell(column_widths[3], 10, employee.phone, 1)
            pdf.cell(column_widths[4], 10, employee.email, 1)
            pdf.ln()

            if pdf.get_y() > 270:
                pdf.add_page()
                add_header()
        pdf.output("Employees.pdf")

    # Export to text file
    def export_to_text(self):
        with open("Employees.txt", mode='w') as file:
            file.write("Name\tDate of Birth\tAge\tPhone\t\tEmail\n")
            for employee in self.employee_list:
                file.write(f"{employee.name}\t{employee.dob}\t{employee.age}\t{employee.phone}\t{employee.email}\n")
    
    # Bulk read from input file
    def bulk_read(self):
        with open('Inputs.csv', mode='r') as file:
            reader = csv.DictReader(file)
            row_no=1
            for row in reader:
                try:
                    app.add_employee(name=row['name'],phone=row['phone'],email=row['email'],dob=row['dob']) 
                except:
                    print("Error in row {}".format(row_no))
                row_no+=1

app=App()

while True:
    print("1. Add Employee")
    print("2. Show Employees details")
    print("3. Export Employees details")
    print("4. Bulk read from input file")
    print("5. Exit")
    n=int(input("Enter a choice: "))
    match n:
        case 1:
            name=input("Enter Employee Name: ")
            dob=input("Enter Employee DOB DD.MM.YYYY: ")
            phone=input("Enter Employee Phone Number: ")
            email=input("Enter Employee Email: ")
            try:
                app.add_employee(name=name,phone=phone,email=email,dob=dob)
            except:
                print("Error in input \n")
        case 2:
            app.show_employees()
        case 3:
            app.export_employees()
        case 4:
            app.bulk_read()
        case 5:
            break
        case _ :
            print("Invalid Input")
