using System;
using GymNotes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace UnitTestProject
{
    [Binding]
    public class FeatureStartSteps
    {
        [Given(@"I have added (.*) to training plan")]
        public void GivenIHaveAddedToTrainingPlan(string name)
        {
            CurrentTraining.Instance.PlannedExercise.Add(new Exercise() { Name = name });
        }
        
        [When(@"I press start")]
        public void WhenIPressStart()
        {
            CurrentTraining.Instance.Start();
        }
        
        [Then(@"Training starts setting now as start time")]
        public void ThenTrainingStartsSettingNowAsStartTime()
        {
            Assert.IsTrue(CurrentTraining.Instance.IsActive);
            Assert.IsTrue(CurrentTraining.Instance.StarTime < DateTime.Now);
        }

        [Given(@"My training is stopped and plan is empty")]
        public void MyTrainingIsStoppedPlanIsEmpty()
        {
            CurrentTraining.Instance.Reset();
            CurrentTraining.Instance.PlannedExercise.Clear();
        }

        [Then(@"Training is not started")]
        public void TrainingIsNotStarted()
        {
            Assert.IsFalse(CurrentTraining.Instance.IsActive);
        }

        [Given(@"My training had started")]
        public void GivenMyTrainingHadStarted()
        {
            MyTrainingIsStoppedPlanIsEmpty();
            CurrentTraining.Instance.PlannedExercise.Clear();
            GivenIHaveAddedToTrainingPlan("Squats");
            WhenIPressStart();
        }
        [When(@"I press finish")]
        public void WhenIPressFinish()
        {
            CurrentTraining.Instance.Finish();
        }
        [Then(@"I have my training saved")]
        public void ThenIHaveMyTrainingSaved()
        {
            Assert.AreEqual(SavedTraining.GetTrainingHistory().Count, 1);
        }

    }
}
