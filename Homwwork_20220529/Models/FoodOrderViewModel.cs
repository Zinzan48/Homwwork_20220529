using System.ComponentModel.DataAnnotations;

namespace Homwwork_20220529.Models
{
    public class FoodOrderViewModel : TblFoodOrder
    {
        public string? FoodName { get; set; }
        public string? CustomerName { get; set; }
    }
}
