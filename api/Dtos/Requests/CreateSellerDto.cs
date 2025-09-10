using System.ComponentModel.DataAnnotations;

namespace api;

public record CreateSellerDto
{
    [MinLength(2)] [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}