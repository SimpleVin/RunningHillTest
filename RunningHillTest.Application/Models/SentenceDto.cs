namespace RunningHillTest.Application.Models
{
    public class SentenceDto
    {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public required string Words { get; set; }
    }
}
