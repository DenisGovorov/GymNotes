using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Doubles
{
    public interface IServerProvider
    {
        void Connect();
        Action SendData(SavedTraining training);
        Action ShareExercise(Exercise exercise);
        void Synchronize();
        Action SignIn(Avatar avatar);
    }
}
