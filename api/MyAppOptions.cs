using System.ComponentModel.DataAnnotations;

public sealed class MyAppOptions
{
    [Required] [MinLength(20)] public string Db { get; set; } = string.Empty!;
}