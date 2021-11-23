using System.ComponentModel.DataAnnotations.Schema;

namespace apiRest.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id {get; set;}
    }
}