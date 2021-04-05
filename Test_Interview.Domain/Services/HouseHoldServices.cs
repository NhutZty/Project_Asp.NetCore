using System.Linq;
using System.Collections.Generic;
using Test_InterView.Domain.Interface;
using Test_InterView.Domain.ModelEntities;
using Test_Interview.Infrastructure.DataAccess;
using Test_InterView.Infrastructure.Entities;

namespace Test_InterView.Services
{
    #region HouseHoldServices
    /// <summary>
    /// HouseHoldServices Class
    /// </summary>
    public class HouseHoldServices : IHouseHoldServices
    {
        public readonly DataBaseContext context;
        public HouseHoldServices(DataBaseContext context)
        {
            this.context = context;
        }

        #region GetHouseHolds
        /// <summary>
        /// GetHouseHolds
        /// Retrieve HouseHold data from state list
        /// </summary>
        /// <param name="stateList">list of state</param>
        /// <returns>list of HouseHoldModels</returns>
        public List<HouseHoldModels> GetHouseHolds(List<int> stateList)
        {
            // list of HouseHoldModels
            List<HouseHoldModels> listHouseHolds = new List<HouseHoldModels>();

            using (context)
            {
                foreach (var state in stateList)
                {
                    // Look up Actuals table 
                    var resultActual = context.Actuals.Where(x => state == x.State).FirstOrDefault();
                    var houseHoldModel = new HouseHoldModels();

                    // If the data is available
                    if (resultActual != null)
                    {
                        houseHoldModel.State = state;
                        houseHoldModel.HouseHolds = resultActual.ActualHouseholds;
                    }
                    // the data isn't available
                    else
                    {
                        // Look up Estimates table 
                        List<EstimatesTable> resultEstimates = context.Estimates
                            .Where(x => state == x.State).ToList();
                        
                        houseHoldModel.State = state;
                        // a sum of the value over all districts for the required state in the Estimates table
                        houseHoldModel.HouseHolds = resultEstimates.Sum(x => x.EstimatesHouseholds);
                        // If any input state id is not available
                        if (resultEstimates.Count() == 0)
                        {
                            continue;
                        }
                    }

                    // Add PopulationModel to the list of HouseHoldModels
                    listHouseHolds.Add(houseHoldModel);
                }
            }

            // return the value of HouseHold 
            return listHouseHolds;
        }
        #endregion
    }
    #endregion
}
