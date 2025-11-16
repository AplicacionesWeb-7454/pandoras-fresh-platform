using pandoraFr.API.Reports.Application.Internal.CommandServices;
using pandoraFr.API.Reports.Domain.Repositories;
using pandoraFr.API.Reports.Domain.Services;
using pandoraFr.API.Shared.Domain.Repositories;

namespace pandoraFr.API.Reports.Application.Internal.CommandServices.Handlers;

public class GenerateLossesReportCommandHandler
{
    private readonly ILossesReadRepository _lossesRepo;
    private readonly IReportBuilderService _builder;
    private readonly IReportWriteRepository _reportWrite;
    private readonly IUnitOfWork _uow;

    public GenerateLossesReportCommandHandler(
        ILossesReadRepository lossesRepo,
        IReportBuilderService builder,
        IReportWriteRepository reportWrite,
        IUnitOfWork uow)
    {
        _lossesRepo = lossesRepo;
        _builder = builder;
        _reportWrite = reportWrite;
        _uow = uow;
    }

    public async Task<Guid> HandleAsync(GenerateLossesReportCommand cmd)
    {
        var data = await _lossesRepo.GetLossesAsync(cmd.From, cmd.To, cmd.ProductType);
        var report = _builder.BuildLossesReport("Reporte de mermas", data);
        await _reportWrite.SaveAsync(report);
        await _uow.CompleteAsync();
        return report.Id;
    }
}