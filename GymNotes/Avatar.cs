using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public FitGoal Goal;
        public TrainingPlan TrainingPlan = new TrainingPlan();
        public RationPlan RationPlan = new RationPlan();
        public Avatar(IRationDao ration, IBodyStructureDao bodyStructure, FitGoal goal)
        {
            Ration = ration;
            BodyStructure = bodyStructure;
            Goal = goal;
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
    }
}
