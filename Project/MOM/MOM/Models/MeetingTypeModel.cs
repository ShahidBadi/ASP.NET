using System.ComponentModel.DataAnnotations;

namespace MOM.Models
{
    public class MeetingTypeModel
    {
        public int MeetingTypeID { get; set; }

        [Required(ErrorMessage = "Meeting Type Name is required")]
        [StringLength(100, ErrorMessage = "Meeting Type Name cannot exceed 100 characters")]
        public string MeetingTypeName { get; set; }

        [StringLength(250, ErrorMessage = "Remarks cannot exceed 250 characters")]
        public string Remarks { get; set; }
    }
}
