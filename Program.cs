using System;
using System.Data;
using System.Data.SqlClient;

namespace ShopDB
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryService service = new CategoryService();

            //// Thêm danh mục
            //int newId = service.AddCategory("Đồ Uống");
            //Console.WriteLine("Thêm thành công với ID: " + newId);

            // Cập nhật
            //service.UpdateCategory(newId, "Đồ Uống Cao Cấp");
            //Console.WriteLine("Cập nhật thành công.");

            //// Tìm kiếm
            //var table = service.SearchCategoryByName("Uống");
            //foreach (System.Data.DataRow row in table.Rows)
            //{
            //    Console.WriteLine($"ID: {row["CategoryID"]}, Name: {row["CategoryName"]}");
            //}

            //// Kiểm tra trùng
            //bool isDup = service.IsDuplicateCategory("Đồ Uống Cao Cấp");
            //Console.WriteLine("Trùng? " + (isDup ? "Có" : "Không"));

            //// Xóa
            //service.DeleteCategory(newId);
            //Console.WriteLine("Đã xóa danh mục.");


            // Nhân viên

            EmployeeService employeeService = new EmployeeService();

            //// 1. Thêm nhân viên
            //int id = employeeService.AddEmployee("Nguyễn Văn A", "0901234567", "a@email.com", "Kế toán", 8000000, DateTime.Now);
            //Console.WriteLine("Đã thêm nhân viên với ID: " + id);

            //// 2. Cập nhật thông tin nhân viên
            //employeeService.UpdateEmployee(id, "Nguyễn Văn A", "0901234567", "a@email.com", "Kế toán trưởng", 10000000, DateTime.Now, "Active");
            //Console.WriteLine("Đã cập nhật nhân viên.");

            //// 3. Tìm kiếm nhân viên
            //DataTable result = employeeService.SearchEmployee("Nguyễn");
            //Console.WriteLine("Danh sách nhân viên tìm được:");
            //foreach (DataRow row in result.Rows)
            //{
            //    Console.WriteLine($"{row["EmployeeID"]} - {row["FullName"]} - {row["Email"]}");
            //}

            //// 4. Kiểm tra email trùng
            //bool isDuplicate = employeeService.IsDuplicateEmail("a@email.com");
            //Console.WriteLine(" Email bị trùng? " + (isDuplicate ? "Có" : "Không"));

            //// 5. Ngưng hoạt động nhân viên
            //employeeService.DeactivateEmployee(id);
            //Console.WriteLine("Đã chuyển trạng thái sang Inactive.");

            //// 6. Xóa nhân viên
            //employeeService.DeleteEmployee(id);
            //Console.WriteLine("Đã xóa nhân viên.");
        }
    }
}
