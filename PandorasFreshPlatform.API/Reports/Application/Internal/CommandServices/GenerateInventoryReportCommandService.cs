
using PandorasFreshPlatform.API.Reports.Domain.Model.Aggregates;
using PandorasFreshPlatform.API.Reports.Domain.Model.Commands;
using PandorasFreshPlatform.API.Reports.Domain.Repositories;
using PandorasFreshPlatform.API.Reports.Domain.Services;
using PandorasFreshPlatform.API.Shared.Domain.Repositories;

namespace PandorasFreshPlatform.API.Reports.Application.Internal.CommandServices
{
    /// <summary> Application command service to generate inventory or losses reports. </summary>

    public class GenerateInventoryReportCommandService
    {
        private readonly IReportWriteRepository _reportWriteRepository;
        private readonly IBaseRepository<InventoryItem> _inventoryRepository;
        private readonly IBaseRepository<LossRecord> _lossesRepository;
        private readonly IReportBuilderService _reportBuilderService;
        private readonly IUnitOfWork _unitOfWork;

        public GenerateInventoryReportCommandService(
            IReportWriteRepository reportWriteRepository,
            IBaseRepository<InventoryItem> inventoryRepository,
            IBaseRepository<LossRecord> lossesRepository,
            IReportBuilderService reportBuilderService,
            IUnitOfWork unitOfWork)
        {
            _reportWriteRepository = reportWriteRepository;
            _inventoryRepository = inventoryRepository;
            _lossesRepository = lossesRepository;
            _reportBuilderService = reportBuilderService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handles the report generation command, building and persisting the report.
        /// </summary>
        public async Task<Report> HandleAsync(GenerateReportCommand command)
        {
            Report report;
            if (command.ReportType == "Inventory")
            {
                IEnumerable<InventoryItem> items = await _inventoryRepository.ListAsync();
                report = _reportBuilderService.BuildInventoryReport(items);
            }
            else
            {
                IEnumerable<LossRecord> losses = await _lossesRepository.ListAsync();
                report = _reportBuilderService.BuildLossesReport(losses);
            }

            await _reportWriteRepository.AddAsync(report);
            await _unitOfWork.CompleteAsync();
            return report;
        }
    }
}
