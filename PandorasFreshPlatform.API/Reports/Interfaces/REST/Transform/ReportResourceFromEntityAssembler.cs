using PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Reports.Interfaces.REST.Resources;

/// <summary>
/// Assembler for mapping Report aggregate to ReportResource DTO.
/// </summary>
namespace PandorasFreshPlatform.API.Reports.Interfaces.REST.Transform
{
    public static class ReportResourceFromEntityAssembler
    {
        public static ReportResource ToResource(Report entity)
        {
            return new ReportResource
            {
                Id = entity.Id,
                Title = entity.Title,
                Type = entity.Type,
                GeneratedAt = entity.GeneratedAt
            };
        }
    }
}