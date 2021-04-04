using System.Linq;
using Test_InterView.Model;
using System.Collections.Generic;
using Test_InterView.DataAccess;

namespace Test_InterView.Services
{
    #region PopulationServices
    /// <summary>
    /// PopulationServices Class
    /// </summary>
    public class PopulationServices : IPopulationServices
    {
        public readonly DataBaseContext context;
        public PopulationServices(DataBaseContext context)
        {
            this.context = context;
        }

        #region GetPopulation
        /// <summary>
        /// GetPopulation
        /// Retrieve population data from state list
        /// </summary>
        /// <param name="stateList">list of state</param>
        /// <returns>list of PopulationModel</returns>
        public List<PopulationModels> GetPopulation(List<int> stateList)
        {
            // list of PopulationModel
            List<PopulationModels> listPopulation = new List<PopulationModels>();

            using (context)
            {
                foreach (var state in stateList)
                {
                    // Look up Actuals table 
                    var resultActual = context.Actuals.Where(x => state == x.State).FirstOrDefault();
                    PopulationModels populationModel = new PopulationModels();

                    // If the data is available
                    if (resultActual != null)
                    {
                        populationModel.State = state;
                        populationModel.Population = resultActual.ActualPopulation;
                    }
                    // the data isn't available
                    else
                    {
                        // Look up Estimates table 
                        var resultEstimates = context.Estimates.Where(x => state == x.State).ToList();
                        
                        populationModel.State = state;
                        // a sum of the value over all districts for the required state in the Estimates table
                        populationModel.Population = resultEstimates.Sum(x => x.EstimatesPopulation);
                        // If any input state id is not available
                        if (resultEstimates.Count() == 0)
                        {
                            continue;
                        }
                    }

                    // Add PopulationModel to the list of PopulationModel
                    listPopulation.Add(populationModel);
                }

            }
            // return the value of Population 
            return listPopulation;
        }
        #endregion
    }
    #endregion
}
