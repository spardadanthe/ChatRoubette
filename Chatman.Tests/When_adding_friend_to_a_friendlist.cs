//using Machine.Specifications;
//using Chatman;
//using Chatman.Persistence.EF;
//using System.Linq;

//namespace Chatman.Tests
//{
//    [Subject("User")]
//    public class When_adding_friend_to_a_friendlist
//    {

//        Establish context = () =>
//        {
//            ChatmanContext  = new ChatmanContext().Users;

//            var user = context.Users.AsQueryable().FirstOrDefault(x => x.Username == "Vanko");
//        };

//        Because of = () =>
//        {

//        };

//        It should_add_user_to_the_database = () => true.ShouldBeTrue();





//    }
//}
