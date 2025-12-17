using System.ComponentModel.DataAnnotations;
using TravelTripProject.Models.Class;

public class Comments
{
    [Key]
    public int Id { get; set; }

    public string KullaniciAdi { get; set; }
    public string Mail { get; set; }
    public string Yorum { get; set; }

    public int BlogId { get; set; }  
    public virtual Blog Blog { get; set; }
}
