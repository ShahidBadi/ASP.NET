using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MOM.Models;

namespace MOM.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult DepartmentList()
        {
            List<DepartmentModel> departmentlist = new List<DepartmentModel>();
            //connection string
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

            //Create command
            SqlCommand command = connection.CreateCommand();
            command.CommandType=System.Data.CommandType.StoredProcedure;
            command.CommandText = "PR_MOM_Department_SelectAll";

            //Open connection
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DepartmentModel department=new DepartmentModel();

                department.DepartmentID = Convert.ToInt32(reader["DepartmentID"]);
                department.DepartmentName = reader["DepartmentName"].ToString();
                department.Created = Convert.ToDateTime(reader["Created"]);
                department.Modified = Convert.ToDateTime(reader["Modified"]);

                departmentlist.Add(department);

            }

            reader.Close();

            connection.Close();



            return View(departmentlist);
        }
        public IActionResult DepartmentAddEdit(int? DepartmentId)
        {
            if(DepartmentId != null)
            {
                DepartmentModel department = new DepartmentModel();
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

                //Create command
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "PR_MOM_Department_SelectByID";
                command.Parameters.AddWithValue("@DepartmentId", DepartmentId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        department.DepartmentName = reader["DepartmentName"].ToString();
                    }
                    
                }
                connection.Close();
                return View("departmentAddEdit",department);

            }
            return View();
        }
        public IActionResult DepartmentDelete(int DepartmentId)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

                //Create command
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "PR_MOM_Department_Delete";
                command.Parameters.AddWithValue("@DepartmentId", DepartmentId);

                connection.Open();

                int noofrows = command.ExecuteNonQuery();
                if(noofrows > 0)
                {
                    TempData["successMessage"] = "Record Deleted";
                }


                connection.Close();
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("DepartmentList");
        }

        public IActionResult saveDepartment(DepartmentModel department)
        {
            try
            {
                //if(!ModelState.IsValid)
                //{
                //    return View("DepartmentAddEdit",department);
                //}
           
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

                //Create command
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
              
                command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);

                if (department.DepartmentID > 0)
                {
                    command.CommandText = "PR_MOM_Department_Update";
                    command.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
                }
                else
                {
                    command.CommandText = "PR_MOM_Department_Insert";
                }

                  connection.Open();

                int noofrows = command.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    TempData["successMessage"] = department.DepartmentID>0 ? "Record updated":"Record inserted";
                }


                connection.Close();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("DepartmentList");
        }

    }
}
