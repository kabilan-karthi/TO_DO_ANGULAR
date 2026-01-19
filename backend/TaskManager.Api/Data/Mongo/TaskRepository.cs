using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TaskManager.Api.Configuration;
using TaskManager.Api.Data.Interfaces;
using TaskManager.Api.Models;

namespace TaskManager.Api.Data.Mongo
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMongoCollection<TaskItem> _tasksCollection;

        public TaskRepository(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _tasksCollection = database.GetCollection<TaskItem>(
                settings.Value.TasksCollectionName);
        }

        public IEnumerable<TaskItem> GetAll()
        {
            return _tasksCollection.Find(_ => true).ToList();
        }

        public TaskItem Create(TaskItem task)
        {
            _tasksCollection.InsertOne(task);
            return task;
        }

        public TaskItem? GetById(int id)
        {
            return _tasksCollection.Find(t => t.Id == id).FirstOrDefault();
        }

        public void Update(TaskItem task)
        {
            _tasksCollection.ReplaceOne(t => t.Id == task.Id, task);
        }

       public bool Delete(int id)
{
    var result = _tasksCollection.DeleteOne(t => t.Id == id);
    return result.DeletedCount > 0;
}


    }
}
