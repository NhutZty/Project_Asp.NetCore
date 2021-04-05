using System.Text.Json.Serialization;

namespace Test_InterView.Domain.ModelEntities
{
    #region HouseHoldModels
    /// <summary>
    /// HouseHoldModels
    /// </summary>
    public class HouseHoldModels
    {
        /// <summary>
        /// State
        /// </summary>
        [JsonPropertyName("State")]
        public int State { get; set; }
        /// <summary>
        /// HouseHolds
        /// </summary>
        [JsonPropertyName("HouseHolds")]
        public double HouseHolds { get; set; }
    }
    #endregion
}
