using System;
using System.Collections.Generic;
using System.Text;

namespace Chatman
{
    //public class Api_AppService_Application
    //{
    //    private readonly DbContext context;

    //    public Api_AppService_Application(DbContext context)
    //    {
    //        this.context = context;
    //    }


    //    public void DoSomething(string asd)
    //    {
    //        var state = context.Load<BusinnessObjectState>();
    //        BusinessObject bo = new BusinessObject(state);
    //        bo.DoSomethingMeaningful(asd);
    //        context.Save(state);
    //    }
    //}

    //public class BusinessObject
    //{
    //    private readonly BusinnessObjectState state;

    //    public BusinessObject(BusinnessObjectState state)
    //    {
    //        this.state = state;
    //    }

    //    public void DoSomethingMeaningful(string asd)
    //    {
    //        state.GG = asd;
    //    }
    //}

    //public class BusinnessObjectState
    //{
    //    public UserId UserId { get; set; }

    //    public string GG { get; set; }

    //    []
    //    public int MyProperty { get; set; }
    //}

    public class Friendship : BaseEntity
    {
        public Friendship(UserId firstUserId, UserId secondUserId) : this(new FriendshipId(Guid.NewGuid().ToString()), firstUserId, secondUserId)
        { }

        public Friendship(FriendshipId id,UserId firstUserId, UserId secondUserId) : base(id)
        {
            if (firstUserId is null) throw new ArgumentNullException(nameof(firstUserId));
            if (secondUserId is null) throw new ArgumentNullException(nameof(secondUserId));
            if (firstUserId == secondUserId) throw new ArgumentException("A friendship can only exist if there are 2 different usersIds");

            FirstUserId = firstUserId;
            SecondUserId = secondUserId;
        }

        public UserId FirstUserId { get; private set; }
        public UserId SecondUserId { get; private set; }

        public static bool operator ==(Friendship f1,Friendship f2)
        {
            bool firstCondition = (f1.FirstUserId == f2.FirstUserId) && (f1.SecondUserId == f2.SecondUserId);
            bool secondCondition = (f1.FirstUserId == f2.SecondUserId) && (f1.SecondUserId == f2.FirstUserId);

            if (firstCondition == true || secondCondition == true)
                return true;

            return false;

        }

        public static bool operator !=(Friendship f1,Friendship f2)
        {
            bool firstCondition = (f1.FirstUserId == f2.FirstUserId) && (f1.SecondUserId == f2.SecondUserId);
            bool secondCondition = (f1.FirstUserId == f2.SecondUserId) && (f1.SecondUserId == f2.FirstUserId);

            if (firstCondition == false && secondCondition == false)
                return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            bool firstCondition = (FirstUserId == ((Friendship)obj).FirstUserId) && (SecondUserId == ((Friendship)obj).SecondUserId);
            bool secondCondition = (FirstUserId == ((Friendship)obj).SecondUserId) && (SecondUserId == ((Friendship)obj).FirstUserId);

            if (firstCondition == true || secondCondition == true)
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstUserId, SecondUserId);
        }
    }
}
