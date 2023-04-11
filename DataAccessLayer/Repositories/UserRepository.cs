﻿using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Interfaces;
using EntityLayer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextDb _contextDb;

        public UserRepository(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _contextDb.Users.ToList();
        }


        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _contextDb.Users.ToListAsync();

        }
        public void Add(User user)
        {
            _contextDb.Users.Add(user);
            _contextDb.SaveChanges();
        }

        //admin paneli metodlar
        public async Task<User?> GetAsync(int id)
        {
            return await _contextDb.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User?> AddAsync(User user)
        {
            await _contextDb.AddAsync(user);
            await _contextDb.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var existingUser = await _contextDb.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.Password = user.Password;
                existingUser.Username = user.Username;
                existingUser.IsAdmin = user.IsAdmin;

                await _contextDb.SaveChangesAsync();
                return existingUser;

            }
            return null;
        }

        public bool IsAdmin(int userId)
        {
            return _contextDb.Users.FirstOrDefault(x => x.Id == userId).IsAdmin;
        }

        public User GetUserById(int id)
        {
           return _contextDb.Users.FirstOrDefault(y => y.Id == id);
        }
    }
}
