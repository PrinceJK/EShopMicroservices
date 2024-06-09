namespace TodoApi
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Todo> GetTodoByIdAsync(string id)
        {
            // Use repository method to get Todo item by ID
            return await _todoRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Todo>> GetAllTodosAsync()
        {
            // Use repository method to get all Todo items
            return await _todoRepository.GetAllAsync();
        }

        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            // Use repository method to create a new Todo item
            return await _todoRepository.CreateAsync(todo);
        }

        public async Task UpdateTodoAsync(string id, Todo todo)
        {
            // Ensure the ID in the Todo object matches the ID parameter
            if (todo.Id != id)
            {
                throw new ArgumentException("Todo ID mismatch");
            }

            // Use repository method to update the existing Todo item
            await _todoRepository.UpdateAsync(id, todo);
        }

        public async Task DeleteTodoAsync(string id)
        {
            // Use repository method to delete the Todo item by ID
            await _todoRepository.DeleteAsync(id);
        }
    }

    public interface ITodoService
    {
        Task<Todo> GetTodoByIdAsync(string id);
        Task<IEnumerable<Todo>> GetAllTodosAsync();
        Task<Todo> CreateTodoAsync(Todo todo);
        Task UpdateTodoAsync(string id, Todo todo);
        Task DeleteTodoAsync(string id);
    }

}
