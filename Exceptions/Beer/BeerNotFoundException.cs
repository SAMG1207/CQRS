namespace CQRSMediaTr.Exceptions.Beer
{
    public class BeerNotFoundException : Exception
    {
        public BeerNotFoundException(int id) 
            :base($"The beer with id: {id} is not found"){ }
    }

    public class BeerAlreadyExistsInThisBrandException : Exception
    {
        public BeerAlreadyExistsInThisBrandException(string beerName)
            :base($"This beer brand already has a beer with this name: {beerName}") { }
    }
}
