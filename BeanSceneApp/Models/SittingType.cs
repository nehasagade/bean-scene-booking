using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneApp.Models
{
    public class SittingType
    {
        [Required, Key]
        [StringLength(20)]
        [DisplayName("Sitting Type")]
        public string SittingName { get; set; }
    }
}
