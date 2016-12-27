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
    public class StaticTest
    {
        [Test] 
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
        [Test] 
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
        [Test] 
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
    }
}