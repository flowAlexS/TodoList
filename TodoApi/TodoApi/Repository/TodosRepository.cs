﻿using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Interfaces;
using TodoApi.Models;

namespace TodoApi.Repository
{
    public class TodosRepository : ITodosRepository
    {
        private readonly ApplicationDBContext _context;

        public TodosRepository(ApplicationDBContext context)
        => this._context = context;


        public async Task<List<TodoTask>> GetAllAsync(AppUser user)
        => await this._context.Tasks.Where(x => x.UserId.Equals(user.Id))
        .Select(task => new TodoTask()
        {
            Id = task.Id,
            Title = task.Title,
            Note = task.Note,
            Completed = task.Completed,
            User = task.User,
            UserId = task.UserId,
        }).ToListAsync();
    }
}