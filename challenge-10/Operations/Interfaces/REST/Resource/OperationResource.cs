namespace challenge_10.Operations.Interfaces.REST.Resource;

public record OperationResource
{
    public OperationResource(int id, string name, string description, bool completed, DateTime completedDate)
    {
        Id = id;
        Name = name;
        Description = description;
        Completed = completed;
        CompletedDate = completedDate;


    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    
    public DateTime CompletedDate { get; set; }

}
