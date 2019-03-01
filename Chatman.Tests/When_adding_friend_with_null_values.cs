using Machine.Specifications;
using System;

namespace Chatman.Tests
{
    public class When_adding_friend_with_null_values
    {
        Establish context = () =>
        {
            mainUser = new User("Ivan");
        };

        Because of = () => exception = Catch.Exception(() => mainUser.AddFriend(null));

        It should_raise_an_exception = () => exception.ShouldNotBeNull();

        public static User mainUser;
        public static Exception exception;
    }
}
