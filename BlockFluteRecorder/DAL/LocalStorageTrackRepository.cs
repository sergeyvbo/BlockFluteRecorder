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
            var length = await StorageLengthAsync();
            for (int i = 0; i < length; i++)
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
                var length = await StorageLengthAsync();
                item.Id = length.ToString();
            }
            await _db.SetItemAsync(item.Id, item);
        }

        private async Task<int> StorageLengthAsync() => await _db.LengthAsync();
    }
}
