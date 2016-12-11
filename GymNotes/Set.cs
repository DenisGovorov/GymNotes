using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes
{
    public class Set
    {
        public Exercise Exercise { get; }
        public int Repeats { get; }
        public float WeightDistance { get; }
        public Set(Exercise exercise, float weightDistance, int repeats = 0)
        {
            Exercise = exercise;
            Repeats = repeats;
            WeightDistance = weightDistance;
        }
    }
}
