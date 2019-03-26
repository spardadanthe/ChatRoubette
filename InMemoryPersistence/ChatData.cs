using Chatman;
using System;
using System.Collections.Generic;
using System.Text;

namespace InMemoryPersistence
{
    public static class ChatData
    {
        public static ICollection<User> Users = new HashSet<User>();
        public static ICollection<Conversation> Conversations = new HashSet<Conversation>();
    }
}
