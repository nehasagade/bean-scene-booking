using BeanSceneApp.Models;

namespace BeanSceneApp.ViewModels
{
    public class TableViewModel
    {
        public IEnumerable<Area> Areas { get; set; }
        public Table Table { get; set; }
    }
}
