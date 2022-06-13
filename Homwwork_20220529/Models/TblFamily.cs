using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework_EntityFramework.Models
{
    public partial class TblFamily : FamilySearch
    {
        public int FamilyId { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Title { get; set; }
        public string? NickName { get; set; }
    }
    public class FamilySearch
    {
        [NotMapped]
        public string? SearchName { get; set; }
        [NotMapped]
        public int SearchAge { get; set; }
        [NotMapped]
        public string? SearchTitle { get; set; }
    }
}
