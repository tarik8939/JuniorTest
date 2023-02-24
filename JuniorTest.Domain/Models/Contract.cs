using JuniorTest.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorTest.Domain.Models
{
    public class Contract
    {
        [Key]
        public int Id { get; set; }
        public virtual ProductionFacility Facility { get; set; }
        public int FacilityId { get; set; }
        public virtual TechnologicalEquipment Equipment { get; set; }
        public int EquipmentId { get; set; }
        public int EquipmentCount { get; set; }
    }
}
