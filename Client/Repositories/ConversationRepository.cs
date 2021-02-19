using Chatman;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Client.Repositories
{
    public class ConversationRepository
    {
        public bool Add(HashSet<UserId> userIds)
        {
            using (var client = new HttpClient())
            {
                Conversation conv = new Conversation(userIds);
                HttpResponseMessage response = client.PostAsJsonAsync("https://localhost:44385/api/Conversations", conv).Result;
                if (response.IsSuccessStatusCode) return true;
                return false;
            }

        }

        public User Get()
        {
            throw new NotImplementedException();
        }
    }
}
