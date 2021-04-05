using System.Text.Json.Serialization;

namespace Test_InterView.Domain.ModelEntities
{
    #region PopulationModels
    /// <summary>
    /// Population Models
    /// </summary>
    public class PopulationModels
    {
        /// <summary>
        /// State
        /// </summary>
        [JsonPropertyName("State")]
        public int State { get; set; }
        /// <summary>
        /// Population
        /// </summary>
        [JsonPropertyName("Population")]
        public double Population { get; set; }
    }
    #endregion
}
