using PearlsOfWisdom.Application.Common.Mappings;
using PearlsOfWisdom.Domain.Entities;
using System.Collections.Generic;

namespace PearlsOfWisdom.Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
}
