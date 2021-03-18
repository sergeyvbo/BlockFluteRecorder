using BlockFluteRecorder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockFluteRecorder.DAL
{
    public interface ITrackRepository
    {
        Task<List<Track>> FindAllAsync();
        Task SaveAsync(Track item);
        Task DeleteAsync(Track item);
        Task<Track> FindByIdAsync(string Id);
        Task<Track> FirstAsync();
        Task SetCurrentTrackAsync(Track track);
        Task<Track> GetCurrentTrackAsync();

    }
}
