using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GymNotes;

namespace GymTest
{
    [TestFixture]
    public class TrainingTest
    {
        public void FillPlan()
        {

            CurrentTraining.Instance.AddToPlanned(new Exercise("Squats", Exercise.ExerciseType.Weighted,
                new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.UpperLeg, Exercise.MuscleGroup.Glutes }, String.Empty));
            CurrentTraining.Instance.AddToPlanned(new Exercise("Crunches", Exercise.ExerciseType.Unweigted,
                new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Abs }, String.Empty));
        }

        [Test]
        public void Start()
        {
            CurrentTraining.Instance.Reset();
            Assert.False(CurrentTraining.Instance.Start());
            Assert.False(CurrentTraining.Instance.IsActive);
            FillPlan();
            Assert.True(CurrentTraining.Instance.Start());
            Assert.True(CurrentTraining.Instance.IsActive);
            Assert.LessOrEqual(CurrentTraining.Instance.StarTime, DateTime.Now);
        }

        [Test]
        public void AddSet()
        {
            CurrentTraining.Instance.Reset();
            FillPlan();
            var plannedExercise = CurrentTraining.Instance.PlannedExercise[0];
            var newExercise = new Exercise("Crunches", Exercise.ExerciseType.Unweigted,
                new List<Exercise.MuscleGroup>() {Exercise.MuscleGroup.Abs}, String.Empty);
            Assert.False(CurrentTraining.Instance.TryAddSet(plannedExercise, 10, 10));
            Assert.False(CurrentTraining.Instance.TryAddSet(newExercise, 10, 10));
            Assert.True(CurrentTraining.Instance.Start());
            Assert.True(CurrentTraining.Instance.TryAddSet(plannedExercise, 10, 10));
            Assert.False(CurrentTraining.Instance.TryAddSet(newExercise, 10, 10));
        }
        [Test]
        public void Reset()
        {
            CurrentTraining.Instance.Reset();
            Assert.False(CurrentTraining.Instance.IsActive);
            Assert.AreEqual(CurrentTraining.Instance.PlannedExercise.Count, 0);
            Assert.AreEqual(CurrentTraining.Instance.GetSets().Count, 0);
            FillPlan();
            Assert.True(CurrentTraining.Instance.Start());

            var plannedExercise = CurrentTraining.Instance.PlannedExercise[0];
            Assert.True(CurrentTraining.Instance.TryAddSet(plannedExercise, 10, 10));

            Assert.True(CurrentTraining.Instance.IsActive);
            Assert.Less(0, CurrentTraining.Instance.PlannedExercise.Count);
            Assert.AreEqual(CurrentTraining.Instance.GetSets().Count, 1);

            CurrentTraining.Instance.Reset();
            Assert.False(CurrentTraining.Instance.IsActive);
            Assert.AreEqual(CurrentTraining.Instance.PlannedExercise.Count, 0);
            Assert.AreEqual(CurrentTraining.Instance.GetSets().Count, 0);
        }
        [Test]
        public void Finish()
        {
            CurrentTraining.Instance.Reset();
            FillPlan();
            Assert.True(CurrentTraining.Instance.Start());
            var plannedExercise = CurrentTraining.Instance.PlannedExercise[0];
            Assert.True(CurrentTraining.Instance.TryAddSet(plannedExercise, 10, 10));
            Assert.AreEqual(SavedTraining.GetTrainingHistory().Count, 0);
            Finish();
            Assert.False(CurrentTraining.Instance.IsActive);
            Assert.AreEqual(CurrentTraining.Instance.PlannedExercise.Count, 0);
            Assert.AreEqual(CurrentTraining.Instance.GetSets().Count, 0);
            Assert.AreEqual(SavedTraining.GetTrainingHistory().Count, 1);
        }
    }
}
