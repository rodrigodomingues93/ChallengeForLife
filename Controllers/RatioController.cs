using ChallengeForLife.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeForLife.Controllers
{
	[ApiController]
	[Route("[controller]")]

	public class RatioController : ControllerBase
	{
		private static List<RatioModel> ListOfRatios = new List<RatioModel>();

		[HttpPost]
		public IActionResult PostRatio([FromBody] string input)
		{
			string[] numbers = input.Split(',');
			int n = numbers.Count();

			if (n == 0)
			{
				return BadRequest();
			}
			else
			{
				RatioModel ratio = new RatioModel();
				ratio.Id = Guid.NewGuid();
				ratio.InputValue = input;
				ratio.CreatedDate = DateTimeOffset.UtcNow;

				int positive = 0, negative = 0, nil = 0;

				for (int i =0; i<numbers.Count();i++)
				{
					if (Convert.ToInt32(numbers[i]) > 0)
						positive++;
					else if(Convert.ToInt32(numbers[i]) < 0)
						negative++;
					else
						nil++;
				}

				ratio.OutputValuePositive = ((float)positive / (float)n).ToString("N6");
				ratio.OutputValueNegative = ((float)negative / (float)n).ToString("N6");
				ratio.OutputValueNil = ((float)nil / (float)n).ToString("N6");

				ListOfRatios.Add(ratio);
				return Ok(ratio);

			}
		}

		[HttpGet]
		public IActionResult GetRatios()
		{
			return Ok(ListOfRatios);
		}
		
		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			return Ok(ListOfRatios.FirstOrDefault(sum => sum.Id == id));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			var ratioDelete = ListOfRatios.FirstOrDefault(sum => sum.Id == id);

			ListOfRatios.Remove(ratioDelete);
			return Ok(true);
		}
	}
}
