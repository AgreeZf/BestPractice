namespace WPFBeerClient
{
    public class WPFBeerClient:BeerInventory.BeerInventoryServiceCallback
    {
        private BeerInventory.BeerInventoryServiceClient client;

        public void NotifyJoinParty(string guestName)
        {
            
        }

        public void NotifyBeerChanged(string guestName, int numberofBeers)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyLeaveParty(string guestName)
        {
            throw new System.NotImplementedException();
        }
    }
}