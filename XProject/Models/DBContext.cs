using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XProject.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        
       public DbSet<Coach> coach { get; set; }
       public DbSet<Trainee> trainee { get; set; }
        public DbSet<ApplactionUsers> applactionUsers { get; set; }
        public DbSet<CoachShudel> coachShudel { get; set; }

        public DbSet<Days> days { get; set; }

        public DbSet<TrainingOffers> trainingoffers { get; set; }

        public DbSet<RequestOfferToTrainee> requestOfferToTrainee { get; set; }

    }
}
