using System.ComponentModel.DataAnnotations;

namespace Labb2_WebDev2._0.Shared.DTOs;

public class OrderDTO
{
    [Required]
    public int CustomerID { get; set; }
    [Required]
    public List<int> Products { get; set; } = new();
}