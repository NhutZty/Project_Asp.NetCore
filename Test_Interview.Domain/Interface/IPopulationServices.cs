using Test_InterView.Domain.ModelEntities;
using System.Collections.Generic;

namespace Test_InterView.Domain.Interface
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
