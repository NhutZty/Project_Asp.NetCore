using Test_InterView.Model;
using System.Collections.Generic;

namespace Test_InterView.Services
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
