using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.Models
{
    public class Booking
    {
        [Required, Key]
        public int Id { get; set; }
        public string? UserId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required, DisplayName("Start Time")]
        [Column(TypeName = "Time")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
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
        [Required]
        public bool IsPrivateBooking { get; set; }
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

        [DisplayName("Tables")]
        public IEnumerable<AvailableTable>? AvailableTables { get; set; }

    }
}
