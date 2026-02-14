using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
    public class MeetingVenueModel
    {
        public int MeetingVenueID { get; set; }

        [Required(ErrorMessage = "Meeting Venue Name is required.")]
        [StringLength(100, ErrorMessage = "Meeting Venue Name cannot exceed 100 characters.")]
        public string MeetingVenueName { get; set; }

        public DateTime Created {  get; set; }

        public DateTime Modified { get; set; }
    }
}
