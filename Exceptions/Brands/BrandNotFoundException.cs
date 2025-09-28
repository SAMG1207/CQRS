namespace CQRSMediaTr.Exceptions.Brands
{
    public class BrandNotFoundException : Exception
    {
        public BrandNotFoundException(int id)
            :base($"The brand with id: {id} is not found"){ }
    }
    
    public class BrandAlreadyExistsException : Exception
    {
        public BrandAlreadyExistsException(string name)
            :base($"There is already a brand with the name {name} in the database") { }
    }
}
