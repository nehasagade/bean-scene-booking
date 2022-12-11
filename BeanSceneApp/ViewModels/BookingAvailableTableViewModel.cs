using BeanSceneApp.Models;

namespace BeanSceneApp.ViewModels
{
    public class BookingAvailableTableViewModel
    {
        public Booking? Booking { get; set; }

        public IEnumerable<AvailableTable> AvailableTables { get; set; }


    }
}
