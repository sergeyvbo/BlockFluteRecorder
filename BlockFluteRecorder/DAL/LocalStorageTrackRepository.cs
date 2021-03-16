using Blazored.LocalStorage;
using BlockFluteRecorder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockFluteRecorder.DAL
{
    public class LocalStorageTrackRepository : IRepository<Track>
    {
        private ILocalStorageService _db;
        public LocalStorageTrackRepository(ILocalStorageService db)
        {
            _db = db;
        }
        public void Create(Track item)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            _db.RemoveItemAsync(id);
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<Track> FindAll()
        {
            var result = new List<Track>();
            for (int i = 0; i < StorageLength(); i++)
            {
                _db.GetItemAsync<Track>(i.ToString());
                
            }
        }

        public Track FindById(string id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Track item)
        {
            throw new NotImplementedException();
        }

        private async Task<int> StorageLength() => await _db.LengthAsync();
    }
}
