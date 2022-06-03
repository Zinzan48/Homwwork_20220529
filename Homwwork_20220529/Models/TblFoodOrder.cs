using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Homwwork_20220529.Models
{
    public partial class TblFoodOrder
    {
        public int Id { get; set; }
        [Display(Name = "顧客")]
        public int CustomerId { get; set; }
        [Display(Name = "下訂食物")]
        public int Fid { get; set; }
        [Display(Name = "下訂時間")]
        public DateTime OrderDatetime { get; set; }
        [Display(Name = "付款時間")]
        public DateTime? PaidDateTime { get; set; }
    }
}
