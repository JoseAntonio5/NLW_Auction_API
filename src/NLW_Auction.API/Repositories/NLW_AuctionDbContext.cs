using Microsoft.EntityFrameworkCore;
using NLW_Auction.API.Entities;

namespace NLW_Auction.API.Repositories;

public class NLW_AuctionDbContext : DbContext 
{

    public DbSet<Auction> Auctions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\jlope\\workspace\\leilaoDbNLW.db");
    }
}
