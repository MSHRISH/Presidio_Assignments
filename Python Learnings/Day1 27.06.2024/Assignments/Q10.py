rows=int(input("Enter the Rows: "))

star="*"
space="!"

star_count=1
space_count=rows-1

for i in range(0,rows):
    star_row_pattern=star*star_count
    space_row_pattern=space*space_count
    row_pattern=space_row_pattern+star_row_pattern+space_row_pattern
    print(row_pattern)
    star_count+=2
    space_count-=1

