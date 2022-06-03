using System.ComponentModel.DataAnnotations;

namespace Homwwork_20220529.Models
{
    public class FoodOrderViewModel : TblFoodOrder
    {
        public string? FoodName { get; set; }
        public string? CustomerName { get; set; }
        [Display(Name = "顧客餘額")]
        public decimal? CustomerMoney { get; set; }
        [Display(Name = "售價")]
        public decimal? FoodMoney { get; set; }
    }
}
