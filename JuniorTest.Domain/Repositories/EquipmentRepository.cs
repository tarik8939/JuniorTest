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
    public class EquipmentRepository : ITechnologicalEquipment
    {
        private readonly TestDBContext _context;

        public EquipmentRepository()
        {
            _context = new TestDBContext(TestDBContext.ops.dbOptions);
        }

        public async Task<TechnologicalEquipment> GetById(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);

            return equipment;
        }
    }
}
