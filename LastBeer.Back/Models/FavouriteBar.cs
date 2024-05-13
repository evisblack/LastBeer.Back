using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models
{
    public class FavouriteBar
    {
        [Key]
        public int Id { get; set; }
        public bool IsFavourite { get; set; }
        [ForeignKey("BarId")]
        public int BarId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Bar Bar { get; set; }
    }
}
