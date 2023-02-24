namespace DaprWebApi.DTOs
{
    public class BetDto
    {
        public int Id { get; set; }
        public int BetId { get; set; }
        public decimal ToWin { get; set; }

        public decimal AskRisk { get; set; }
    }
}
