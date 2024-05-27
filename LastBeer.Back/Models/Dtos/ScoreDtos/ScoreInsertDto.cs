namespace LastBeer.Back.Models.Dtos.ScoreDtos
{
    public class ScoreInsertDto
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int Points { get; set; }
        public DateTime ScoreDate { get; set; }
    }
}
