using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplications.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }

        public static List<Product> GetAllProduct()
        { 
            List<Product> lstPro = new List<Product>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=true";
            
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Product";
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read()) 
                {
                    lstPro.Add(new Product { ProductId = dr.GetInt32(0), 
                        ProductName = dr.GetString(1), Price = dr.GetString(2) });

                    //dr.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally { cn.Close(); } 

            return lstPro;
        }

        public static void InsertProduct(Product obj) 
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=true";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Product Values(@ProductId, @ProductName, @Price)";

                cmd.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmd.Parameters.AddWithValue("@Price", obj.Price);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { cn.Close(); }

        }

        public static void UpdateProduct(Product obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=true";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update Product set ProductName=@ProductName, Price=@Price Where ProductId=@ProductId";

                cmd.Parameters.AddWithValue("@ProductId", obj.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmd.Parameters.AddWithValue("@Price", obj.Price);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { cn.Close(); }

        }

        public static void DeleteProduct(int ProductId)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=true";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete from Product Where ProductId = @ProductId";

                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { cn.Close(); }

        }

        public static Product GetSingleProduct(int ProductId)
        {
            Product obj = new Product();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KTjune23;Integrated Security=true";
            cn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Product Where ProductId = @ProductId";
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    obj.ProductId = ProductId;
                    obj.ProductName = dr.GetString("ProductName");
                    obj.Price = dr.GetString("Price");
                }
                else 
                {
                    //not found
                    obj = null;
                }

                dr.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
            finally { cn.Close(); }

            return obj;
        }
    }
}