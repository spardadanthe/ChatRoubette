using Machine.Specifications;
using System;

namespace Chatman.Tests
{
    [Subject("Conversation")]
    public class When_adding_an_invalid_message_to_conversation
    {
        Establish context = () =>
        {
            user = new User("vanko");
            //conv = new Conversation();
        };

        Because of = () => exception = Catch.Exception(() => conv.AddMessage(mess));

        It Should_raise_an_null_argument_exception = () => exception.ShouldNotBeNull(); 

        static Conversation conv;
        static User user;
        static Message mess;
        static Exception exception;
    }
}
