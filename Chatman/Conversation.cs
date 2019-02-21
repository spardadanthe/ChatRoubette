using System.Collections.Generic;

namespace Chatman
{
    public class Conversation
    {
        public List<User> UsersParticipating { get; set; }
        public List<Message>  History { get; set; }
}
}