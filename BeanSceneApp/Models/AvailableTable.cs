using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.Models
{
    public class AvailableTable
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Start Time"), Key]
        [Column(TypeName = "Time"), ForeignKey("Timeslot")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required, DisplayName("Area Id")] 
        public char AreaId { get; set; }
        [Required, DisplayName("Table Number")]
        public int TableNum { get; set; }

        public int? BookingId { get; set; }
    }
}
