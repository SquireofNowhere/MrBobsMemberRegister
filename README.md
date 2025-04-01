# MrBobsMemberRegister (C# app using IntelliJ IDE)

## Synopsis
Mr Bob has been running an art shop since 2016. His business approach is that any artist can become 
a member by registering in the shop. He has to register them manually, capturing details such as 
Surname and Name, the name of the artwork, the category of the work, size of the work, number 
of pieces and expected price etc. Each registered member can place their artwork (painting) in the 
shop for 10 months. They have to pay the rent to Mr Bob to keep their work in the shop. Rent is on 
a daily basis. If he sells any item he gets a 25% commission of selling price. Rent rate is according to 
the size of the art.

He has to capture the sold items with relevant details manually. Mr Bob is tired of this manual 
process. Hence he decided to automate his shop with some more features. He, therefore, 
approached the company “SoftwareTech solution” to develop an application for this Art Shop. The 
company appointed you as a developer to develop an application.

## Keep in mind
this app is made for Mr Bob, to be used by him and his employees .
not everyone should be able to access and change things.

Hashing a duplicate password will not give the same hash.


## tiny features
 - when picking menu item a number shows to show which menu you picked.
 - member class methods return a bool that shows whether they succeeded or not


## Things you are actually working on... bozo
- [x] BCrypt is not working... is it installed?? who knows
    - it WAS installed. it wasnt working... and then it just started working... i have zero idea why
- [ ] many menu options still not working
    - [x] Member menu does nothing.
    - [x] you need to work on registering users into the database (you currrently can't login)
	- [x] show all users option does not show all users.
    - [ ] a way to delete users would also be nice (Admin only of course)
    - [ ] make sure you mark which ones are not done... which is a lot
- [ ] localDB seems alright but theres no actual data in it.
    - [ ] member table needs to count how many artworks a member has at any given time. 
    	-  might use an update statement in code to just update the count every time a new artwork is added or deleted and stuff...
	- [ ] dynamically changing switch statement(?) to choose members in the database?

### Problems currently being faced. bugs
- [ ] show all users option does not show all options. goes to the wrong menu (was a logic issue)

## Things I need to be working on and how I will do them.


### security to keep out customers lol
password hashing i believe  
using BCrypt.Net-Next for hashing (Nuget Package)
	install w


### Storage of members
I will be using SQL Server LocalDB as it will let me use a pretty extensive data collection system while also being local so my users will not need to install any extra things on their device to use this application. A W for Mr Bob.

### Tables 
<pre>
Users
	Name - unique  
	passwordHash
	
Members
	Id - unique  
	Name  
	Surname  
	number of artworks  
	rent (calculated from artworks)  
	
Artworks 
	Id - unique  
	Owner  
	Name  
	Category  
	Size  
	SizeInt / int / length x breadth  
	expected price  
	sold price
	<pre>
	