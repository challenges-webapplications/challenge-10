using System;
using System.Collections.Generic;
using challenge_10.Shared.Domain.Model.Entities;

namespace challenge_10.Operations.Domain.Models.Entities;

public class Operation : BaseEntity
{
    public string Name { get; init; }
    public string Description { get; init; }
    public bool Completed { get; init; }

    public DateTime CompletedDate { get; init; }

    public Operation(string name, string description, bool completed, DateTime completedDate)
    {

        Name = name;
        Description = description;
        Completed = completed;
        CompletedDate = completedDate;
    }



}
