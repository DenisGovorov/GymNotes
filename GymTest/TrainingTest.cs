﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GymNotes;
using GymNotes.Doubles;

namespace GymTest
{
    [TestFixture]
    public class TrainingTest
    {
        public void FillPlan()
        {

            CurrentTraining.Instance.AddToPlanned(new ExerciseSpy("Squats", ExerciseSpy.ExerciseType.Weighted,
                new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.UpperLeg, ExerciseSpy.MuscleGroup.Glutes }, String.Empty));
            CurrentTraining.Instance.AddToPlanned(new ExerciseSpy("Crunches", ExerciseSpy.ExerciseType.Unweigted,
                new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.Abs }, String.Empty));
        }

        [Test] // Dummy
        public void AddSet()
        {
            CurrentTraining.Instance.Reset();
            FillPlan();
            var plannedExercise = CurrentTraining.Instance.PlannedExercise[0];
            var newExercise = new ExerciseSpy("Crunches", ExerciseSpy.ExerciseType.Unweigted,
                new List<ExerciseSpy.MuscleGroup>() {ExerciseSpy.MuscleGroup.Abs}, String.Empty);
            var set = new DummySet();
            Assert.False(CurrentTraining.Instance.TryAddSet(set));
            Assert.True(CurrentTraining.Instance.Start());
            Assert.True(CurrentTraining.Instance.TryAddSet(set));
        }
        [Test] // Dummy
        public void Reset()
        {
            CurrentTraining.Instance.Reset();
            Assert.False(CurrentTraining.Instance.IsActive);
            Assert.AreEqual(CurrentTraining.Instance.PlannedExercise.Count, 0);
            Assert.AreEqual(CurrentTraining.Instance.GetSets().Count, 0);
            FillPlan();
            Assert.True(CurrentTraining.Instance.Start());
            
            var set = new DummySet();
            Assert.True(CurrentTraining.Instance.TryAddSet(set));

            Assert.True(CurrentTraining.Instance.IsActive);
            Assert.Less(0, CurrentTraining.Instance.PlannedExercise.Count);
            Assert.AreEqual(CurrentTraining.Instance.GetSets().Count, 1);

            CurrentTraining.Instance.Reset();
            Assert.False(CurrentTraining.Instance.IsActive);
            Assert.AreEqual(CurrentTraining.Instance.PlannedExercise.Count, 0);
            Assert.AreEqual(CurrentTraining.Instance.GetSets().Count, 0);
        }
        [Test] // Dummy
        public void Finish()
        {
            var startedCount = SavedTraining.GetTrainingHistory().Count;
            CurrentTraining.Instance.Reset();
            FillPlan();
            Assert.True(CurrentTraining.Instance.Start());
            var plannedExercise = CurrentTraining.Instance.PlannedExercise[0];
            var set = new DummySet();
            Assert.True(CurrentTraining.Instance.TryAddSet(set));
            Assert.AreEqual(SavedTraining.GetTrainingHistory().Count, startedCount);
            CurrentTraining.Instance.Finish();
            Assert.False(CurrentTraining.Instance.IsActive);
            Assert.AreEqual(CurrentTraining.Instance.PlannedExercise.Count, 0);
            Assert.AreEqual(CurrentTraining.Instance.GetSets().Count, 0);
            Assert.AreEqual(SavedTraining.GetTrainingHistory().Count, startedCount+1);
        }
        [Test] // Stub
        public void SaveCalories()
        {
            CurrentTraining.Instance.Reset();
            FillPlan();
            CurrentTraining.Instance.Start();
            var set = new DummySet();
            CurrentTraining.Instance.TryAddSet(set);
            CurrentTraining.Instance.Finish();
            var history = SavedTraining.GetTrainingHistory();
            var last = history[history.Count - 1];
            var startCallories = last.Calories;
            StubResult.CalculateCalories(last);

            Assert.Less(startCallories, last.Calories);
        }
        [Test] // Stub
        public void SaveAverge()
        {
            CurrentTraining.Instance.Reset();
            FillPlan();
            CurrentTraining.Instance.Start();
            var set = new DummySet();
            CurrentTraining.Instance.TryAddSet(set);
            CurrentTraining.Instance.Finish();
            var history = SavedTraining.GetTrainingHistory();
            var last = history[history.Count - 1];
            var startAverge = last.AvergeLoad;
            StubResult.AvergeLoad(last);

            Assert.Less(startAverge, last.AvergeLoad);
        }
        [Test] // Stub
        public void SaveProgress()
        {
            CurrentTraining.Instance.Reset();
            FillPlan();
            CurrentTraining.Instance.Start();
            var set = new DummySet();
            CurrentTraining.Instance.TryAddSet(set);
            CurrentTraining.Instance.Finish();
            var history = SavedTraining.GetTrainingHistory();
            var last = history[history.Count - 1];
            var startDelta = last.ProgressDelta;
            StubResult.ProgressDelta(last);

            Assert.Less(startDelta, last.ProgressDelta);
        }
    }
}
