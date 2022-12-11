using BeanSceneApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneApp.ViewModels
{
    public class AvailabilityViewModel
    {
        public Availability Availability { get; set; }

        public IEnumerable<SittingType> SittingTypeList { get; set; }

        public IEnumerable<Timeslot> Timeslot { get; set; }

        [DisplayName("End Date"), Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        [DisplayName("End Time"), Required]
        public TimeSpan EndTime { get; set; }
        public StatusEnum Status { get; set; }
        public enum StatusEnum
        {
            Available,
            Closed
        }

        //[DisplayName("Main")]
        //public bool MainAvailable { get; set; }
        //[DisplayName("Outdoor")]
        //public bool OutdoorAvailable { get; set; }
        //[DisplayName("Balcony")]
        //public bool BalconyAvailable { get; set; }

        public IEnumerable<SelectedArea> SelectedAreas;
        public IEnumerable<char> SelectedAreaIds;
    }
}
