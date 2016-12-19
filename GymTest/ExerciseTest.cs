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
        private static readonly List<Exercise> _default = new List<Exercise>()
        {
            new Exercise("Squats", Exercise.ExerciseType.Weighted,
                new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.UpperLeg, Exercise.MuscleGroup.Glutes }, String.Empty),
            new Exercise("Crunches", Exercise.ExerciseType.Unweigted,
                new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Abs}, String.Empty)
        };

        [SetUp]
        public void SetDefault()
        {
            Exercise.RemoveAll();
            foreach (var exercise in _default)
            {
                Exercise.TryAddExcercise(exercise);
            }
        }

        [Test]
        public void AddExercise()
        {
            bool added = false;
            Assert.DoesNotThrow(() => { added = Exercise.TryAddExcercise("Pull Ups", Exercise.ExerciseType.Unweigted, 
                new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Back }); }, "Does not throw");
            Assert.True(added);
            Assert.AreEqual(_default.Count + 1, Exercise.GetCount());
        }

        [Test] //Spy
        public void AddEmptyName()
        {
            Exercise.TryAddExcercise("", Exercise.ExerciseType.Unweigted, new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Abs });
            var exercise = new Exercise("", Exercise.ExerciseType.Unweigted, new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Abs }, String.Empty);
            Exercise.TryAddExcercise(exercise);
        }
        [Test]
        public void AddExistingName()
        {
            string name = "Push Ups";
            var exercise1 = new Exercise(name, Exercise.ExerciseType.Unweigted, new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Chest }, String.Empty);
            var exercise2 = new Exercise(name, Exercise.ExerciseType.Unweigted, new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Chest }, String.Empty);
            Exercise.TryAddExcercise(exercise1);
            Assert.False(Exercise.TryAddExcercise(name, Exercise.ExerciseType.Unweigted,new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.Chest }));
            Assert.False(Exercise.TryAddExcercise(exercise2));
            var gottenExercise = Exercise.GetByName(name);
        }
        [Test]
        public void AddEmptyFields()
        {
            string name = "EmptyFields_test";
            Assert.True(Exercise.TryAddExcercise(name, 0, null));
            Assert.IsNotNull(Exercise.GetByName(name));
        }
        [Test]
        public void GroupExercise()
        {
            var exerciseCount = Exercise.GetCount();
            var list = Exercise.SelectByGroup(new List<Exercise.MuscleGroup>() { Exercise.MuscleGroup.UpperLeg });
            Assert.AreEqual(exerciseCount, Exercise.GetCount(), 0, "Exercise Items count changed");
            Assert.LessOrEqual(list.Count, Exercise.GetCount());
            Assert.True(list.Any(ex => String.Equals(ex.Name, "Squats")));
        }
        [Test]
        public void GetByName()
        {
            var existingName = _default[0].Name;
            var gottenExercise = Exercise.GetByName(existingName);
            Assert.IsNotNull(gottenExercise, "gottenExercise == null");
            Assert.AreSame(gottenExercise.Name, _default[0].Name);
        }
        [Test] // Spy
        public void EditName()
        {
            var oldName = _default[0].Name;
            var newName = "New Name";
            Exercise.GetByName(newName); 
            Exercise.GetByName(oldName); // 1
            Exercise.GetByName(oldName).TryEdit(newName); // 2
            Exercise.GetByName(oldName);
            Exercise.GetByName(newName); // 3
            
        }
        [Test]
        public void EditExistingName()
        {
            var oldName = _default[0].Name;
            var newName = _default[1].Name;
            Assert.IsNotNull(Exercise.GetByName(newName));
            Assert.IsNotNull(Exercise.GetByName(oldName));
            Assert.False(Exercise.GetByName(oldName).TryEdit(newName));
            Assert.IsNotNull(Exercise.GetByName(oldName));
        }
        [Test]
        public void EditEmptyName()
        {
            var oldName = _default[0].Name;
            var newName = String.Empty;
            Assert.IsNotNull(Exercise.GetByName(oldName));
            Assert.False(Exercise.GetByName(oldName).TryEdit(newName));
            Assert.IsNotNull(Exercise.GetByName(oldName));
            Assert.IsNull(Exercise.GetByName(newName));
        }
        [Test]
        public void RemoveExisting()
        {
            var name = _default[0].Name;
            Assert.IsNotNull(Exercise.GetByName(name));
            Assert.True(Exercise.Remove(name));
            Assert.IsNull(Exercise.GetByName(name));
            
            Assert.IsNotNull(Exercise.GetByName(_default[1].Name));
            Assert.True(Exercise.Remove(_default[1].Name));
            Assert.IsNull(Exercise.GetByName(_default[1].Name));
            
        }
        [Test]
        public void RemoveAll()
        {
            Assert.Less(0, Exercise.GetCount());
            Exercise.RemoveAll();
            Assert.AreEqual(Exercise.GetCount(), 0);
        }
    }
}
