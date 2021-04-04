using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_InterView.Entities
{
    [Table("Estimates")]
    public class EstimatesTable
    {
        public int State { get; set; }
        public int Districts { get; set; }
        [Required]
        public double EstimatesPopulation { get; set; }
        [Required]
        public double EstimatesHouseholds { get; set; }
    }
}
