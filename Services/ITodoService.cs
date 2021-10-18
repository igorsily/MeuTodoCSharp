using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuTodo.Models;

namespace MeuTodo.Services
{
    public interface ITodoService
    {
       Task<List<Todo>> FindAllTask();

       Task<Todo> FindById(int id);

       Task<Todo> UpdateTodo(Todo todo);

       Task<Todo> CreateTodo(Todo todo);

       Task DeleteTodo(int id);
    }
}