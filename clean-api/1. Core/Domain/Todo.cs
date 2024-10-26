﻿namespace Domain;

public class Todo
{
    public int Id { get; set; }
    
    public required string Title { get; set; }
    
    public string? Description { get; set; }
}
