using FitnessCode.BL.Model;
using System.Data.Entity;

namespace FitnessCode.BL.Controller
{
    class FitnessContext : DbContext
    {
        public FitnessContext() : base("FitnessCode") { }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
