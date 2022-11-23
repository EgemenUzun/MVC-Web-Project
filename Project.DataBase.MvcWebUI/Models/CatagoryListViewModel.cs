using SellingSites.Entities;

namespace Project.DataBase.MvcWebUI.Models
{
    public class CatagoryListViewModel
    {
        public List<Category> Categories { get; internal set; }
        public int CurrentCategory { get; internal set; }
    }
}
