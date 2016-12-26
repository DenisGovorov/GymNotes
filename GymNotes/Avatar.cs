using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNotes.Doubles;

namespace GymNotes
{
    public class Avatar
    {
        public enum FitGoal
        {
            Health, GrowMuscle, BurnFat
        }

        public IRationDao Ration;
        public IBodyStructureDao BodyStructure;

        public List<Exercise> ExerciseCollection = new List<Exercise>();
        public IServerProvider ServerProvider;
        public FitGoal Goal;
        public TrainingPlan TrainingPlan = new TrainingPlan();
        public RationPlan RationPlan = new RationPlan();

        public bool Synchronized { get; private set; }

        public Avatar(IRationDao ration, IBodyStructureDao bodyStructure, FitGoal goal)
        {
            Ration = ration;
            BodyStructure = bodyStructure;
            Goal = goal;
        }
        public Avatar(IServerProvider serverProvider)
        {
           ServerProvider = serverProvider;
        }
        public RationPlan GetRationPlan()
        {
            if (BodyStructure.BodyCorrespond(Goal))
            {
                return Ration.GetNormalRation(BodyStructure);
            }
            return Ration.GetRation(BodyStructure, Goal);
        }
        public void GetOptimalPlan()
        {
            TrainingPlan = BodyStructure.SuggestTrainingPlan(Goal);
            RationPlan = GetRationPlan();
        }
        public bool CheckCorrection()
        {
            return (BodyStructure.CheckCorrection() | Ration.CheckCorrection(BodyStructure, Goal));
        }

        public bool PostResult(SavedTraining training)
        {
            return ServerProvider.SendDataAsync(training).Result;
        }
        public void GetExercise(Guid id)
        {
            var exercise = ServerProvider.GetExerciseAsync(id).Result;
            if (exercise != null)
                ExerciseCollection.Add(exercise);
        }
        public void Synchronize()
        {
            var syncObject = ServerProvider.SynchronizeAsync().Result;
            Synchronize(syncObject);
        }
        private void Synchronize(SynchronizationObject syncObject)
        {
            Synchronized = true;
        }
    }
}
