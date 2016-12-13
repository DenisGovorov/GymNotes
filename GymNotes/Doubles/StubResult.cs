using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Doubles
{
    public class StubResult
    {
        public static void CalculateCalories(SavedTraining training)
        {
            // place calculations here
            training.Calories = 10;
        }
        public static void AvergeLoad(SavedTraining training)
        {
            // place calculations here
            training.AvergeLoad = 10;
        }
        public static void ProgressDelta(SavedTraining training)
        {
            // place calculations here
            training.ProgressDelta = 10;
        }
    }
}
