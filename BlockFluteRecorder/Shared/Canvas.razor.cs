using BlockFluteRecorder.DAL;
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
        [Inject]
        private ITrackRepository _db { get; set; }
        [Inject]
        private IJSRuntime _js { get; set; }
        public string Title { get; set; }
        public bool IsPlaying { get; set; } = false;       
        [Parameter]
        public Track CurrentTrack {
            get => new Track { Notes = Notes, Title = Title };
            set 
            {
                Notes = value?.Notes;
                Title = value?.Title;
                StateHasChanged();
            }
        }
        public List<Note> Notes { get; set; }
        public async Task SaveAsync()
        {
            await _db.SaveAsync(CurrentTrack);
        }

        public void PlayPause() => IsPlaying = !IsPlaying;
        public void Stop()
        {
            IsPlaying = false;
        }

        public void AddNote(Note note)
        {
            Stop();
            Notes.Add(note);
            StateHasChanged();
        }

        public void DeleteNote(Note note)
        {
            Stop();
            Notes.Remove(note);
        }

        public void Print()
        {
            _js.InvokeVoidAsync("window.print");
        }

        protected override void OnInitialized()
        {
            Notes ??= new List<Note>();
        }
    }
}
