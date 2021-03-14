using BlockFluteRecorder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockFluteRecorder.Shared
{
    public partial class Canvas
    {
        public string Title { get; set; }
        public bool IsPlaying { get; set; } = false;
        public List<Note> Track { get; set; }
        public void PlayPause() => IsPlaying = !IsPlaying;
        public void Stop()
        {
            IsPlaying = false;
        }

        public void DeleteNote(Note note)
        {
            Track.Remove(note);
        }
    }
}
