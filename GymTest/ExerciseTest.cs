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
        private static readonly List<ExerciseSpy> _default = new List<ExerciseSpy>()
        {
            new ExerciseSpy("Squats", ExerciseSpy.ExerciseType.Weighted,
                new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.UpperLeg, ExerciseSpy.MuscleGroup.Glutes }, String.Empty),
            new ExerciseSpy("Crunches", ExerciseSpy.ExerciseType.Unweigted,
                new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.Abs}, String.Empty)
        };

        [SetUp]
        public void SetDefault()
        {
            ExerciseSpy.ResetSpy();
            ExerciseSpy.RemoveAll();
            foreach (var exercise in _default)
            {
                ExerciseSpy.TryAddExcercise(exercise);
            }
        }

        [Test]
        public void AddExercise()
        {
            bool added = false;
            Assert.DoesNotThrow(() => { added = ExerciseSpy.TryAddExcercise("Pull Ups", ExerciseSpy.ExerciseType.Unweigted, 
                new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.Back }); }, "Does not throw");
            Assert.True(added);
            Assert.AreEqual(_default.Count + 1, ExerciseSpy.GetCount());
        }

        [Test] //Spy
        public void AddEmptyName()
        {
            ExerciseSpy.ResetSpy();
            ExerciseSpy.TryAddExcercise("", ExerciseSpy.ExerciseType.Unweigted, new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.Abs });
            var exercise = new ExerciseSpy("", ExerciseSpy.ExerciseType.Unweigted, new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.Abs }, String.Empty);
            ExerciseSpy.TryAddExcercise(exercise);
            Assert.AreEqual(ExerciseSpy.Calls.Count, 0);
        }
        [Test]
        public void AddExistingName()
        {
            string name = "Push Ups";
            var exercise1 = new ExerciseSpy(name, ExerciseSpy.ExerciseType.Unweigted, new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.Chest }, String.Empty);
            var exercise2 = new ExerciseSpy(name, ExerciseSpy.ExerciseType.Unweigted, new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.Chest }, String.Empty);
            ExerciseSpy.TryAddExcercise(exercise1);
            Assert.False(ExerciseSpy.TryAddExcercise(name, ExerciseSpy.ExerciseType.Unweigted,new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.Chest }));
            Assert.False(ExerciseSpy.TryAddExcercise(exercise2));
            var gottenExercise = ExerciseSpy.GetByName(name);
        }
        [Test]
        public void AddEmptyFields()
        {
            string name = "EmptyFields_test";
            Assert.True(ExerciseSpy.TryAddExcercise(name, 0, null));
            Assert.IsNotNull(ExerciseSpy.GetByName(name));
        }
        [Test]
        public void GroupExercise()
        {
            var exerciseCount = ExerciseSpy.GetCount();
            var list = ExerciseSpy.SelectByGroup(new List<ExerciseSpy.MuscleGroup>() { ExerciseSpy.MuscleGroup.UpperLeg });
            Assert.AreEqual(exerciseCount, ExerciseSpy.GetCount(), 0, "Exercise Items count changed");
            Assert.LessOrEqual(list.Count, ExerciseSpy.GetCount());
            Assert.True(list.Any(ex => String.Equals(ex.Name, "Squats")));
        }
        [Test]
        public void GetByName()
        {
            var existingName = _default[0].Name;
            var gottenExercise = ExerciseSpy.GetByName(existingName);
            Assert.IsNotNull(gottenExercise, "gottenExercise == null");
            Assert.AreSame(gottenExercise.Name, _default[0].Name);
        }
        [Test] // Spy
        public void EditName()
        {
            ExerciseSpy.ResetSpy();
            var oldName = _default[0].Name;
            var newName = "New Name";
            ExerciseSpy.GetByName(newName); 
            ExerciseSpy.GetByName(oldName); // 1
            ExerciseSpy.GetByName(oldName).TryEdit(newName); // 2
            ExerciseSpy.GetByName(oldName);
            ExerciseSpy.GetByName(newName); // 3

            Assert.AreEqual(ExerciseSpy.Calls.Count, 3);
        }
        [Test]
        public void EditExistingName()
        {
            var oldName = _default[0].Name;
            var newName = _default[1].Name;
            Assert.IsNotNull(ExerciseSpy.GetByName(newName));
            Assert.IsNotNull(ExerciseSpy.GetByName(oldName));
            Assert.False(ExerciseSpy.GetByName(oldName).TryEdit(newName));
            Assert.IsNotNull(ExerciseSpy.GetByName(oldName));
        }
        [Test]
        public void EditEmptyName()
        {
            var oldName = _default[0].Name;
            var newName = String.Empty;
            Assert.IsNotNull(ExerciseSpy.GetByName(oldName));
            Assert.False(ExerciseSpy.GetByName(oldName).TryEdit(newName));
            Assert.IsNotNull(ExerciseSpy.GetByName(oldName));
            Assert.IsNull(ExerciseSpy.GetByName(newName));
        }
        [Test]
        public void RemoveExisting()
        {
            ExerciseSpy.ResetSpy();
            var name = _default[0].Name;
            Assert.IsNotNull(ExerciseSpy.GetByName(name));
            Assert.True(ExerciseSpy.Remove(name));
            Assert.IsNull(ExerciseSpy.GetByName(name));
            
            Assert.IsNotNull(ExerciseSpy.GetByName(_default[1].Name));
            Assert.True(ExerciseSpy.Remove(_default[1].Name));
            Assert.IsNull(ExerciseSpy.GetByName(_default[1].Name));

            Assert.AreEqual(ExerciseSpy.Calls.Count(c => c.MethodName == "Remove"), 2);
        }
        [Test]
        public void RemoveAll()
        {
            Assert.Less(0, ExerciseSpy.GetCount());
            ExerciseSpy.RemoveAll();
            Assert.AreEqual(ExerciseSpy.GetCount(), 0);
        }
    }
}
