namespace TodoApi
{
    public interface ITodoRepository
    {
        Task<Todo> GetByIdAsync(string id);
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> CreateAsync(Todo todo);
        Task UpdateAsync(string id, Todo todo);
        Task DeleteAsync(string id);
    }

}
