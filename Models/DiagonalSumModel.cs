namespace ChallengeForLife.Models
{
	public class DiagonalSumModel
	{
		public Guid Id { get; set; }
		public string InputValue { get; set; } = string.Empty;
		public string OutputValue { get; set; } = string.Empty;
		public DateTimeOffset CreatedDate { get; set; }
	}
}
