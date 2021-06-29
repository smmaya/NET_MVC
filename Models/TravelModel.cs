using System;
using System.ComponentModel.DataAnnotations;

namespace PSMan.Models
{
    public class TravelModel
    {
        public int Id { get; set; }

        [Display(Name = "Flight No.")]
        public string Flight { get; set; }

        [Display(Name = "From")]
        public string FromCity { get; set; }

        [Display(Name = "Departure")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy hh:mm}")]
        public DateTime FromDepartureTime { get; set; }

        [Display(Name = "To")]
        public string ToCity { get; set; }

        [Display(Name = "Estimated Landing")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy hh:mm}")]
        public DateTime ToLandingTime { get; set; }

        public TravelModel()
        {
        }
    }
}
