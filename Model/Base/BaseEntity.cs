using System.ComponentModel.DataAnnotations.Schema;

namespace RESTApi.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id {get; set;}
    }
}