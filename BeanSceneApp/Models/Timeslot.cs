using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.Models
{
    public class Timeslot
    {
       
        [Required, Key]
        [DisplayFormat(DataFormatString = "{0:hh:mm}")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
    }
}
