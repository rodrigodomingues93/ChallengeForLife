using ChallengeForLife.Data;
using ChallengeForLife.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeForLife.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DiagonalSumController : ControllerBase
	{
		private readonly DataContext _dsContext;

		public DiagonalSumController(DataContext dsContext)
		{
			_dsContext = dsContext;
		}
		private static List<DiagonalSumModel> ListDiagonalSums = new List<DiagonalSumModel>();

		[HttpPost]
		public IActionResult PostDiagonalSum([FromBody] string input)
		{
			string[] matrix = input.Split(' ');
			double side = Math.Sqrt(matrix.Length);
			int lado = (int)(side);

			if ((side - lado) != 0)
			{
				return BadRequest();
			}
			else
			{
				DiagonalSumModel sum = new DiagonalSumModel();
				sum.Id = Guid.NewGuid();
				sum.InputValue = input;
				sum.CreatedDate = DateTimeOffset.UtcNow;

				int Sum1 = 0, Sum2 = 0, counter=0;
				for (int i = 0; i < lado; i++)
				{
					for (int j = 0; j < lado; j++)
					{
						if (i == j)
							Sum1 += Convert.ToInt32(matrix[counter]);
						if (i + j == lado - 1)
							Sum2 += Convert.ToInt32(matrix[counter]);
						counter++;
					}
				}
				sum.OutputValue = Math.Abs(Sum1 - Sum2).ToString();

				_dsContext.DiagonalSums.Add(sum);
				_dsContext.SaveChanges();
				
				ListDiagonalSums.Add(sum);

				return Ok(sum);
			}
		}

		[HttpGet]
		public IActionResult GetDiagonalSums()
		{
			return Ok(ListDiagonalSums);
		}

		[HttpGet("{id}")]
		public IActionResult Get(Guid id)
		{
			return Ok(ListDiagonalSums.FirstOrDefault(sum => sum.Id == id));
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(Guid id)
		{
			var diagonalDelete = ListDiagonalSums.FirstOrDefault(sum => sum.Id == id);
			
			_dsContext.DiagonalSums.Remove(diagonalDelete);
			_dsContext.SaveChanges();

			ListDiagonalSums.Remove(diagonalDelete);
			return Ok(true);
		}
	}
}
