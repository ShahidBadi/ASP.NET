using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MOM.Models;

namespace MOM.Controllers
{
    public class MeetingVenueController : Controller
    {
        public IActionResult MeetingVenueList()
        {
            List<MeetingVenueModel> venuelist=new List<MeetingVenueModel>();
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

            //Create command
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "PR_MOM_MeetingVenue_SelectAll";

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MeetingVenueModel venue = new MeetingVenueModel();

                venue.MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]);
                venue.MeetingVenueName = reader["MeetingVenueName"].ToString();
                venue.Created = Convert.ToDateTime(reader["Created"]);      
                venue.Modified = Convert.ToDateTime(reader["Modified"]);

                venuelist.Add(venue);
            }
            reader.Close();

            connection.Close();

            return View(venuelist);
        }
        public IActionResult MeetingVenueAddEdit(int? VenueId)
        {
            if(VenueId != null)
            {
                MeetingVenueModel venue = new MeetingVenueModel();
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

                //Create command
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "PR_MOM_MeetingVenue_SelectByID";
                command.Parameters.AddWithValue("@MeetingVenueID", VenueId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        venue.MeetingVenueID = Convert.ToInt32(reader["MeetingVenueID"]);
                        venue.MeetingVenueName = reader["MeetingVenueName"].ToString();
                    }
                }
                connection.Close();
                return View("MeetingVenueAddEdit",venue);
            }
            return View();
        }
        public  IActionResult DeleteVenue(int VenueId)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

                //Create command
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "PR_MOM_MeetingVenue_Delete";
                command.Parameters.AddWithValue("@MeetingVenueID", VenueId);

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
            return RedirectToAction("MeetingVenueList");
        }

        [HttpPost]
        public IActionResult saveVenue(MeetingVenueModel venue)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-3OEISF3\\SQLEXPRESS;Initial Catalog=MOM;Integrated Security=True;TrustServerCertificate=True");

                //Create command
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@MeetingVenueName", venue.MeetingVenueName);
               


                if (venue.MeetingVenueID > 0)
                {
                    command.CommandText = "PR_MOM_MeetingVenue_Update";
                    command.Parameters.AddWithValue("@MeetingVenueID", venue.MeetingVenueID);
                }
                else
                {
                    command.CommandText = "PR_MOM_MeetingVenue_Insert";
                }

               

                connection.Open();

                int noofrows = command.ExecuteNonQuery();
                if (noofrows > 0)
                {
                    TempData["successMessage"] = venue.MeetingVenueID > 0 ? "Record updated" : "Record inserted";
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                TempData["ErrrorMessage"]=ex.Message;
            }
            return RedirectToAction("MeetingVenueList");
        }

    }
}
