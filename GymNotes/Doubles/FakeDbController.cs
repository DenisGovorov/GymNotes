using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Doubles
{
    public class FakeTrainingDbController
    {
        private static Dictionary<Guid, SavedTraining> _fakeDb = new Dictionary<Guid, SavedTraining>();

        static FakeTrainingDbController()
        {
            var training = new SavedTraining(DateTime.Today);
            training.Sets.Add(new Set() { Exercise = new Exercise() {Name = "Squats" } });
            _fakeDb.Add(training.Id, training);
            training = new SavedTraining(DateTime.Today);
            //_fakeDb.Add(training.Id, training);
        }
        public static bool Insert(SavedTraining training)
        {
            if (_fakeDb.ContainsKey(training.Id))
                return false;
            _fakeDb.Add(training.Id, training);
            return true;
        }
        public static bool Delete(Guid id)
        {
            if (!_fakeDb.ContainsKey(id))
                return false;
            _fakeDb.Remove(id);
            return true;
        }
        public static void Load()
        {
            SavedTraining.LoadDb(new List<SavedTraining>(_fakeDb.Values));
        }
    }
}
