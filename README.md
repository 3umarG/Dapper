# Dapper Micro-ORM for .NET

This repository provides information and resources for working with Dapper, a lightweight micro-ORM (Object-Relational Mapping) library for .NET and some code examples for using it with EF in the same project.

## What is Dapper?

Dapper is a simple, high-performance micro-ORM developed by the folks at Stack Exchange. It was designed with simplicity and performance in mind, making it an excellent choice for developers who want to work with raw SQL queries while still benefiting from the convenience of object mapping.

Dapper uses lightweight code generation and ADO.NET to map query results to .NET objects. It provides a minimalistic API that allows you to write SQL queries directly and easily map the results to your domain objects or DTOs (Data Transfer Objects).

## When to Use Dapper?

Dapper is a great choice for various scenarios. Here are some situations where Dapper shines:

1. **Performance-Critical Applications:** If you have performance-sensitive applications that require fast data access, Dapper's lightweight and efficient implementation can provide a significant performance boost compared to full-fledged ORMs like Entity Framework (EF).

2. **Raw SQL Queries:** Dapper allows you to write raw SQL queries and easily map the results to your objects. This is particularly useful when you have complex or optimized SQL queries that are challenging to express using an ORM's query language.

3. **Minimal Configuration:** Dapper requires minimal configuration and has a small learning curve. If you prefer a simpler ORM that doesn't rely on complex configuration or conventions, Dapper is an excellent choice.

4. **Compatibility with Existing Data Access Code:** Dapper plays well with existing ADO.NET code, so if you already have a data access layer built with ADO.NET, you can easily integrate Dapper into your existing codebase without major refactoring.

## Dapper vs. Entity Framework (EF)

Dapper and Entity Framework are both popular choices for data access in .NET applications. Here's a brief comparison between the two:

**Dapper:**

- Lightweight and high-performance micro-ORM.
- Requires manual SQL query writing and mapping.
- Offers greater control over database interactions and performance optimizations.
- Suitable for scenarios that require fine-grained control over SQL queries and execution.

**Entity Framework:**

- Full-featured ORM with support for various database providers.
- Provides a higher level of abstraction, allowing you to work with LINQ queries and abstracted database operations.
- Automatic mapping between database tables and domain objects.
- Suitable for rapid development, prototyping, and scenarios where complex query composition is not a priority.

When choosing between Dapper and Entity Framework, consider the specific needs of your project. If performance, fine-grained control over queries, and working with raw SQL are important, Dapper may be a better fit. On the other hand, if you value productivity, abstraction, and seamless integration with different databases, Entity Framework could be the way to go.



### Query Example:

```csharp
using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    // Execute a query and map the results to a list of objects
    var products = connection.Query<Product>("SELECT * FROM Products").ToList();

    foreach (var product in products)
    {
        Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
    }
}
```

### Execute Example:
```csharp
using (var connection = new SqlConnection(connectionString))
{
    connection.Open();

    // Execute a query to insert a new record
    var affectedRows = connection.Execute("INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)",
        new { Name = "John Doe", Email = "john.doe@example.com" });

    Console.WriteLine($"Affected Rows: {affectedRows}");
}
```
