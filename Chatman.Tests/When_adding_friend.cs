using Machine.Specifications;

namespace Chatman.Tests
{
    [Subject("User")]
    public class When_adding_friend
    {
        Establish context = () =>
        {
            mainUser = new User("Ivan");
            friend = new User("Gosho");
        };

        Because of = () =>
        {
            mainUser.AddFriend(friend);
        };

        It should_have_friend = () => mainUser.Friends.ShouldContain(friend);

        public static User mainUser;
        public static User friend;
    }
}
