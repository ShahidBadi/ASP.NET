using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
    public class MeetingMemberModel
    {
        public int MeetingMemberID { get; set; }

        [Required(ErrorMessage = "Meeting is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Meeting")]
        public int MeetingID { get; set; }

        [Required(ErrorMessage = "Staff is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Staff")]
        public int StaffID { get; set; }

        [Required(ErrorMessage = "Attendance status is required")]
        public bool IsPresent { get; set; }
        [StringLength(250, ErrorMessage = "Remarks cannot exceed 250 characters")]
        public string? Remarks { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
    }
}
