Dapper is a simple and lightweight Object-Relational Mapping (ORM) library for .NET. It is used for data access in applications where performance is critical and the developer needs fine-grained control over SQL queries. Below is a brief explanation of a Dapper CRUD (Create, Read, Update, Delete) application.
Here I am using Dapper for creating new records, reading existing records, updating records, and deleting records. Dapper simplifies the process of executing SQL queries and mapping the results to .NET objects.
Following things I use here
DATABASE Name - DapperApp , Table Name - Product
Model - Products 
Properties - 

public int PId { get; set; }
[Required]
public string Pname { get; set; }
[Required]
public string Description { get; set; }
[Required]
[Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number")]
public int Price { get; set; }
public DateTime CreatedDate { get; set; }

Here In AddProduct, EditProduct and Delete functionality I use Tempdata["Message"] also for show one time erromessage of successfully product add-update message.

PacakageInstall - Dapper(The library that provides functionality to execute SQL commands and map the results to models)
Advantages of Using Dapper:

Performance: Dapper is known for its speed, as it is a micro-ORM that does not impose much overhead on database interactions.
Flexibility: Developers have the freedom to write raw SQL queries and optimize them as needed.
