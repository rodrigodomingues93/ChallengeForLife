using ChallengeForLife.Data;
using ChallengeForLife.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeForLife.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class VeryBigSumController : ControllerBase
	{
		private readonly DataContext _vbsContext;

		public VeryBigSumController(DataContext vbsContext)
		{
			_vbsContext = vbsContext;
		}
		private static List<VeryBigSumModel> ListOfSums = new List<VeryBigSumModel>();

		[HttpPost]
		public IActionResult PostVBSum([FromBody] string input)
		{
			string[] buffer = input.Split(' ');

			if (buffer.Count() != 5)
				return BadRequest();
			else
			{
				VeryBigSumModel sum = new VeryBigSumModel();
				sum.Id = Guid.NewGuid(); ;
				sum.InputValue = input;
				sum.CreatedDate = DateTimeOffset.UtcNow;
				long total = 0L;

				foreach (var number in buffer)
				{
					total += Convert.ToInt32(number);
				}

				sum.OutputValue = total.ToString();
				_vbsContext.VeryBigSums.Add(sum);
				_vbsContext.SaveChanges();
				ListOfSums.Add(sum);

				return Ok(sum);
			}
		}

		[HttpGet]
		public IActionResult GetVBSums()
		{
			return Ok(ListOfSums.OrderByDescending(sum => sum.CreatedDate));
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			return Ok(ListOfSums.FirstOrDefault(sum => sum.Id == id));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			var sumDelete = ListOfSums.FirstOrDefault(sum => sum.Id == id);
			_vbsContext.VeryBigSums.Remove(sumDelete);
			_vbsContext.SaveChanges();
			ListOfSums.Remove(sumDelete);
			return Ok(true);
		}
	}
}
