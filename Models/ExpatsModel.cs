using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PSMan.Models
{
    public class ExpatsModel
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Display(Name = "Company")]
        public string Company { get; set; }

        [Display(Name = "Email address")]
        public string Email { get; set; }

        public ExpatsModel()
        {
        }
    }
}
