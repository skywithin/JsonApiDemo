using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Data.Entities;

[Resource]
public class Person : Identifiable<int>
{
    [Column("PersonID")]
    public override int Id { get; set; }

    public int PersonID { get; set; }

    [Attr(PublicName = "first-name")]
    public string FirstName { get; set; } = null!;

    [Attr(PublicName = "last-name")]
    public string LastName { get; set; } = null!;
}
