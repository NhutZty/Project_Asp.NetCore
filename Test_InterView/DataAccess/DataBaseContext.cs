using Test_InterView.Entities;
using Microsoft.EntityFrameworkCore;

namespace Test_InterView.DataAccess
{
    #region DataBaseContext
    /// <summary>
    /// DataBaseContext
    /// </summary>
    public class DataBaseContext : DbContext
    {
        #region DbSet
        public DbSet<ActualsTable> Actuals { get; set; }
        public DbSet<EstimatesTable> Estimates { get; set; }
        #endregion

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EstimatesTable>().HasKey(estimate => new {
                estimate.State,
                estimate.Districts
            });
        }
    }
    #endregion
}
