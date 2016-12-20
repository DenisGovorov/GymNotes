using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Doubles
{
    public interface ICurrentTrainingObserver
    {
        void OnTrainningFinished(object o, EventArgs args);
    }
    public class SystemNotifier : ICurrentTrainingObserver
    {
        public void OnTrainningFinished(object o, EventArgs args)
        {
            SendNotification();
        }

        protected virtual void SendNotification()
        {

        }
    }
    public interface IAutomaticSсheduleKeeper
    {
        event EventHandler TrainingStart;
    }
}
