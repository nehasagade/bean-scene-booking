using BeanSceneApp.Models;

namespace BeanSceneApp.ViewModels
{
    public class PrivateBookingAvailableTable
    {
        public IEnumerable<Booking> Booking { get; set; }

        public IEnumerable<AvailableTable> AvailableTables { get; set; }
    }
}
