using Test_InterView.Model;
using System.Collections.Generic;

namespace Test_InterView.Services
{
    #region IPopulationServices
    /// <summary>
    /// IPopulationServices Interface
    /// </summary>
    public interface IPopulationServices
    {
        List<PopulationModels> GetPopulation(List<int> stateList);
    }
    #endregion
}
