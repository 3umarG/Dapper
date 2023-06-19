using Dapper;
using Dappper.Managers;

internal class Program
{
    private static void Main(string[] args)
    {

        #region Dapper CRUD Operations
        ProductManager manager = new();
        /*
        // Add
       if( manager.Add(new Product() { ProductName = "New Product From Dapper" ,Discontinued = false }))
        {
            Console.WriteLine("Added !!!");
        }else
        {
            Console.WriteLine("Error in Add !!!");
        }

       // GetAll
        Console.WriteLine("Products Count : "+manager.GetAll().Count);

        // Get Product By Its ID
        var pr = manager.GetByID(1);
        Console.WriteLine($"The Product in ID : 1 is {pr.ProductName}");

        // Update
        pr.ProductName = "Updated From Dapper";
        if (manager.Update(pr))
        {
            Console.WriteLine("Updated ");
        }else
        {
            Console.WriteLine("Cannot Update !!! ");
        }
        

        // Deleting
        if (manager.Remove(79))
        {
            Console.WriteLine("Removed ");
        }
        else
        {
            Console.WriteLine("Error in Removing");
        }
        */ 
        #endregion
    }

}