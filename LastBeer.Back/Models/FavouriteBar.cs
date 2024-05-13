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
        public Bar Bar { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        //public List<Bar> Favorites { get; set; } = new List<Bar>();
    }
}
