using JuniorTest.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuniorTest.Domain.DomainModels
{
    public class TechnologicalEquipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Square { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
