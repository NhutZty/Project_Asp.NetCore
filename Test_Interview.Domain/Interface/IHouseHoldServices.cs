using System.Collections.Generic;
using Test_InterView.Domain.ModelEntities;

namespace Test_InterView.Domain.Interface
{
    #region IHouseHoldServices
    /// <summary>
    /// IHouseHoldServices Interface
    /// </summary>
    public interface IHouseHoldServices
    {
        List<HouseHoldModels> GetHouseHolds(List<int> stateList);
    }
    #endregion
}
