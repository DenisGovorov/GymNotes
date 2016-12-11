using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNotes;

namespace Test
{
    [TestFixture]
    public class ExerciseTest
    {
        //[SetUp]
        //public void AddExercise()
        //{

        //}
        [Test]
        public void TestMethod()
        {
            Exercise.TryAddExcercise("Squats", Exercise.ExerciseType.Weighted, new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.UpperLeg, Exercise.MuscleGroup.Glutes });
            Exercise.TryAddExcercise("Crunches", Exercise.ExerciseType.Unweigted, new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Abs });

            var exerciseCount = Exercise.GetCount();
            var list = Exercise.SelectByGroup(new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.UpperLeg });
            Assert.AreEqual(exerciseCount, Exercise.GetCount(), 0, "Exercise Items count changed");
        }
        [Test]
        public void AddExercise()
        {
            Assert.DoesNotThrow(() => { Exercise.TryAddExcercise("Crunches", Exercise.ExerciseType.Unweigted, new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Abs }); }, "Does not throw");
        }
    }
}
