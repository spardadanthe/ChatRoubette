using Machine.Specifications;
using System.Collections.Generic;
using System.Text;

namespace Chatman.Tests
{
    [Subject("Conversation")]
    public class When_adding_message_to_conversation
    {
        Establish context = () =>
        {
            //conv = new Conversation();
            user = new User("vanko");
            mess = new Message(user, "test message", 1);
        };

        Because of = () => conv.AddMessage(mess);

        It should_containt_message_in_history = () => conv.History.ShouldContain(mess);

        static Conversation conv;
        static User user;
        static Message mess;
    }
}
