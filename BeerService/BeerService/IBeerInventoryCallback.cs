using System.ServiceModel;

namespace Spd.Runtime
{
    public interface IBeerInventoryCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyJoinParty(string guestName);

        [OperationContract(IsOneWay = true)]
        void NotifyBeerChanged(string guestName,int numberofBeers);



        [OperationContract(IsOneWay = true)]
        void NotifyLeaveParty(string guestName);
    
    }
}