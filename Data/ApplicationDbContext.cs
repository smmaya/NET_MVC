using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PSMan.Controllers;
using PSMan.Models;

namespace PSMan.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PSMan.Models.ExpatsModel> Expats { get; set; }
        public DbSet<PSMan.Models.TravelModel> TravelModel { get; set; }
    }
}
