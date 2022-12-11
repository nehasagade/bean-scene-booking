using BeanSceneApp.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.ViewModels
{
    public class PrivateBookingViewModel
    {
        [Required, Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Column(TypeName = "Time"), DisplayName("Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
        [Required, DisplayName("Guests")]
        public int NumOfGuests { get; set; }
        [Required, DisplayName("Required Tables")]
        public int RequiredTables { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        public enum StatusEnum
        {
            Pending,
            Confirmed,
            Cancelled,
            Seated,
            Completed
        }
        [Required]
        public SourceEnum Source { get; set; }
        public enum SourceEnum
        {
            Online,
            InPerson,
            Phone,
            Email
        }
        [StringLength(500)]
        public string? Note { get; set; }
        [Required, DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required, DisplayName("Sitting Type")]
        public string SittingType { get; set; }
        public IEnumerable<Availability> Availability { get; set; }
        public IEnumerable<SittingType> SittingTypeList { get; set; }
    }
}
