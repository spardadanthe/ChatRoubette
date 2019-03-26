using Machine.Specifications;
using Chatman;

namespace Chatman.Tests
{
    [Subject("User")]
    public class When_adding_friend_to_a_friendlist
    {
        
        Establish context = () =>
        {
            userThatAddsFriend = new User("userThatAddsFriend");
            userToBeAdded = new User("userToBeAdded");
        };

        Because of = () =>
        {
            userThatAddsFriend.AddFriend(userToBeAdded.Id);
        };

        It should_have_only_one_friend_in_friendlist = () => userThatAddsFriend.FriendIds.Count.ShouldEqual(1);
        It should_have_the_same_friend_in_friendlist = () => userThatAddsFriend.FriendIds.ShouldContain(userToBeAdded.Id);

        public static User userThatAddsFriend;
        public static User userToBeAdded;


    }
}
