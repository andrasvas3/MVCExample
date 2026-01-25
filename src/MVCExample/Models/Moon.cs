using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExample.Models;

[Table("Moon")]
public class Moon
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("PK_MoonId")]
    public int Id { get; set; }

    [Column("Name")]
    public string? Name { get; set; }

    [ForeignKey("Planet")]
    public int PlanetId { get; set; }
    public Planet? Planet { get; set; }
}
