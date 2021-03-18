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
        public bool IsPlaying { get; set; } = false;
        [Parameter]
        public Track CurrentTrack { get; set; } = new Track();

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
            (CurrentTrack.Notes ??= new List<Note>()).Add(note);
            StateHasChanged();
        }

        public void DeleteNote(Note note)
        {
            Stop();
            CurrentTrack.Notes.Remove(note);
        }

        public void Print()
        {
            _js.InvokeVoidAsync("window.print");
        }

        protected override async Task OnInitializedAsync()
        {
            CurrentTrack = await _db.GetCurrentTrackAsync() ?? new Track();
        }
    }
}
