using Test_InterView.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Test_InterView.Domain.ModelEntities;
using Test_Interview.Domain.Interface;
using Test_Interview.Domain;

namespace Test_InterView.Controllers
{
    #region PopulationController
    /// <summary>
    /// PopulationController
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PopulationController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        public PopulationController(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        #region GetPopulation
        /// <summary>
        /// GetPopulation
        /// </summary>
        /// <param name="state">query parameter state</param>
        /// <returns>IActionResult</returns>
        [HttpGet]
        public IActionResult GetPopulation([FromQuery] string state)
        {
            // write log to file
            LogManagement.WriteLogToFile(HttpContext.Request.Path + HttpContext.Request.QueryString);

            List<int> numberStates = Utility.GetListStateFromQueryString(HttpContext.Request.Query["state"]);
            if (numberStates == null)
            {
                // return a 404 HTTP Code
                return NotFound();
            }

            List<PopulationModels> listPopulation = _unitOfWork.PopulationRepository.GetPopulation(numberStates);
            // the data is available
            if (listPopulation.Count == 0)
            {
                // return a 404 HTTP Code
                return NotFound();
            }

            // return the value of Population
            return Ok(listPopulation);
        }
        #endregion
    }
    #endregion
}
