using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes
{
    public class Set
    {
        public Exercise Exercise { get; set; }
        public int Repeats { get; }
        public float WeightDistance { get; }
        public Set(Exercise exercise, float weightDistance, int repeats = 0)
        {
            Exercise = exercise;
            Repeats = repeats;
            WeightDistance = weightDistance;
        }
        public Set()
        {
            
        }
        public enum CompareTypes
        {
            Repeats, WeightDistance, Progress
        }

        public float ComparePrevious(CompareTypes compare)
        {
            var last = SavedTraining.GetTrainingHistory().FindLast(t => t.Sets.Any(s => s.Exercise.Name == this.Exercise.Name)).Sets[0];
            float result = 0;
            switch (compare)
            {
                case CompareTypes.Repeats:
                    result = this.Repeats - (last?.Repeats ?? 0);
                    break;
                case CompareTypes.WeightDistance:
                    result = this.WeightDistance - (last?.WeightDistance ?? 0);
                    break;
                case CompareTypes.Progress:
                    result = CompareProgress(last);
                    break;
            }
            return result;
        }
        
        public virtual float CompareProgress(Set last)
        {
            return 0;
        }

        public Set  Forecast(int index)
        {
            var stat = SavedTraining.GetTrainingHistory().FindAll(t => t.Sets.Any(s => s.Exercise.Name == this.Exercise.Name));
            List<Set> sets = stat.Select(savedTraining => savedTraining.Sets[index]).ToList();
            return Forecast(sets);
        }
        public virtual Set Forecast(List<Set> stat)
        {
            return new Set();
        }
    }
}
