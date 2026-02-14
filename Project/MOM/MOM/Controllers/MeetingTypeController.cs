using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MOM.Models;

namespace MOM.Controllers
{
    public class MeetingTypeController : Controller
    {
        public IActionResult MeetingTypeList()
        {
            List<MeetingTypeModel> meetingTypelist = new List<MeetingTypeModel>();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

            //Create command
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "PR_MOM_MeetingType_SelectAll";

            //Open connection
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MeetingTypeModel meetingType = new MeetingTypeModel();

                meetingType.MeetingTypeID = Convert.ToInt32(reader["MeetingTypeID"]);
                meetingType.MeetingTypeName = reader["MeetingTypeName"].ToString();
                meetingType.Remarks = reader["Remarks"].ToString();

                meetingTypelist.Add(meetingType);
            }
            reader.Close();
            connection.Close();

            return View(meetingTypelist);
        }
        public IActionResult MeetingTypeAddEdit(int? meetingTypeId)
        {
            if(meetingTypeId !=null)
            {
                MeetingTypeModel MeetingType = new MeetingTypeModel();
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

                //Create command
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "PR_MOM_MeetingType_SelectByID";
                command.Parameters.AddWithValue("@MeetingTypeId", meetingTypeId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        MeetingType.MeetingTypeName = reader["MeetingTypeName"].ToString();
                        MeetingType.Remarks = reader["Remarks"].ToString();
                    }
                }
                connection.Close();
                return View("MeetingTypeAddEdit", MeetingType);
            }
            return View();
            
        }
        public IActionResult MeetingTypeDelete(int MeetingTypeId)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

                //Create command
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "PR_MOM_MeetingType_delete";
                command.Parameters.AddWithValue("@MeetingTypeID", MeetingTypeId);

                connection.Open();
                int noofrows = command.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    TempData["successMessage"] = "Record Deleted";
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("MeetingTypeList");
        }


        [HttpPost]
        public IActionResult SaveMeetingType(MeetingTypeModel meetingType)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return View("MeetingTypeAddEdit",meetingType);
                //}
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

                //Create command
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MeetingTypeName", meetingType.MeetingTypeName);
                command.Parameters.AddWithValue("@Remarks", meetingType.Remarks);
                if(meetingType.MeetingTypeID>0)
                {
                    command.CommandText = "PR_MOM_MeetingType_Update";
                    command.Parameters.AddWithValue("@MeetingTypeID", meetingType.MeetingTypeID);
                }
                else
                {
                    command.CommandText = "PR_MOM_MeetingType_Insert";

                }
                connection.Open();
                int noofrows = command.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    TempData["successMessage"] = meetingType.MeetingTypeID > 0 ? "Record updated":"Record Inserted";
                }
                connection.Close();
            }
            catch(Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
            }
            return RedirectToAction("MeetingTypeList");
        }
    }
}
