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

        public IServerProvider ServerProvider;
        public FitGoal Goal;
        public TrainingPlan TrainingPlan = new TrainingPlan();
        public RationPlan RationPlan = new RationPlan();
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

        public void PostResult(SavedTraining training)
        {
            ServerProvider.Connect();
            ServerProvider.SendData(training);
        }
        public void ShareExercise(Exercise exercise)
        {
            ServerProvider.Connect();
            ServerProvider.ShareExercise(exercise);
        }
        public void Synchronize()
        {
            ServerProvider.Connect();
            ServerProvider.Synchronize();
        }
        public void SignIn()
        {
            ServerProvider.Connect();
            ServerProvider.SignIn(this);
        }
    }
}
