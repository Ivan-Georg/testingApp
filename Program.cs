using System;
using Moq;
using System.Collections.Generic;

namespace testingApp
{
    // User class represents a model for storing information about a user.
    public class User
    {
        // Property to get or set the unique identifier of the user.
        public int UserId { get; set; }

        // Property to get or set the name of the user.
        public string UserName { get; set; }

        // Constructor for creating User objects with specified id and name.
        public User(int userId, string userName)
        {
            // Set the UserId and UserName properties based on the provided parameters.
            UserId = userId;
            UserName = userName;
        }
    }
}

