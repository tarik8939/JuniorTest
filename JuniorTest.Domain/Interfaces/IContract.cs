using JuniorTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorTest.Domain.Interfaces
{
    public interface IContract
    {
        Task<Contract> Create(Contract contract);
        Task<List<Contract>> GetAll();

        Task<List<Contract>> GetAllById(int id);
    }
}
