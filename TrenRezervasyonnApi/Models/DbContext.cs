using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrenRezervasyonnApi.Models;

public class TrainReservationContext : DbContext
{
	public DbSet<Tren> Trens { get; set; }
	public DbSet<Vagon> Vagons { get; set; }
	

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TrainReservation;Trusted_Connection=True;");
	}
}