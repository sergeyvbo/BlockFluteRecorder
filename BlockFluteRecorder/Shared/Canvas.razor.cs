using BlockFluteRecorder.Model;
using Microsoft.AspNetCore.Components;
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

        
        [Parameter]
        public Track CurrentTrack {
            get 
            {
                return new Track { Notes = Track, Title = Title };
            }
            set 
            {
                Track = value?.Notes;
                Title = value?.Title;
                StateHasChanged();
            }
        }
        public List<Note> Track { get; set; }
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

        protected override void OnInitialized()
        {
            Track ??= new();
        }
    }
}
