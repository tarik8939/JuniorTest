using JuniorTest.Domain.Data;
using JuniorTest.Domain.DomainModels;
using JuniorTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorTest.Domain.Repositories
{
    public class FacilityRepository : IProductionFacility
    {
        private readonly TestDBContext _context;

        public FacilityRepository()
        {
            _context = new TestDBContext(TestDBContext.ops.dbOptions);
        }
        public async Task<ProductionFacility> GetById(int id)
        {
            var facility = await _context.Facilities.FindAsync(id);

            return facility;
        }
    }
}
