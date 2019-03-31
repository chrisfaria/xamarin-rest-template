using System.Collections.Generic;
using System.Threading.Tasks;
using xTemplate.Mobile.Models;

namespace xTemplate.Mobile.Contracts.Services.Data
{
    public interface ICatalogDataService
    {
        Task<IEnumerable<Item>> GetAllItemsAsync();
        Task<IEnumerable<Item>> GetItemsOfTheWeekAsync();
    }
}
