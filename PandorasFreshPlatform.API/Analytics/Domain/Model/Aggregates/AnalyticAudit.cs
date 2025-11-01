using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace PandorasFreshPlatform.API.Analytics.Domain.Model.Aggregates;

public partial class Analytic : IEntityWithCreatedUpdatedDate
{
    [Column("createdAt")] public DateTimeOffset CreatedAt { get; set; }
    [Column("updatedAt")] public DateTimeOffset UpdatedAt { get; set; }
}