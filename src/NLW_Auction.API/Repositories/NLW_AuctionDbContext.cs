using Microsoft.EntityFrameworkCore;
using NLW_Auction.API.Entities;

namespace NLW_Auction.API.Repositories;

public class NLW_AuctionDbContext : DbContext 
{
    public NLW_AuctionDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Auction> Auctions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Offer> Offers { get; set; }
}
