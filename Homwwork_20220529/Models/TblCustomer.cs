using System;
using System.Collections.Generic;

namespace Homework_EntityFramework.Models
{
    public partial class TblCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Money { get; set; }
    }
}
