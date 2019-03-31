using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Akavache;
using xTemplate.Mobile.Constants;
using xTemplate.Mobile.Contracts.Services.Data;
//using xTemplate.Mobile.Extensions;
using xTemplate.Mobile.Models;
using System.Reactive.Linq;
using xTemplate.Mobile.Contracts.Repository;

namespace xTemplate.Mobile.Services.Data
{
    public class CatalogDataService : BaseService, ICatalogDataService
    {
        private readonly IGenericRepository _genericRepository;

        public CatalogDataService(IGenericRepository genericRepository, 
            IBlobCache cache = null) : base(cache)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            List<Item> itemsFromCache = 
                await GetFromCache<List<Item>>(CacheNameConstants.AllItems);

            if (itemsFromCache != null)//loaded from cache
            {
                return itemsFromCache;
            }
            else
            {
                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.ItemsEndpoint
                };

                var items = await _genericRepository.GetAsync<List<Item>>(builder.ToString());

                await Cache.InsertObject(CacheNameConstants.AllItems, items, DateTimeOffset.Now.AddSeconds(20));

                return items;
            }
        }

        public async Task<IEnumerable<Item>> GetItemsOfTheWeekAsync()
        {
            List<Item> itemsFromCache = await GetFromCache<List<Item>>(CacheNameConstants.ItemsOfTheWeek);

            if (itemsFromCache != null)//loaded from cache
            {
                return itemsFromCache;
            }

            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.ItemsOfTheWeekEndpoint
            };

            var items = await _genericRepository.GetAsync<List<Item>>(builder.ToString());

            await Cache.InsertObject(CacheNameConstants.ItemsOfTheWeek, items, DateTimeOffset.Now.AddSeconds(20));

            return items;
        }
    }
}
