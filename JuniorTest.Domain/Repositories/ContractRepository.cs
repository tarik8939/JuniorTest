using JuniorTest.Domain.Data;
using JuniorTest.Domain.Interfaces;
using JuniorTest.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorTest.Domain.Repositories
{
    public class ContractRepository : IContract
    {
        private readonly TestDBContext _context;

        public ContractRepository()
        {
            _context = new TestDBContext(TestDBContext.ops.dbOptions);
        }

        public async Task<Contract> Create(Contract contract)
        {
            _context.Contracts.Add(contract);
            await _context.SaveChangesAsync();

            return contract;
        }

        public Task<List<Contract>> GetAll()
        {
            var contracts = _context.Contracts
                .Include(x => x.Equipment)
                .Include(x => x.Facility)
                .ToListAsync();

            return contracts;
        }

        public Task<List<Contract>> GetAllById(int id)
        {
           var contracts = _context.Contracts
                .Include(x => x.Equipment)
                .Include(x => x.Facility)
                .Where(x => x.FacilityId == id)
                .ToListAsync();

            return contracts;
        }
    }
}
