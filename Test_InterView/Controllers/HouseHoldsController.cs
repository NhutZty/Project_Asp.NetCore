using Test_InterView.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Test_InterView.Domain.Interface;
using Test_InterView.Domain.ModelEntities;

namespace Test_InterView.Controllers
{
    #region HouseHoldsController
    /// <summary>
    /// HouseHoldsController
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class HouseHoldsController : ControllerBase
    {
        private readonly IHouseHoldServices _houseHoldServices;
        public HouseHoldsController(IHouseHoldServices houseHoldServices)
        {
            this._houseHoldServices = houseHoldServices;
        }

        #region GetHouseHolds
        /// <summary>
        /// GetHouseHolds
        /// </summary>
        /// <param name="state">query parameter state</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult GetHouseHolds([FromQuery] string state)
        {
            // write log to file
            LogManagement.WriteLogToFile(HttpContext.Request.Path + HttpContext.Request.QueryString);

            List<int> numberStates = Utility.GetListStateFromQueryString(
                HttpContext.Request.Query[Const.QUERY_PARAMETER_STATE]);
            if (numberStates == null)
            {
                // return a 404 HTTP Code
                return NotFound();
            }

            List<HouseHoldModels> listHouseHold = _houseHoldServices.GetHouseHolds(numberStates);
            // the data is available
            if (listHouseHold.Count == 0)
            {
                // return a 404 HTTP Code
                return NotFound();
            }

            // return the value of Households 
            return Ok(listHouseHold);
        }
        #endregion
    }
    #endregion
}
