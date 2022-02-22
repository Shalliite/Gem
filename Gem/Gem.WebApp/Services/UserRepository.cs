﻿using Gem.WebApp.Migrations;

namespace Gem.WebApp.Services
{
    public class UserRepository
    {
        private readonly ApplicationDbContext dbc;
        public UserRepository(ApplicationDbContext adbc)
        {
            dbc = adbc;
        }
        public void Add(User user)
        {
            dbc.Users.Add(user);
            dbc.SaveChanges();
        }
    }
}