﻿namespace Diet.Models;

public partial class Food : Summary
{
    public int Id { get; set; }

    public string Name { get; set; }

    public long Max { get; set; }
}