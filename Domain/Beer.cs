using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CQRSMediaTr.Domain
{
    public class Beer : Entity
    {
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand? Brand { get; private set; }

        public Beer(int brandId, string name) 
        {
            base.Name = name;
            BrandId = brandId;
        }

        public Beer()
        {
            //FOR EF PURPOSES
        }
    }
}
