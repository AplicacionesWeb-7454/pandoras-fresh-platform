using PandorasFreshPlatform.API.Analytics.Domain.Model.Commands;
    
namespace PandorasFreshPlatform.API.Analytics.Domain.Model.Entities;

public class Analytic
{
    public Analytic()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public Analytic(string name, string description):this()
    {
        Name = name;
        Description = description;   
    }
    public Analytic(createAnalyticCommand command):this(command.Name,command.Description)
    {
        
    }
    
    public string Name { get; set; }
    public string Description { get; set; }
}