using Machine.Specifications;

namespace Chatman.Tests
{
    [Subject("Friendship")]
    public class When_comparing_two_friendships_with_same_Friends_with_Equal
    {

        Establish context = () =>
        {
            user1 = new User("Vanko");
            user2 = new User("Goshko");
            firstFriendship = new Friendship((UserId)user1.Id, (UserId)user2.Id);
            secondFriendship = new Friendship((UserId)user2.Id, (UserId)user1.Id);
            areEqual = false; 
        };

        Because of = () =>
        {
            areEqual = firstFriendship.Equals(secondFriendship);
        };

        It should_be_the_same = () => areEqual.ShouldBeTrue();

        public static bool areEqual;
        public static User user1;
        public static User user2;
        public static Friendship firstFriendship;
        public static Friendship secondFriendship;
    }
}