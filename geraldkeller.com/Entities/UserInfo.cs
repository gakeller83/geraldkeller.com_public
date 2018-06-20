//Copyright Gerald Keller 2017
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geraldkeller.com.Entities
{
  [Table("user_info")]
  public class UserInfo
  {
    [Key, ForeignKey("user")]
    public int id { get; set; }
    [MaxLength(320)]
    public string email { get; set; }    
    public virtual User user { get; set; }
  }
}