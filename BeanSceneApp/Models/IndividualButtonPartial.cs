using System.Text;

namespace BeanSceneApp.Models
{
    public class IndividualButtonPartial
    {
        public string ButtonType {get; set; }
        public string Action { get; set; }
        public string Glyph { get; set; }
        public string Text { get; set; }

        // Nullable properties
        public char? AreaId { get; set; }
        public int? TableNum { get; set; }
        public string? SittingType { get; set; }
        public DateTime? AvailabilityDate { get; set; }
        public TimeSpan? AvailabilityTime { get; set; }

        public string ActionParam
        {
            get
            {
                var param = new StringBuilder("/");
                if (AreaId != null && TableNum != null)
                {
                    param.Append(String.Format("{0}/{1}", AreaId, TableNum));
                }
                else if(AreaId != null)
                {
                    param.Append(String.Format("{0}", AreaId));
                }
                else if (AvailabilityDate != null && AvailabilityTime != null)
                {
                    
                    param.Append(String.Format("{0:yyyy-MM-dd}/{1}", AvailabilityDate, AvailabilityTime));
                    
                }
                return param.ToString();
            }
        }
        
    }
}
