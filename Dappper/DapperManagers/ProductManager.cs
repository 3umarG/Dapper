using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Entities;
using Dapper.Context;
using Microsoft.EntityFrameworkCore;

namespace Dappper.Managers
{
    public class ProductManager : IManager<Product>
    {
        // I will receive the Connection String from the Context of the EF 
        SqlConnection connection;

        public ProductManager(NorthwindContext context)
        {
            connection = new SqlConnection(context.Database.GetConnectionString());
        }
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
        /// I will update this function because the given product has alot of attributes that I don't need
        public bool Update(Product product)
        {
            return connection.Execute(
                "UpdateProductNameById",
                new { product.ProductID, product.ProductName },
                commandType: System.Data.CommandType.StoredProcedure) > 0;
        }
    }
}
