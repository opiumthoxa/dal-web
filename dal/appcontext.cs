using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication3.Models;


public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Sotrudnik> Sotrudniks { get; set; }
    public DbSet<Uvolnenie_PSJ> Uvolnenies_PSJ { get; set; }
    public DbSet<Uvolnenie_Rukovodstvom> Uvolnenies_Rukovodstvom { get; set; }
    public DbSet<OtdelKadrov> OtdelsKadrov { get; set; }
}