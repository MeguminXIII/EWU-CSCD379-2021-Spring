﻿using System;
using System.Collections.Generic;

namespace SecretSanta.Data
{
    public class Assignment
    {
        public User Giver { get; private set; }
        public User Receiver { get; private set; }
        public int Id { get; set; }
        public Group group { get; set; }

        private Assignment() { throw new NotSupportedException(nameof(Assignment)+"()"); }

        public Assignment(User giver, User receiver)
        {
            Giver = giver ?? throw new ArgumentNullException(nameof(giver));
            Receiver = receiver ?? throw new ArgumentNullException(nameof(receiver));
        }
    }
}
