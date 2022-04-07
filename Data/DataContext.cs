using ChallengeForLife.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeForLife.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		public DbSet<VeryBigSumModel> VeryBigSums { get; set; }
		public DbSet<DiagonalSumModel> DiagonalSums { get; set; }

	}
}