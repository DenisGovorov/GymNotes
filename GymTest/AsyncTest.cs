using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GymNotes;
using GymNotes.Doubles;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace GymTest
{
    [TestFixture]
    public class AsyncTest
    {
        [Test]
        [Timeout(80000)]
        public void PostResult()
        {
            var provider = new ServerProvider();
            var saved = new SavedTraining();
            var task = provider.SendDataAsync(saved);
            task.Wait();

            Assert.IsTrue(task.Result);
        }
        [Test]
        [Timeout(80000)]
        public void GetExercise()
        {
            var dbMock = MockRepository.GenerateStub<IServerDBMock>();
            var provider = new ServerProvider() { mock = dbMock };
            dbMock.Expect(m => m.GetExercise(Arg<Guid>.Is.Anything)).Return(new Exercise());
            var avatar = new Avatar(provider);
            int startCount = avatar.ExerciseCollection.Count;
            int expectedCount = startCount + 1;

            avatar.GetExercise(Guid.NewGuid());

            while (true)
            {
                if (avatar.ExerciseCollection.Count == expectedCount)
                    break;
                Thread.Sleep(200);
            }
            Assert.AreEqual(startCount, 0);
            Assert.AreEqual(avatar.ExerciseCollection.Count, 1);
        }
        [Test]
        [Timeout(80000)]
        public void Sync()
        {
            var provider = new ServerProvider();
            var avatar = new Avatar(provider);

            avatar.Synchronize();
            while (true)
            {
                if (avatar.Synchronized)
                    break;
                Thread.Sleep(200);
            }
            Assert.IsTrue(avatar.Synchronized);
        }
    }
}
