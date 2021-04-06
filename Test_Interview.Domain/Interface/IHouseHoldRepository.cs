using System.Collections.Generic;
using Test_InterView.Domain.ModelEntities;

namespace Test_Interview.Domain.Interface
{
    #region IHouseHoldRepository
    /// <summary>
    /// IHouseHoldRepository Interface
    /// </summary>
    public interface IHouseHoldRepository
    {
        List<HouseHoldModels> GetHouseHolds(List<int> stateList);
    }
    #endregion
}
