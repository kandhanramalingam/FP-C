using System.ComponentModel.DataAnnotations.Schema;

namespace FP_C.API.Models.DataEntities
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
