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
        public Game Game { get; set; }
        public int Points { get; set; }
        public DateTime ScoreDate { get; set; }
    }
}
