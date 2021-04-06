using Test_Interview.Infrastructure.DataAccess;
using Test_Interview.Domain.Interface;
using Test_Interview.Domain.Repo;

namespace Test_Interview.Domain
{
    #region UnitOfWork
    /// <summary>
    /// UnitOfWork Class
    /// </summary>
    public class UnitOfWork
    {
        private DataBaseContext _context = null;
        private HouseHoldRepository _houseHoldRepository = null;
        private PopulationRepository _populationRepository = null;
        
        public UnitOfWork(DataBaseContext context)
        {
            this._context = context;
        }

        public HouseHoldRepository HouseHoldRepository
        {
            get
            {
                if (_houseHoldRepository == null) 
                {
                    _houseHoldRepository = new HouseHoldRepository(_context); 
                }
                return _houseHoldRepository; 
            }
        }
        public PopulationRepository PopulationRepository
        {
            get
            {
                if (_populationRepository == null) 
                {
                    _populationRepository = new PopulationRepository(_context);
    }
                return _populationRepository; 
            }
        }

    }
    #endregion
}
