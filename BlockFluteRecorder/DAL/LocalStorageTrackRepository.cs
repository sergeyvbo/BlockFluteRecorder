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

        private const string CURRENT_TRACK_KEY = "currentTrack";
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
            for (var i = 0; i < length; i++)
            {
                var key = await _db.KeyAsync(i);
                if (key == CURRENT_TRACK_KEY)
                {
                    continue;
                }
                var item = await _db.GetItemAsync<Track>(key);
                if (item is not null)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public async Task<Track> FindByIdAsync(string Id)
        {
            return await _db.GetItemAsync<Track>(Id);
        }

        public async Task<Track> FirstAsync()
        {
            var key = await _db.KeyAsync(0);
            if (string.IsNullOrEmpty(key))
            {
                return null;
            }

            return await _db.GetItemAsync<Track>(key);
        }

        public async Task SaveAsync(Track item)
        {
            if (item.Id == default)
            {
                var key = await GetMinimalUnusedKeyAsync();
                item.Id = key;
            }
            await _db.SetItemAsync(item.Id, item);
        }

        public async Task SetCurrentTrackAsync(Track track)
        {
            await _db.SetItemAsync(CURRENT_TRACK_KEY, track);
        }

        public async Task<Track> GetCurrentTrackAsync()
        {
            return await _db.GetItemAsync<Track>(CURRENT_TRACK_KEY);
        }

        public async Task<string> GetMinimalUnusedKeyAsync()
        {
            List<int> keys = new();
            var length = await StorageLengthAsync();
            for (var i = 0; i < length; i++)
            {
                string keyString = await _db.KeyAsync(i);
                if (keyString == CURRENT_TRACK_KEY)
                {
                    continue;
                }
                var key = int.Parse(keyString);
                keys.Add(key);
            }
            keys.Sort();
            for (var i = 0; i < keys.Count; i++)
            {
                if (keys[i] > i)
                {
                    return i.ToString();
                }
            }
            return keys.Count.ToString();
        }
        private async Task<int> StorageLengthAsync() => await _db.LengthAsync();
    }
}
