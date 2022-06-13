using Homework_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Homework_EntityFramework.Models
{
    public class FoodViewModel
    {
        private readonly HomeworkDBContext _context;
        public List<TblFood> _tblFood { get; set; }
        public Search _search { get; set; }
        public FoodViewModel(HomeworkDBContext context)
        {
            _context = context;
            _tblFood = new List<TblFood>();
            _search = new Search();
        }
        public async Task GetFoods()
        {
            var Food = _context.TblFoods.AsQueryable();
            if (_search != null)
            {
                if (_search.minPrice != null)
                {
                    Food = Food.Where(x => x.Price >= _search.minPrice);
                }
                if (_search.maxPrice != null)
                {
                    Food = Food.Where(x => x.Price <= _search.maxPrice);
                }
                if (_search.star != null)
                {
                    Food = Food.Where(x => x.Stars == _search.star);
                }
            }
            _tblFood = await Food.ToListAsync();
        }
    }
    public class Search
    {
        [Display(Name = "最低價格")]
        public int? minPrice { get; set; }
        [Display(Name = "最高價格")]
        public int? maxPrice { get; set; }
        [Display(Name = "星星數")]
        [Range(1, 5)]
        public int? star { get; set; }
    }
}
