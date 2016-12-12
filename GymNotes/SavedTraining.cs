using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes
{
    public class SavedTraining
    {
        private static List<SavedTraining> _history = new List<SavedTraining>();
        public DateTime StarTime;
        public TimeSpan Duration;
        private List<DummySet> _sets = new List<DummySet>();
        public Guid Id { get; private set; }
        public static void Add(CurrentTraining current, DateTime time)
        {
            var training = new SavedTraining()
            {
                _sets = current.GetSets(),
                StarTime = current.StarTime,
                Duration =  time - current.StarTime,
                
            };
            _history.Add(training);
        }

        public static List<SavedTraining> GetTrainingHistory()
        {
            return _history;
        }
        public static void RemoveAll()
        {
            _history.Clear();
        }
        public static void LoadDb(List<SavedTraining> data)
        {
            _history.Clear();
            _history = data;
        }

        public SavedTraining()
        {
            Id = Guid.NewGuid();
        }
        public SavedTraining(DateTime startTime)
        {
            StarTime = startTime;
            Id = Guid.NewGuid();
        }
    }

}
