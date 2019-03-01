using Machine.Specifications;
using System;

namespace Chatman.Tests
{
    [Subject("User")]
    public class When_adding_friend_to_invalid_user
    {
        Establish context = () =>
        {
            mainUser = null;
            friend = new User("Gosho");
        };

        Because of = () => exception = Catch.Exception(() => mainUser.AddFriend(friend));

        It should_raise_an_exception = () => exception.ShouldNotBeNull();

        public static User mainUser;
        public static User friend;
        private static Exception exception;
    }
}
