using pandoraFr.API.Reports.Application.Internal.CommandServices;
using pandoraFr.API.Reports.Domain.Repositories;
using pandoraFr.API.Reports.Domain.Services;
using pandoraFr.API.Shared.Domain.Repositories;

namespace pandoraFr.API.Reports.Application.Internal.CommandServices.Handlers;

public class GenerateInventoryReportCommandHandler
{
    private readonly IInventoryReadRepository _inventoryRepo;
    private readonly IReportBuilderService _builder;
    private readonly IReportWriteRepository _reportWrite;
    private readonly IUnitOfWork _uow;

    public GenerateInventoryReportCommandHandler(
        IInventoryReadRepository inventoryRepo,
        IReportBuilderService builder,
        IReportWriteRepository reportWrite,
        IUnitOfWork uow)
    {
        _inventoryRepo = inventoryRepo;
        _builder = builder;
        _reportWrite = reportWrite;
        _uow = uow;
    }

    public async Task<Guid> HandleAsync(GenerateInventoryReportCommand cmd)
    {
        var data = await _inventoryRepo.GetSnapshotAsync(cmd.From, cmd.To);
        var report = _builder.BuildInventoryReport("Reporte de inventario", data);
        await _reportWrite.SaveAsync(report);
        await _uow.CompleteAsync();
        return report.Id;
    }
}