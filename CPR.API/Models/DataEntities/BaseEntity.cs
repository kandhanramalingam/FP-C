using System.ComponentModel.DataAnnotations.Schema;

namespace CPR.API.Models.DataEntities
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
