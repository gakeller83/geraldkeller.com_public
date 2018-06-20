//Copyright Gerald Keller 2017
using geraldkeller.com.Entities;
using System.Data.Entity;

namespace geraldkeller.com.DBContexts
{
  [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
  public class MySqlContext : DbContext, IMySqlContext
  {
    public MySqlContext() : base("name=MySqlConnection")
    {
      Database.SetInitializer<MySqlContext>(new DropCreateDatabaseIfModelChanges<MySqlContext>());
    }

    public virtual DbSet<User> User {get; set; }
    public virtual DbSet<UserInfo> UserInfo { get; set; }
  }
}