use pubs
--Print the storeid and number of orders for the store
select stor_id, count(*) as 'Order Count'  from sales group by stor_id;

--print the number of orders for every title
select t.title_id,count(ord_num) as 'Number of Orders Placed' from titles as t left join sales as s on s.title_id=t.title_id
group by t.title_id;

--print the publisher name and book name
select title ,pub_name as 'Publisher Name' from titles as t join publishers as p on t.pub_id=p.pub_id;

--Print the author full name for all the authors
select au_id 'Author Id',(au_fname+' '+au_lname) as 'Full Name' from authors;

--Print the price or every book with tax (price+price*12.36/100)
select (price+price*12.36/100) as 'Price Including Tax' from titles;

--Print the author name, title name
select title, ta.au_id ,(au_fname+' '+au_lname) as 'Author Name' from titles as t 
join titleauthor as ta on ta.title_id=t.title_id
join authors as a on ta.au_id=a.au_id;

--print the author name, title name and the publisher name
select title, ta.au_id ,(au_fname+' '+au_lname) as 'Author Name', pub_name from titles as t 
join titleauthor as ta on ta.title_id=t.title_id
join authors as a on ta.au_id=a.au_id
join publishers as p on t.pub_id=p.pub_id;

--Print the average price of books pulished by every publisher
select p.pub_id, avg(t.price) 'Average Price' from publishers as p left join titles as t on p.pub_id=t.pub_id group by p.pub_id;

--print the books published by 'Marjorie'
select title from publishers as p join titles as t on p.pub_id=t.pub_id where p.pub_name='Marjorie';

--Print the order numbers of books published by 'New Moon Books'
select ord_num from sales as s 
join titles as t on s.title_id=t.title_id
join publishers as p on t.pub_id=p.pub_id
where p.pub_name='New Moon Books';

--Print the number of orders for every publisher
select p.pub_id, count(t.pub_id) 'Orders Receives' from publishers as p 
left join titles as t on p.pub_id=t.pub_id
left join sales as s on s.title_id=t.title_id
group by p.pub_id;

--print the order number , book name, quantity, price and the total price for all orders
select ord_num,title, qty, (qty*price) 'Total Price' from sales as s 
join titles as t on s.title_id=t.title_id;

--print the total order quantity for every book
select t.title_id, sum(qty) 'OrderQuantity' from titles as t 
left join sales as s on t.title_id=s.title_id
group by t.title_id;

--print the total ordervalue for every book
select t.title_id, sum(qty*price) 'OrderValue' from titles as t 
left join sales as s on t.title_id=s.title_id
group by t.title_id;

--print the orders that are for the books published by the publisher for which 'Paolo' works for



















