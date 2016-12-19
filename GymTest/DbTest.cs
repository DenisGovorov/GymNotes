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
            Assert.Less(startCount, SavedTraining.GetTrainingHistory().Count);
        }
        [Test]  // Fake
        public void Insert()
        {
            var startCount = SavedTraining.GetTrainingHistory().Count;
            FakeTrainingDbController.Insert(new SavedTraining());
            Assert.AreEqual(startCount+1, SavedTraining.GetTrainingHistory().Count);
        }
        [Test]  // Fake
        public void Delete()
        {
            var startCount = SavedTraining.GetTrainingHistory().Count;
            FakeTrainingDbController.Delete(SavedTraining.GetTrainingHistory()[0].Id);
            Assert.AreEqual(startCount - 1, SavedTraining.GetTrainingHistory().Count);
        }
    }
}
