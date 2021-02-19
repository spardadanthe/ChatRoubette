using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman.Tests
{
        [Subject("Friendship")]
        public class When_comparing_two_friendships_with_same_friends_with_operator
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
                areEqual = firstFriendship == secondFriendship;
            };

            It should_be_true = () => areEqual.ShouldBeTrue();

            public static bool areEqual;
            public static User user1;
            public static User user2;
            public static Friendship firstFriendship;
            public static Friendship secondFriendship;
        
    }
}
