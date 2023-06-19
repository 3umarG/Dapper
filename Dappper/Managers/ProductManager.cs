using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Dappper.Managers
{
    public class ProductManager : IManager<Product>
    {
        SqlConnection connection = new("Data Source=DESKTOP-EF44UM4\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;TrustServerCertificate=True");
        /// Raw SQL
        public bool Add(Product product)
        {
            try
            {
                return connection.Execute(@"

                    INSERT 
                    INTO Products
                    (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                    VALUES        
                        (@ProductName,
                        @SupplierID,
                        @CategoryID,
                        @QuantityPerUnit,
                        @UnitPrice,
                        @UnitsInStock,
                        @UnitsOnOrder,
                        @ReorderLevel,
                        @Discontinued)
                    ", product) > 0;

            }
            catch
            {
                return false;
            }
        }


        /// Query with SP
        public List<Product> GetAll()
         => connection.Query<Product>(
             "SelectAllProducts",
             commandType: System.Data.CommandType.StoredProcedure)?
            .ToList() ?? new();

        /// Raw SQL 
        public Product GetByID(long ID)
        {
            return
                connection.QueryFirstOrDefault<Product>(
                "Select * From Products Where ProductID = @ProdcutID",
                new { ProdcutID = ID }
            );
        }

        /// SP + Execute : Number of Rows Affected ...
        public bool Remove(long ID)
        {
            try
            {
                return connection.Execute("DeleteProductByID",
                    new { ID = int.Parse(ID.ToString()) },
                    commandType: System.Data.CommandType.StoredProcedure) > 0;
            }
            catch
            {
                return false;
            }
        }

        /// SP + Execute 
        public bool Update(Product product)
        {
            return connection.Execute(
                "UpdateProductNameById",
                new {product.ProductID , product.ProductName},
                commandType: System.Data.CommandType.StoredProcedure) > 0;
        }
    }
}
