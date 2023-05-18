using Domain.Order.Config;
using Infrastructure.Context;
using Infrastructure.Model.ComplexMongo;

namespace MongoTransfer
{
    public class MgOrder
    {
        public StateEntity SendOrder(StateEntity stateEntity)
        {
            StateEntity result;
            using (var db = new StateContext())
            {
                db.State.Add(stateEntity);

                result = db.State.Last();
            }
            return result;
        }
    }
}