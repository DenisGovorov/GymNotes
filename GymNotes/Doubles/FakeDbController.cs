using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Doubles
{
    public class FakeTrainingDbController : ITrainingDb
    {
        private static Dictionary<Guid, SavedTraining> _fakeDb = new Dictionary<Guid, SavedTraining>();

        //static FakeTrainingDbController()
        //{
        //    var training = new SavedTraining(DateTime.Today);
        //    _fakeDb.Add(training.Id, training);
        //    training = new SavedTraining(DateTime.Today);
        //    _fakeDb.Add(training.Id, training);
        //}
        public bool Insert(SavedTraining training)
        {
            if (_fakeDb.ContainsKey(training.Id))
                return false;
            _fakeDb.Add(training.Id, training);
            return true;
        }
        public bool Save(SavedTraining training)
        {
            if (_fakeDb.ContainsKey(training.Id))
                return false;
            _fakeDb[training.Id] = training;
            return true;
        }
        public SavedTraining Select(Guid id)
        {
            return _fakeDb.ContainsKey(id) ? null : _fakeDb[id];
        }
        public bool Delete(Guid id)
        {
            if (!_fakeDb.ContainsKey(id))
                return false;
            _fakeDb.Remove(id);
            return true;
        }

        public void DeleteAll()
        {
            _fakeDb.Clear();
        } 
    }
}
