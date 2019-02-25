using System.Collections.Generic;

namespace Chatman
{
    public class Conversation
    {
        public Conversation()
        {
            UsersParticipating = new List<User>();
            History = new List<Message>();
        }
        public List<User> UsersParticipating { get; set; }
        public List<Message>  History { get; set; }
}
}