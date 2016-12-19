using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GymNotes;
using GymNotes.Doubles;
using Rhino.Mocks;

namespace GymTest
{
    [TestFixture]
    public class AvatarTest
    {
        [Test] // Strict
        public void AvatartGetNormalRation()
        {

            IRationDao rationDao = MockRepository.GenerateStrictMock<IRationDao>();
            IBodyStructureDao bodyStructureDao = MockRepository.GenerateStrictMock<IBodyStructureDao>();

            var goal = Avatar.FitGoal.GrowMuscle;

            bodyStructureDao.Expect(body => body.BodyCorrespond(goal)).Return(true);
            rationDao.Expect(rat => rat.GetNormalRation(bodyStructureDao)).Return(new RationPlan());

            var avatar = new Avatar(rationDao, bodyStructureDao, goal);

            avatar.GetRationPlan();

            rationDao.VerifyAllExpectations();
            bodyStructureDao.VerifyAllExpectations();
        }
        [Test] // Strict
        public void AvatartGetAnyRation()
        {

            IRationDao rationDao = MockRepository.GenerateStrictMock<IRationDao>();
            IBodyStructureDao bodyStructureDao = MockRepository.GenerateStrictMock<IBodyStructureDao>();

            var goal = Avatar.FitGoal.GrowMuscle;

            bodyStructureDao.Expect(body => body.BodyCorrespond(goal)).Return(false);
            rationDao.Expect(rat => rat.GetRation(bodyStructureDao, goal)).Return(new RationPlan());

            var avatar = new Avatar(rationDao, bodyStructureDao, goal);

            avatar.GetRationPlan();

            rationDao.VerifyAllExpectations();
            bodyStructureDao.VerifyAllExpectations();
        }
        [Test] // Dynamic
        public void AvatartGetOptimal()
        {
            IRationDao rationDao = MockRepository.GenerateMock<IRationDao>();
            IBodyStructureDao bodyStructureDao = MockRepository.GenerateMock<IBodyStructureDao>();

            bodyStructureDao.Expect(body => body.BodyCorrespond(Arg<Avatar.FitGoal>.Is.Anything)).Return(false);
            bodyStructureDao.Expect(body => body.SuggestTrainingPlan(Arg<Avatar.FitGoal>.Is.Anything)).Return(new TrainingPlan());
            rationDao.Expect(rat => rat.GetRation(Arg<IBodyStructureDao>.Is.Anything, Arg<Avatar.FitGoal>.Is.Anything)).Return(new RationPlan());

            var avatar = new Avatar(rationDao, bodyStructureDao, Arg<Avatar.FitGoal>.Is.Anything);

            avatar.GetOptimalPlan();

            rationDao.VerifyAllExpectations();
            bodyStructureDao.VerifyAllExpectations();
        }
        [Test] // Dynamic
        public void AvatarCheckCorrection()
        {
            IRationDao rationDao = MockRepository.GenerateMock<IRationDao>();
            IBodyStructureDao bodyStructureDao = MockRepository.GenerateMock<IBodyStructureDao>();

            rationDao.Expect(rat => rat.CheckCorrection(Arg<IBodyStructureDao>.Is.Anything, Arg<Avatar.FitGoal>.Is.Anything)).Return(true);
            bodyStructureDao.Expect(body => body.CheckCorrection()).Return(true);

            var avatar = new Avatar(rationDao, bodyStructureDao, Arg<Avatar.FitGoal>.Is.Anything);

            avatar.CheckCorrection();

            rationDao.VerifyAllExpectations();
            bodyStructureDao.VerifyAllExpectations();
        }
        [Test] // Partial
        public void CompareSets()
        {
            FakeTrainingDbController.Load();
            CurrentTraining.Instance.Reset();
            Set set = MockRepository.GeneratePartialMock<Set>();
            float delta = 1;
            set.Exercise = new Exercise() {Name = "Squats"};

            CurrentTraining.Instance.TryAddSet(set);
            set.Expect(s => s.ComparePrevious(Set.CompareTypes.Progress)).Return(delta);

            CurrentTraining.Instance.ComparePrevios(0, Set.CompareTypes.Progress);
            
            set.VerifyAllExpectations();
        }
        [Test] // Partial
        public void ForecastSet()
        {
            FakeTrainingDbController.Load();
            CurrentTraining.Instance.Reset();
            Set set = MockRepository.GeneratePartialMock<Set>();
            set.Exercise = new Exercise() { Name = "Squats" };
            CurrentTraining.Instance.TryAddSet(set);
            set.Expect(s => s.Forecast(Arg<List<Set>>.Is.Anything)).Return(new Set());

            CurrentTraining.Instance.Forecast(0);

            set.VerifyAllExpectations();
        }
        [Test] // Old
        public void PostResult()
        {
            var mocks = new MockRepository();
            IServerProvider serverProvider = mocks.DynamicMock<IServerProvider>();
            var training = new SavedTraining();
            Expect.Call(serverProvider.Connect);
            Expect.Call(serverProvider.SendData(training));
            mocks.ReplayAll();


            var avatar = new Avatar(serverProvider);
            avatar.PostResult(training);

            mocks.VerifyAll();
        }
        [Test] // Old
        public void Synchronize()
        {
            var mocks = new MockRepository();
            IServerProvider serverProvider = mocks.DynamicMock<IServerProvider>();

            Expect.Call(serverProvider.Connect);
            Expect.Call(serverProvider.Synchronize);
            mocks.ReplayAll();

            var avatar = new Avatar(serverProvider);
            avatar.Synchronize();

            mocks.VerifyAll();
        }
        [Test] // Record/Playback
        public void Share()
        {
            var mocks = new MockRepository();
            IServerProvider serverProvider = mocks.DynamicMock<IServerProvider>();
            var exer = new Exercise();

            using (mocks.Record())
            {
                Expect.Call(serverProvider.Connect);
                Expect.Call(serverProvider.ShareExercise(exer));
            }

            using (mocks.Playback())
            {
                var avatar = new Avatar(serverProvider);
                avatar.ShareExercise(exer);
            }
        }

        [Test] // Record/Playback
        public void SignIn()
        {
            var mocks = new MockRepository();
            IServerProvider serverProvider = mocks.DynamicMock<IServerProvider>();
            var exer = new Exercise();
            var avatar = new Avatar(serverProvider);
            using (mocks.Record())
            {
                Expect.Call(serverProvider.Connect);
                Expect.Call(serverProvider.SignIn(avatar));
            }

            using (mocks.Playback())
            {
                avatar.SignIn();
            }
        }
    }
}
