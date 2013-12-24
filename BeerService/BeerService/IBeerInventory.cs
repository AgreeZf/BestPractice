using System.ServiceModel;

namespace Spd.Runtime
{
    [ServiceContract(CallbackContract = typeof(IBeerInventoryCallback),Name = "BeerInventoryService",Namespace = "http://www.zfogde.com/wcf/BeerInventoryService",SessionMode = SessionMode.Required)]
    public interface IBeerInventory
    {
        [OperationContract(Name = "JoinParty")]
        int JoinParty(string name);

        [OperationContract(Name = "MakeBeerRun")]
        void MakeBeerRun(string guestName, int numberofBeers);

        [OperationContract(Name = "DrinkBeer")]
        void DrinkBeer(string guestName);

        [OperationContract(Name = "LeaveParty")]
        void LeaveParty(string guestName);
    }
}