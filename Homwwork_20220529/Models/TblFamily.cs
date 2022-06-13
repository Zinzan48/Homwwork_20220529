using System;
using System.Collections.Generic;

namespace Homework_EntityFramework.Models
{
    public partial class TblFamily
    {
        public int FamilyId { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Title { get; set; }
        public string? NickName { get; set; }
    }
}
