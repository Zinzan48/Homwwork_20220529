using System.ComponentModel.DataAnnotations;

namespace Homework_EntityFramework.Models
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
