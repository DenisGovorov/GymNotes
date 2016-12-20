using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNotes.Doubles;

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
        public readonly List<Exercise> PlannedExercise = new List<Exercise>();

        public event EventHandler TrainingFinished; 

        public void ClearPlannedList()
        {
            PlannedExercise.Clear();
        }

        public void AddToPlanned(Exercise exercise)
        {
            PlannedExercise.Add(exercise);
        }

        public bool Start()
        {
            if (PlannedExercise.Count == 0)
                return false;
            StarTime = DateTime.Now;
            IsActive = true;
            return true;
        }

        //public bool TryAddSet(Exercise exercise, float weightDistance, int repeats = 0)
        //{
        //    if (IsActive && PlannedExercise.Contains(exercise))
        //    {
        //        _sets.Add(new DummySet());
        //        return true;
        //    }
        //    // TODO: Unseccess message
        //    return false;
        //}
        public bool TryAddSet(Set set)
        {
            //if (IsActive)
            //{
                _sets.Add(set);
                return true;
            //}
            // TODO: Unseccess message
            return false;
        }

        public void ComparePrevios(int index, Set.CompareTypes compare)
        {
            _sets[index].ComparePrevious(compare);
        }
        public Set Forecast(int index)
        {
            return _sets[index].Forecast(index);
        }
        public void Finish()
        {
            SavedTraining.Add(this, DateTime.Now);
            OnTrainingFinished();
            Reset();
        }

        public void Reset()
        {
            IsActive = false;
            ClearPlannedList();
            _sets.Clear();
        }

        public List<Set> GetSets()
        {
            return _sets;
        }

        protected virtual void OnTrainingFinished()
        {
            TrainingFinished?.Invoke(this, EventArgs.Empty);
        }

        public void SubscribeObserver(ICurrentTrainingObserver observer)
        {
            TrainingFinished += observer.OnTrainningFinished;
        }
        public void SetScheduleKeeper(IAutomaticSсheduleKeeper keeper)
        {
            keeper.TrainingStart += Keeper_TrainingStart;
        }

        public void Keeper_TrainingStart(object sender, EventArgs e)
        {
            SetAutomatic = true;
        }

        public bool SetAutomatic { get; set; }
    }
}
