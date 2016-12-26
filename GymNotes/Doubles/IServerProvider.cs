using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GymNotes.Doubles
{
    public interface IServerProvider
    {
        Task<bool> SendDataAsync(SavedTraining training);
        Task<Exercise> GetExerciseAsync(Guid id);
        Task<SynchronizationObject> SynchronizeAsync();
    }

    public class SynchronizationObject
    {

    }

    public class ServerProvider : IServerProvider
    {
        public IServerDBMock mock;

        public async Task<bool> SendDataAsync(SavedTraining training)
        {
            return await Task.Run(() =>
            {
                // Sending data
                Thread.Sleep(200);
                return true;
            });
        }

        public async Task<Exercise> GetExerciseAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                // GetingExercise
                Thread.Sleep(200);
                return mock.GetExercise(id);
            });
        }

        public async Task<SynchronizationObject> SynchronizeAsync()
        {
            return await Task.Run(() =>
            {
                // Synchronization
                Thread.Sleep(1000);
                return new SynchronizationObject();
            });
        }
    }

    public interface IServerDBMock
    {
        Exercise GetExercise(Guid id);
    }
}
