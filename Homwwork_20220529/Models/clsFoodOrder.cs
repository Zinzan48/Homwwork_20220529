using Microsoft.EntityFrameworkCore;

namespace Homework_EntityFramework.Models
{
    public class clsFoodOrder : TblFoodOrder
    {
        private readonly HomeworkDBContext _context;
        public clsFoodOrder(HomeworkDBContext context)
        {
            _context = context;
        }
        public async Task<bool> SetMoney(int id)
        {
            var FoodOrder = await _context.TblFoodOrders.FindAsync(id);
            var customer = await _context.TblCustomers.FindAsync(FoodOrder.CustomerId);
            var food = await _context.TblFoods.FindAsync(FoodOrder.Fid);
            var money = food.Price;
            var moneyBag = customer.Money;
            moneyBag = moneyBag - money;
            if (moneyBag < 0)
            {
                return false;
            }
            customer.Money = moneyBag;
            FoodOrder.PaidDateTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
