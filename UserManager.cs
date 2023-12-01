using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testingApp
{
    // UserManager class represents a service for managing User objects in a database.
    public class UserManager
    {
        // Private field to store the reference to the database implementation.
        private readonly IDatabase _database;

        // Constructor that initializes the UserManager with a specific database implementation.
        public UserManager(IDatabase database)
        {
            _database = database;
        }

        // AddUser method adds a new User to the database.
        public void AddUser(User user)
        {
            _database.AddUser(user);
        }

        // RemoveUser method removes a User from the database based on the provided userId.
        // It first checks if the user exists in the database before attempting to remove.
        public void RemoveUser(int userId)
        {
            // Retrieve the user from the database based on userId.
            var userToRemove = _database.GetUser(userId);

            // Check if the user exists before attempting to remove.
            if (userToRemove != null)
            {
                _database.RemoveUser(userId);
            }
        }

        // GetUser method retrieves a User from the database based on the provided userId.
        public User GetUser(int userId)
        {
            return _database.GetUser(userId);
        }
    }
}
