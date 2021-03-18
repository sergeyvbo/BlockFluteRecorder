using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockFluteRecorder.Model
{
    public class Track : IEquatable<Track>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public List<Note> Notes{ get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Track);
        }

        public bool Equals(Track other)
        {
            return other != null &&
                   Id == other.Id &&
                   Title == other.Title;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title);
        }

        public override string ToString()
        {
            return $"[{Id}] {Title} ({Notes.Count} notes)";
        }

        public static bool operator ==(Track left, Track right)
        {
            return EqualityComparer<Track>.Default.Equals(left, right);
        }

        public static bool operator !=(Track left, Track right)
        {
            return !(left == right);
        }
    }
}
