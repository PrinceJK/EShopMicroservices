using Microsoft.Azure.Cosmos;

namespace TodoApi
{
    public class CosmosDbTodoRepository : ITodoRepository
    {
        private readonly Container _container;

        public CosmosDbTodoRepository(CosmosClient cosmosClient)
        {
            _container = cosmosClient.GetContainer("databaseId", "containerId");
        }

        public async Task<QuestionDto> CreateAsync(QuestionDto questionDto)
        {
            // Use Cosmos DB SDK to create the question document
            try
            {
                ItemResponse<QuestionDto> response = await _container.CreateItemAsync(questionDto, new PartitionKey(questionDto.Id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                // Handle conflict (e.g., todo with the same ID already exists)
                return null;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw ex;
            }
        }

        public async Task<QuestionDto> UpdateAsync(string id, QuestionDto questionDto)
        {
            // Use Cosmos DB SDK to update the question document
        }

        public async Task<Todo> CreateAsync(Todo todo)
        {
            try
            {
                ItemResponse<Todo> response = await _container.CreateItemAsync(todo, new PartitionKey(todo.Id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
                // Handle conflict (e.g., todo with the same ID already exists)
                return null;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw ex;
            }
        }

        public async Task DeleteAsync(string id)
        {
            try
            {
                await _container.DeleteItemAsync<Todo>(id, new PartitionKey(id));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Handle not found (e.g., todo with the specified ID does not exist)
                throw new KeyNotFoundException($"Todo item with id: {id} not found");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw ex;
            }
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            var query = new QueryDefinition("SELECT * FROM c");
            List<Todo> todos = new List<Todo>();

            using (FeedIterator<Todo> resultSetIterator = _container.GetItemQueryIterator<Todo>(query))
            {
                while (resultSetIterator.HasMoreResults)
                {
                    FeedResponse<Todo> response = await resultSetIterator.ReadNextAsync();
                    todos.AddRange(response.ToList());
                }
            }

            return todos;
        }

        public async Task<Todo> GetByIdAsync(string id)
        {
            try
            {
                ItemResponse<Todo> response = await _container.ReadItemAsync<Todo>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Handle not found (e.g., todo with the specified ID does not exist)
                return null;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw ex;
            }
        }

        public async Task UpdateAsync(string id, Todo todo)
        {
            try
            {
                await _container.ReplaceItemAsync(todo, id, new PartitionKey(id));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Handle not found (e.g., todo with the specified ID does not exist)
                throw new KeyNotFoundException($"Todo item with id: {id} not found");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                throw ex;
            }
        }
    }


}
