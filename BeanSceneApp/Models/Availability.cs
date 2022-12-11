using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.Models
{
    public class Availability
    {
        [Required, Key]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Required, DisplayName("Start Time"), Key]
        [Column(TypeName = "Time"), ForeignKey("Timeslot")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required, DisplayName("Sitting Type")]
        [StringLength(20), ForeignKey("SittingType")]
        public string SittingType { get; set; }
        [Required, DisplayName("Status")]
        public StatusEnum Status { get; set; }
        public enum StatusEnum
        {
            Available,
            Closed
        }
        [DisplayName("Max Tables")]
        public int MaxTables { get; set; }
        [DisplayName("Tables Available")]
        public int TablesAvailable { get; set; }
        [DisplayName("Max Capacity")]
        public int MaxCapacity { get; set; }

        public int Capacity { get; set; }

    }
}
