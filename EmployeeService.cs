using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ShopDB
{
    public class EmployeeService
    {
        private string connectionString = $"Server=LWOANG\\SHOPDB;Database=Shop2;User Id=sa;Password=123;";
        private DatabaseHelper db;

        public EmployeeService()
        {
            db = new DatabaseHelper(connectionString);
        }

        // 1. Thêm nhân viên
        public int AddEmployee(string fullName, string phone, string email, string role, decimal salary, DateTime hireDate)
        {
            string query = "EXEC AddEmployee @FullName, @Phone, @Email, @Role, @Salary, @HireDate";

            SqlParameter[] parameters = {
            new SqlParameter("@FullName", fullName),
            new SqlParameter("@Phone", phone),
            new SqlParameter("@Email", email),
            new SqlParameter("@Role", role),
            new SqlParameter("@Salary", salary),
            new SqlParameter("@HireDate", hireDate)
        };

            object result = db.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result);
        }

        // 2. Cập nhật nhân viên
        public void UpdateEmployee(int employeeId, string fullName, string phone, string email, string role, decimal salary, DateTime hireDate, string status)
        {
            string query = "EXEC UpdateEmployee @EmployeeID, @FullName, @Phone, @Email, @Role, @Salary, @HireDate, @Status";

            SqlParameter[] parameters = {
            new SqlParameter("@EmployeeID", employeeId),
            new SqlParameter("@FullName", fullName),
            new SqlParameter("@Phone", phone),
            new SqlParameter("@Email", email),
            new SqlParameter("@Role", role),
            new SqlParameter("@Salary", salary),
            new SqlParameter("@HireDate", hireDate),
            new SqlParameter("@Status", status)
        };

            db.ExecuteNonQuery(query, parameters);
        }

        // 3. Xóa nhân viên
        public void DeleteEmployee(int employeeId)
        {
            string query = "EXEC DeleteEmployee @EmployeeID";
            SqlParameter[] parameters = {
            new SqlParameter("@EmployeeID", employeeId)
        };

            db.ExecuteNonQuery(query, parameters);
        }

        // 4. Lấy tất cả nhân viên
        public DataTable GetAllEmployees()
        {
            string query = "EXEC GetAllEmployees";
            return db.ExecuteQuery(query);
        }

        // 5. Tìm kiếm theo tên hoặc email
        public DataTable SearchEmployee(string keyword)
        {
            string query = "EXEC SearchEmployee @Keyword";
            SqlParameter[] parameters = {
            new SqlParameter("@Keyword", keyword)
        };
            return db.ExecuteQuery(query, parameters);
        }

        // 6. Phân trang
        public DataTable GetEmployeesPaged(int pageNumber, int pageSize)
        {
            string query = "EXEC GetEmployeesPaged @PageNumber, @PageSize";
            SqlParameter[] parameters = {
            new SqlParameter("@PageNumber", pageNumber),
            new SqlParameter("@PageSize", pageSize)
        };
            return db.ExecuteQuery(query, parameters);
        }

        // 7. Kiểm tra trùng email
        public bool IsDuplicateEmail(string email)
        {
            string query = "EXEC CheckDuplicateEmail @Email";
            SqlParameter[] parameters = {
            new SqlParameter("@Email", email)
        };
            object result = db.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) == 1;
        }

        // 8. Ngưng hoạt động nhân viên
        public void DeactivateEmployee(int employeeId)
        {
            string query = "EXEC DeactivateEmployee @EmployeeID";
            SqlParameter[] parameters = {
            new SqlParameter("@EmployeeID", employeeId)
        };
            db.ExecuteNonQuery(query, parameters);
        }
    }
}
