﻿namespace Labb2_WebDev2._0.Dataccess.Entities;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public string EAN { get; set; }
    public float Price { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public bool Discontinued { get; set; }
}