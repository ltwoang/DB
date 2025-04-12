using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ShopDB
{
    public class CategoryService
    {
        private string connectionString = $"Server=LWOANG\\SHOPDB;Database=Shop2;User Id=sa;Password=123;";

        // Dùng chung helper
        private DatabaseHelper db;

        public CategoryService()
        {
            db = new DatabaseHelper(connectionString);
        }

        public int AddCategory(string categoryName)
        {
            string query = "EXEC AddCategory @CategoryName";
            SqlParameter[] parameters = {
            new SqlParameter("@CategoryName", categoryName)
        };
            object result = db.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        public void UpdateCategory(int categoryId, string categoryName)
        {
            string query = "EXEC UpdateCategory @CategoryID, @CategoryName";
            SqlParameter[] parameters = {
            new SqlParameter("@CategoryID", categoryId),
            new SqlParameter("@CategoryName", categoryName)
        };
            db.ExecuteNonQuery(query, parameters);
        }

        public void DeleteCategory(int categoryId)
        {
            string query = "EXEC DeleteCategory @CategoryID";
            SqlParameter[] parameters = {
            new SqlParameter("@CategoryID", categoryId)
        };
            db.ExecuteNonQuery(query, parameters);
        }

        public DataTable GetAllCategories()
        {
            string query = "EXEC GetAllCategories";
            return db.ExecuteQuery(query);
        }

        public DataTable SearchCategoryByName(string keyword)
        {
            string query = "EXEC SearchCategoryByName @Keyword";
            SqlParameter[] parameters = {
            new SqlParameter("@Keyword", keyword)
        };
            return db.ExecuteQuery(query, parameters);
        }

        public bool IsDuplicateCategory(string categoryName)
        {
            string query = "EXEC CheckDuplicateCategory @CategoryName";
            SqlParameter[] parameters = {
            new SqlParameter("@CategoryName", categoryName)
        };
            object result = db.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) == 1;
        }

        public DataTable GetCategoriesPaged(int pageNumber, int pageSize)
        {
            string query = "EXEC GetCategoriesPaged @PageNumber, @PageSize";
            SqlParameter[] parameters = {
            new SqlParameter("@PageNumber", pageNumber),
            new SqlParameter("@PageSize", pageSize)
        };
            return db.ExecuteQuery(query, parameters);
        }

        public DataTable GetCategoriesInUse()
        {
            string query = "EXEC GetCategoriesInUse";
            return db.ExecuteQuery(query);
        }
    }
}
