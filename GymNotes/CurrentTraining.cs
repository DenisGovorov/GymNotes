using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes
{
    public class CurrentTraining
    {
        public static CurrentTraining Instance => _instance ?? (_instance = new CurrentTraining());
        private static CurrentTraining _instance;
        
        private  CurrentTraining(){}
        public bool IsActive { get; private set; }
        public DateTime StarTime;
        private List<Set> _sets = new List<Set>();
        private List<Exercise> _plannedExercise = new List<Exercise>();

        public void ClearPlannedList()
        {
            _plannedExercise.Clear();
        }

        public void AddToPlanned(Exercise exercise)
        {
            _plannedExercise.Add(exercise);
        }

        public bool Start()
        {
            if (_plannedExercise.Count == 0)
                return false;
            StarTime = DateTime.Now;
            IsActive = true;
            return true;
        }

        public void AddSet(Exercise exercise, float weightDistance, int repeats = 0)
        {
            _sets.Add(new Set(exercise, weightDistance, repeats));
        }

        public void Finish()
        {
            SavedTraining.Add(this, DateTime.Now);

        }
    }
}
