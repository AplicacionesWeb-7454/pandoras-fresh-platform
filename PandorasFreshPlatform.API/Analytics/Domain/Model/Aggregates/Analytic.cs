using PandorasFreshPlatform.API.Analytics.Domain.Model.Commands;

namespace PandorasFreshPlatform.API.Analytics.Domain.Model.Aggregates;

public partial class Analytic
{
    public Analytic(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Analytic(createAnalyticCommand command) : this(command.Id,command.Name,command.Description)
    {
        
    }

    public int Id { get;  }
    public string Name { get;  }
    public string Description { get;  }
    
}