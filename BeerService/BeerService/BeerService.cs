using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Configuration;
namespace Spd.Runtime
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single,InstanceContextMode = InstanceContextMode.PerCall)]
    public class BeerService:IBeerInventory
    {
        private static List<IBeerInventoryCallback> _callbacks=new List<IBeerInventoryCallback>();
        private static int _beerInventory = Convert.ToInt32(ConfigurationManager.AppSettings["InitialBeerInventory"]);
        public int JoinParty(string name)
        {
            var guest = OperationContext.Current.GetCallbackChannel<IBeerInventoryCallback>();
            if (!_callbacks.Contains(guest))
            {
                _callbacks.Add(guest);
                _callbacks.ForEach(o=>o.NotifyJoinParty(name));
            }
            return _beerInventory;
        }

        public void MakeBeerRun(string guestName, int numberofBeers)
        {
            _beerInventory += numberofBeers;
            _callbacks.ForEach(o=>o.NotifyBeerChanged(guestName,numberofBeers));

        }

        public void DrinkBeer(string guestName)
        {
            _beerInventory--;
            _callbacks.ForEach(o=>o.NotifyBeerChanged(guestName,-1));
        }

        public void LeaveParty(string guestName)
        {
            var guest = OperationContext.Current.GetCallbackChannel<IBeerInventoryCallback>();
            if (_callbacks.Contains(guest))
            {
                _callbacks.Remove(guest);
                _callbacks.ForEach(o => o.NotifyLeaveParty(guestName));
            }

        }
    }
}