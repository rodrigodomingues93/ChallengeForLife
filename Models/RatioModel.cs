namespace ChallengeForLife.Models
{
	public class RatioModel
	{
		public Guid Id { get; set; }
		public string InputValue { get; set; }
		public string OutputValuePositive { get; set; }
		public string OutputValueNegative { get; set; }
		public string OutputValueNil { get; set; }
		public DateTimeOffset CreatedDate { get; set; }

	}
}
