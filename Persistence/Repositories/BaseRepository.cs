using Application.Repositories;
using Domain.Common;
using Domain.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Logging;
using SharedLibrary.Utilities;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly CosmosContext Context;
        protected readonly Container Container;
        protected readonly ILogger Logger;
        

        public BaseRepository(CosmosContext context, string container, string partitionKey, ILogger logger)
        {
            Context = context;
            Logger = logger;
            Container = context.GetContainer(container, partitionKey).Result;

        }

        public async Task<T> Create(T entity)
        {
            Logger.LogInformation("Creating entity with Id {entity} in {container}", entity.Id, Container.Id);
            var created = await Container.CreateItemAsync(entity);
            return created.Resource;
        }

        public async Task<T> Update(T entity)
        {
            Logger.LogInformation("Updating entity with Id {entity} in {container}", entity.Id, Container.Id);
            var updated = await Container.UpsertItemAsync(entity);
            return updated.Resource;
        }

        public async Task Delete(T entity)
        {
            Logger.LogInformation("Flagging as deleted entity with Id {entity} in {container}", entity.Id, Container.Id);
            entity.DateDeleted = DateTime.UtcNow;
            await Update(entity);
        }

        public async Task<T> Get(Guid id, string partitionKey, CancellationToken cancellationToken)
        { 
            Logger.LogInformation("Getting id {id} with partition key {partitionKey} from container {container}", id.ToString(), partitionKey, Container.Id );
            return await Container.ReadItemAsync<T>(id.ToString(), new PartitionKey(partitionKey), null, cancellationToken);
        }

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Getting all entities in {container}", Container.Id);
            var iterator = Container.GetItemLinqQueryable<T>()
                .Where(i => i.DateDeleted == default)
                .ToFeedIterator();

            var items = new List<T>();
            while (iterator.HasMoreResults)
            {
                var results = await iterator.ReadNextAsync(cancellationToken);
                items.AddRange(results);
            }

            return items;
        }

        public async Task<List<T>> GetByFunction(Expression<Func<T, bool>> findFunc, CancellationToken cancellationToken)
        {
            Logger.LogInformation("Getting entities in {container} that match pattern {function}", Container.Id, findFunc.Body.ToString());

            var iterator = Container.GetItemLinqQueryable<T>()
                .Where(findFunc)
                .ToFeedIterator();
                

            var items = new List<T>();
            while (iterator.HasMoreResults)
            {
                var results = await iterator.ReadNextAsync(cancellationToken);
                items.AddRange(results);
            }

            return items;
        }

    }
}
