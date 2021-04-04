using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_InterView.Entities
{
    [Table("Actuals")]
    public class ActualsTable
    {
        [Key]
        public int State { get; set; }

        [Required]
        public double ActualPopulation { get; set; }

        [Required]
        public double ActualHouseholds { get; set; }
    }
}
