using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNotes.Doubles;

namespace GymNotes
{
    public class TrainingManager
    {
        private ITrainingDb _db;

        public TrainingManager(ITrainingDb db)
        {
            _db = db;
        }

        public bool AddTraining(SavedTraining training)
        {
            return _db.Insert(training);
        }
        public bool RemoveTraining(Guid id)
        {
            return _db.Delete(id);
        }
        public bool SaveTraining(SavedTraining training)
        {
            return _db.Save(training);
        }
        public SavedTraining GetTraining(Guid id)
        {
            return _db.Select(id);
        }
    }
}
