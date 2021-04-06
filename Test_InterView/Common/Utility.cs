using System.Collections.Generic;

namespace Test_InterView.Common
{
    #region Utility
    /// <summary>
    /// Utility class
    /// </summary>
    public class Utility
    {
        #region GetListStateFromQueryString
        /// <summary>
        /// GetListStateFromQueryString
        /// </summary>
        /// <param name="queryString">queryString</param>
        /// <returns>List of State</returns>
        public static List<int> GetListStateFromQueryString(string queryString)
        {
            List<int> numberStates = new List<int>();
            
            // Query parameter state does not exist
            if (queryString == null)
            {
                return null;
            }
            
            // separate the string state with comma
            string[] listStateString = queryString.Split(Const.COMMA);
            
            foreach (var item in listStateString)
            {
                // Convert string to int
                bool isSuccess = int.TryParse(item, out int numberState);
                // cannot be converted
                if (!isSuccess)
                {
                    return null;
                }
                // Converted successfully, add State number
                numberStates.Add(numberState);
            }
            // return List of State(Interger)
            return numberStates;
        }
        #endregion
    }
    #endregion
}
