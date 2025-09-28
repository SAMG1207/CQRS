namespace CQRSMediaTr.Domain
{
    public class Brand: Entity
    {        
        public List<Beer> Beers { get; set; } = [];

        public Brand()
        {
            //FOR EF PURPOSES
        }
        public Brand(string name)
        {
            Name = name;
        }
    }
}
