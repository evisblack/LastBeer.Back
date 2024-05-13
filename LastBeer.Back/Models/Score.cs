using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LastBeer.Back.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("GameId")]
        public int GameId { get; set; }
        public int Points { get; set; }
        public DateTime ScoreDate { get; set; }

        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
