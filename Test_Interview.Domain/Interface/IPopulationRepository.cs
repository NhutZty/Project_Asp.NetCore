using Test_InterView.Domain.ModelEntities;
using System.Collections.Generic;

namespace Test_Interview.Domain.Interface
{
    #region IPopulationRepository
    /// <summary>
    /// IPopulationRepository Interface
    /// </summary>
    public interface IPopulationRepository
    {
        List<PopulationModels> GetPopulation(List<int> stateList);
    }
    #endregion
}
