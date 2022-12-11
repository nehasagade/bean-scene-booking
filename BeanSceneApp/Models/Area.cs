using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BeanSceneApp.Models
{
    public class Area
    {
        [Required]
        [Key]
        [DisplayName("Area Id")]
        public char AreaId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [DisplayName("Image")]
        public string? ImageURL { get; set; }

    }
}
