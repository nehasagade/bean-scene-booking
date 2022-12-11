using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.Models
{
    public class Table
    {
        [Required, DisplayName("Area Id")]
        [Key, ForeignKey("Area")]
        public char AreaId { get; set; }        
        [Required, DisplayName("Table Number")]
        [Key]
        public int TableNum { get; set; }
        [StringLength(4),DisplayName("Table Name")]
        public string? TableName { get; set; }
        [StringLength(200)]
        public string? Note { get; set; }
        public Area? Area { get; set; }

    }
}
