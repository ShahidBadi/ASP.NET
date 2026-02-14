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
        public IActionResult MeetingTypeAddEdit()
        {
            return View();
        }
        public IActionResult MeetingTypeDelete(int MeetingTypeId)
        {
            return RedirectToAction("MeetingTypeList");
        }
    }
}
