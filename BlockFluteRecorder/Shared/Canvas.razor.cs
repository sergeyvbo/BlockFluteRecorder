using BlockFluteRecorder.Model;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlockFluteRecorder.Shared
{
    public partial class Canvas
    {
        public IJSRuntime js;
        public string Title { get; set; }
        public bool IsPlaying { get; set; } = false;
        public List<Note> Track { get; set; } = new List<Note>();
        public void PlayPause() => IsPlaying = !IsPlaying;
        public void Stop()
        {
            IsPlaying = false;
        }

        public void AddNote(Note note)
        {
            Stop();
            Track.Add(note);
            StateHasChanged();
        }

        public void DeleteNote(Note note)
        {
            Stop();
            Track.Remove(note);
        }

        public void Print()
        {
            Console.WriteLine("printing");
        }
    }
}
