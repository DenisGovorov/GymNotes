using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes
{
    public interface IBodyStructureDao
    {
        bool BodyCorrespond(Avatar.FitGoal goal);
        TrainingPlan SuggestTrainingPlan(Avatar.FitGoal goal);
        bool CheckCorrection();
    }
}
