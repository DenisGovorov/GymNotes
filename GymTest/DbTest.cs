using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNotes;
using GymNotes.Doubles;
using NUnit.Framework;
using Rhino.Mocks;

namespace GymTest
{
    [TestFixture]
    public class DbTest
    {
        //[Test] 
        //public void FakeAdd()
        //{
        //    var db = new FakeTrainingDbController();
        //    var manager = new TrainingManager(db);
        //    var training = new SavedTraining() ;
        //    var id = training.Id;

        //    var firstRequest = manager.GetTraining(id);
        //    manager.AddTraining(training);
        //    var secondRequest = manager.GetTraining(id);
            
        //    Assert.IsNull(firstRequest);
        //    Assert.IsNotNull(secondRequest);
        //    Assert.AreSame(training, secondRequest);
        //}
        //[Test]
        //public void FakeRemove()
        //{
        //    var db = new FakeTrainingDbController();
        //    var manager = new TrainingManager(db);
        //    var training = new SavedTraining();
        //    var id = training.Id;
            
        //    manager.AddTraining(training);
        //    var firstRequest = manager.GetTraining(id);
        //    manager.RemoveTraining(id);
        //    var secondRequest = manager.GetTraining(id);
            
        //    Assert.IsNotNull(firstRequest);
        //    Assert.IsNull(secondRequest);
        //}
        //[Test]
        //public void FakeSave()
        //{
        //    var db = new FakeTrainingDbController();
        //    var manager = new TrainingManager(db);
        //    var propertyValue = 10f;
        //    var newPropertyValue = 20f;
        //    var training = new SavedTraining() {Calories = propertyValue};
        //    var id = training.Id;
            
        //    manager.AddTraining(training);
        //    var firstRequest = manager.GetTraining(id);
        //    firstRequest.Calories = newPropertyValue;
        //    manager.SaveTraining(firstRequest);
        //    var secondRequest = manager.GetTraining(id);

        //    Assert.AreSame(training, firstRequest);
        //    Assert.AreSame(training, secondRequest);
        //    Assert.AreNotEqual(training.Calories, propertyValue);
        //    Assert.AreEqual(training.Calories, newPropertyValue);
        //}

        //[Test] // Mock
        //public void MockAdd()
        //{
        //    var db = MockRepository.GenerateStrictMock<ITrainingDb>();
        //    var manager = new TrainingManager(db);
        //    var training = new SavedTraining();
        //    var id = training.Id;

        //    db.Expect(b => b.Select(id)).Return(null);
        //    db.Expect(b => b.Insert(training)).Return(true);
        //    db.Expect(b => b.Select(id)).Return(training);

        //    var firstRequest = manager.GetTraining(id);
        //    manager.AddTraining(training);
        //    var secondRequest = manager.GetTraining(id);

        //    Assert.IsNull(firstRequest);
        //    Assert.IsNotNull(secondRequest);
        //    Assert.AreSame(training, secondRequest);

        //    db.VerifyAllExpectations();
        //}
        //[Test] // Mock
        //public void MockRemove()
        //{
        //    var db = MockRepository.GenerateStrictMock<ITrainingDb>();
        //    var manager = new TrainingManager(db);
        //    var training = new SavedTraining();
        //    var id = training.Id;

        //    db.Expect(b => b.Insert(training)).Return(true);
        //    db.Expect(b => b.Select(id)).Return(training);
        //    db.Expect(b => b.Delete(id)).Return(true);
        //    db.Expect(b => b.Select(id)).Return(null);

        //    manager.AddTraining(training);
        //    var firstRequest = manager.GetTraining(id);
        //    manager.RemoveTraining(id);
        //    var secondRequest = manager.GetTraining(id);

        //    Assert.IsNotNull(firstRequest);
        //    Assert.IsNull(secondRequest);

        //    db.VerifyAllExpectations();
        //}
        //[Test]
        //public void MockSave()
        //{
        //    var db = MockRepository.GenerateStrictMock<ITrainingDb>();
        //    var manager = new TrainingManager(db);
        //    var propertyValue = 10f;
        //    var newPropertyValue = 20f;
        //    var training = new SavedTraining() { Calories = propertyValue };
        //    var id = training.Id;

        //    db.Expect(b => b.Insert(training)).Return(true);
        //    db.Expect(b => b.Select(id)).Return(training);
        //    db.Expect(b => b.Save(training)).Return(true);
        //    db.Expect(b => b.Select(id)).Return(training);

        //    manager.AddTraining(training);
        //    var firstRequest = manager.GetTraining(id);
        //    firstRequest.Calories = newPropertyValue;
        //    manager.SaveTraining(firstRequest);
        //    var secondRequest = manager.GetTraining(id);

        //    Assert.AreSame(training, firstRequest);
        //    Assert.AreSame(training, secondRequest);
        //    Assert.AreNotEqual(training.Calories, propertyValue);
        //    Assert.AreEqual(training.Calories, newPropertyValue);

        //    db.VerifyAllExpectations();
        //}
    }
}
