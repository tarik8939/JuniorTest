using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuniorTest.Domain.Interfaces;
using JuniorTest.Domain.Models;
using JuniorTest.Domain.Repositories;
using JuniorTest.Services.DTOs;

namespace JuniorTest.Services.Services
{
    public class ContractService
    {
        private readonly IContract _contract;
        private readonly IProductionFacility _facility;
        private readonly ITechnologicalEquipment _equipment;

        public ContractService()
        {
            _contract = new ContractRepository();
            _equipment = new EquipmentRepository();
            _facility = new FacilityRepository();
        }

        public async Task<ICollection<Contract>> GetAll()
        {
            var contracts = await this._contract.GetAll();
            if (contracts.Count > 0)
                return contracts;
            else
                return null;
        }

        public async Task<Contract> Create(ContractDto dto)
        {
            var contract = new Contract
            {
                EquipmentId = dto.EquipmentId,
                FacilityId = dto.FacilityId,
                EquipmentCount = dto.EquipmentCount,
            };

            var AvailableArea = await GetAccessibility(dto.FacilityId, contract);

            if (AvailableArea)
            {
                var result = await this._contract.Create(contract);
                if (result.Id > 0)
                    return result; 
                else
                    return null;
            }
            else
                return null;
        }

        private async Task<bool> GetAccessibility(int FacilityId, Contract contract)
        {
            var facility = await _facility.GetById(FacilityId);
            var contracts = await _contract.GetAllById(FacilityId);
            var equipment = await _equipment.GetById(contract.EquipmentId);

            var equipmentSquare = contracts.Sum(x => x.Equipment.Square * x.EquipmentCount);
            var squareInContracts = facility.Square - equipmentSquare;
            var AvailableArea = (squareInContracts - (equipment.Square * contract.EquipmentCount) >= 0);

            return AvailableArea;
        }
    }
}
