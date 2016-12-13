using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNotes;
using GymNotes.Doubles;
using NUnit.Framework;

namespace GymTest
{
    [TestFixture]
    public class DbTest
    {
        [Test] // Fake
        public void Load()
        {
            SavedTraining.RemoveAll();
            var startCount = SavedTraining.GetTrainingHistory().Count;
            FakeTrainingDbController.Load();
            Assert.Less(startCount, SavedTraining.GetTrainingHistory().Count);
        }
        [Test]  // Fake
        public void Insert()
        {
            FakeTrainingDbController.Load();
            var startCount = SavedTraining.GetTrainingHistory().Count;
            FakeTrainingDbController.Insert(new SavedTraining());
            FakeTrainingDbController.Load();
            Assert.AreEqual(startCount+1, SavedTraining.GetTrainingHistory().Count);
        }
        [Test]  // Fake
        public void Delete()
        {
            FakeTrainingDbController.Load();
            var startCount = SavedTraining.GetTrainingHistory().Count;
            FakeTrainingDbController.Delete(SavedTraining.GetTrainingHistory()[0].Id);
            FakeTrainingDbController.Load();
            Assert.AreEqual(startCount - 1, SavedTraining.GetTrainingHistory().Count);
        }
    }
}
