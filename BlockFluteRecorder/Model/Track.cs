using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockFluteRecorder.Model
{
    public class Track
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Note> Notes{ get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Title} ({Notes.Count} notes)";
        }
    }
}
