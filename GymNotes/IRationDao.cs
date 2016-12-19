using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes
{
    public interface IRationDao
    {
        RationPlan GetRation(IBodyStructureDao structure, Avatar.FitGoal goal);
        RationPlan GetNormalRation(IBodyStructureDao structure);
        bool CheckCorrection(IBodyStructureDao structure, Avatar.FitGoal goal);
    }
}
