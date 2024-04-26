using JsonApiDotNetCore.Resources;
using JsonApiDotNetCore.Resources.Annotations;

namespace Sample.Data.Entities;

[Resource]
public class Person : Identifiable<int>
{
    [Attr]
    public string Name { get; set; } = null!;
}
