using System.ComponentModel.DataAnnotations;

namespace Labb2_WebDev2._0.Shared.DTOs;

public class ProductDTO
{
    public int ProductID { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string EAN { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Description { get; set; }
    public bool Discontinued { get; set; }
}