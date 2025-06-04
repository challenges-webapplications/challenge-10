namespace challenge_10.Operations.Interfaces.REST.Resource;

public record OperationResource
{
    public OperationResource(int id, string name, string description, bool completed)
    {
        Id = id;
        Name = name;
        Description = description;
        Completed = completed;
        
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }

}
