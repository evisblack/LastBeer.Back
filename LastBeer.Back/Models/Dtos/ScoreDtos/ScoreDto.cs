namespace LastBeer.Back.Models.Dtos.ScoreDtos
{
    public class ScoreDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int Points { get; set; }
        public DateTime ScoreDate { get; set; }
    }
}
