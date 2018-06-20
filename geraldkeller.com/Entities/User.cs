using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace geraldkeller.com.Entities
{
  [Table("users")]
  //Copyright Gerald Keller 2017
  public class User
  {
    [Key]
    public int id { get; set; }
    [MaxLength(60)]
    public string username { get; set; }
    [MaxLength(128)]
    public string salt { get; set; }
    [MaxLength(64)]
    public byte[] pwhash { get; set; }

    public virtual UserInfo userinfo { get; set; }

    public Models.User ToUserModel()
    {
      return new Models.User
      {
        username = this.username        
      };
    }
  }
}