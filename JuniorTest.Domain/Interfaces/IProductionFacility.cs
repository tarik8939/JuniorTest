using JuniorTest.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorTest.Domain.Interfaces
{
    public interface IProductionFacility
    {
        Task<ProductionFacility> GetById(int id);
    }
}
