using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Doubles
{
    public interface ITrainingDb
    {
        bool Insert(SavedTraining training);
        bool Save(SavedTraining training);
        SavedTraining Select(Guid id);
        bool Delete(Guid id);
        void DeleteAll();
    }
}
