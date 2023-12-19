namespace RunningHillTest.Application.Models
{
    public class WordDto
    {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public required int WordTypeId { get; set; }
    }
}
