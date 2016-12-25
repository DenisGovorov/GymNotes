using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymNotes;
using GymNotes.Doubles;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;

namespace GymTest
{
    [TestFixture]
    public class EventTest
    {
        //[Test]
        //public void EventInvoke()
        //{
        //    var mocks = new MockRepository();
        //    var keeper = mocks.DynamicMock<IAutomaticSсheduleKeeper>();
        //    keeper.TrainingStart += null;
        //    IEventRaiser raiser = LastCall.GetEventRaiser();

        //    mocks.ReplayAll();
        //    CurrentTraining.Instance.SetScheduleKeeper(keeper);
        //    raiser.Raise(keeper, EventArgs.Empty);

        //    Assert.IsTrue(CurrentTraining.Instance.SetAutomatic);
        //}

        //[Test]
        //public void EventSubscibe()
        //{
        //    var notifier = MockRepository.GenerateMock<SystemNotifier>();
        //    notifier.Expect(not => not.OnTrainningFinished(CurrentTraining.Instance, EventArgs.Empty));

        //    CurrentTraining.Instance.SubscribeObserver(notifier);
        //    CurrentTraining.Instance.Finish();

        //    notifier.VerifyAllExpectations();
        //}

        //[Test]
        //public void EventParamObjectEventSubscibe()
        //{
        //    var keeper = MockRepository.GenerateMock<IAutomaticSсheduleKeeper>();

        //    CurrentTraining.Instance.SetScheduleKeeper(keeper);
        //    keeper.AssertWasCalled(k => k.TrainingStart += CurrentTraining.Instance.Keeper_TrainingStart);
        //}
    }
}
