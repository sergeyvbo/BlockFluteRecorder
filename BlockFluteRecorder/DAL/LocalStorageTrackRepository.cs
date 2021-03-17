using Blazored.LocalStorage;
using BlockFluteRecorder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockFluteRecorder.DAL
{
    public class LocalStorageTrackRepository : ITrackRepository
    {
        private ILocalStorageService _db;
        public LocalStorageTrackRepository(ILocalStorageService db)
        {
            _db = db;
        }

        public async Task DeleteAsync(Track item)
        {
            await _db.RemoveItemAsync(item.Id);
        }

        public void Dispose()
        {
            
        }

        public async Task<List<Track>> FindAllAsync()
        {
            var result = new List<Track>();
            for (int i = 0; i < StorageLength(); i++)
            {
                result.Add(await _db.GetItemAsync<Track>(i.ToString()));
            }
            return result;
        }

        public async Task<Track> FindByIdAsync(string Id)
        {
            return await _db.GetItemAsync<Track>(Id);
        }

        public async Task SaveAsync(Track item)
        {
            if (item.Id == default)
            {
                item.Id = StorageLength().ToString();
            }
            await _db.SetItemAsync(item.Id, item);
        }

        private int StorageLength() => _db.LengthAsync().Result;
    }
}
