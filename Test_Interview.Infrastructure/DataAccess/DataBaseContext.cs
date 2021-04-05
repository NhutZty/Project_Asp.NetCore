using Microsoft.EntityFrameworkCore;
using Test_InterView.Infrastructure.Entities;

namespace Test_Interview.Infrastructure.DataAccess
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
