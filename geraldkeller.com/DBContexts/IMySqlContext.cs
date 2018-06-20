//Copyright Gerald Keller 2017
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using geraldkeller.com.Entities;

namespace geraldkeller.com.DBContexts
{
  public interface IMySqlContext : IDisposable
  {
    Task<int> SaveChangesAsync();
    DbSet<User> User { get; set; }
    DbSet<UserInfo> UserInfo { get; set; }

  }
}