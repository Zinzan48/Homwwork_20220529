using System;
using System.Collections.Generic;

namespace Homwwork_20220529.Models
{
    public partial class TblFoodOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int Fid { get; set; }
        public DateTime OrderDatetime { get; set; }
        public DateTime? PaidDateTime { get; set; }
    }
}
