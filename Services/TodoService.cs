using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuTodo.Data;
using MeuTodo.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MeuTodo.Services
{
    public class TodoService : ITodoService
    {
        
        private  readonly MeuTodoContext _context;

        public TodoService(MeuTodoContext context)
        {
            _context = context;
        }

        public async Task<List<Todo>> FindAllTask()
        {
            return await _context.
                Todo.
                AsNoTracking().
                ToListAsync();
        }

        public async Task<Todo> FindById(int id)
        {
            // var todo = await _context.Todo.FindAsync(id);
            //
            // if (todo == null)
            // {
            //     throw new Exception();
            // }
            //
            return  await _context.Todo.FindAsync(id);
        }

        public async Task<Todo> UpdateTodo(Todo todo)
        {
            
            _context.Entry(todo).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(todo.Id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return todo;
        }

        public async Task<Todo> CreateTodo(Todo todo)
        {
            _context.Todo.Add(todo);
            await _context.SaveChangesAsync();

            return todo;
        }

        public async Task DeleteTodo(int id)
        {
            var todo = await _context.Todo.FindAsync(id);
            
            if (todo == null)
            {
                throw new NotImplementedException();
                // return NotFound();
            }
            
            _context.Todo.Remove(todo);
            
            await _context.SaveChangesAsync();
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.Id == id);
        }
    }
}