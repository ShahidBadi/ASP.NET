using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
    public class MeetingsModel
    {
        public int MeetingID { get; set; }

        [Required(ErrorMessage = "Meeting date is required")]
        [DataType(DataType.DateTime)]
        public DateTime MeetingDate { get; set; }

        [Required(ErrorMessage = "Meeting venue is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid venue")]
        public int MeetingVenueID { get; set; }

        [Required(ErrorMessage = "Meeting type is required")]   
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid meeting type")]
        public int MeetingTypeID { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid department")]
        public int DepartmentID { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? MeetingDescription { get; set; }

        public string? DocumentPath { get; set; }

        public DateTime Created {  get; set; }

        public DateTime Modified {  get; set; }

        public bool IsCancelled { get; set; }

        public DateTime? CancellationDateTime { get; set; }


        [StringLength(300, ErrorMessage = "Cancellation reason cannot exceed 300 characters")]
        public string? CancellationReason { get; set; }
    }
}
