--Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name
create procedure proc_printBooksByAuthor(@Aname varchar(200))
as 
begin
	select title,pub_name from titles as t 
	join publishers as p on t.pub_id=p.pub_id
	where title_id in 
	(select title_id from titleauthor where au_id=(select au_id from authors where au_fname=@Aname));
END


exec proc_printBooksByAuthor 'Marjorie';

-- Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.
alter procedure proc_EmployeeSales(@Ename varchar(50))
as
begin
	select t.title, t.price, s.qty, (t.price * s.qty) 'Total Cost' from titles t join sales s on t.title_id = s.title_id
	join employee e on e.pub_id = t.pub_id where e.fname=@Ename
end

exec proc_EmployeeSales 'peter';

--Create a query that will print all names from authors and employees
select (au_fname+' '+au_lname) as AuthorName, 'Author' as role from authors 
UNION
select CONCAT(fname, ' ', lname) as EmployeeName,'Employee' as role from employee
order by role;

--Create a  query that will float the data from sales,titles, publisher and authors table to print title name, Publisher's name, author's full name with quantity ordered and price for the order for all orders,
--print first 5 orders after sorting them based on the price of order
select TOP 5 title,pub_name,(au_fname+' '+au_lname) as 'AuthorName',qty,(qty*price) as 'OrderPrice' from titles as t
join publishers as p on t.pub_id=p.pub_id
join titleauthor as ta on ta.title_id=t.title_id
join authors as a on ta.au_id=a.au_id
join sales as s on s.title_id=t.title_id
order by OrderPrice;



