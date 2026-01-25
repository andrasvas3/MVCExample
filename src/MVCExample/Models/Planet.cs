using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCExample.Models;

[Table("Planet")]
public class Planet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("PK_PlanetId")]
    public int Id { get; set; }

    [Column("Name")]
    public string? Name { get; set; }

    public ICollection<Moon>? Moons { get; set; }
}
