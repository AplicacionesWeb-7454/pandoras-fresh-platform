namespace pandoraFr.API.Reports.Interfaces.REST.Resources;

public record DashboardResource(int TotalInventory, int TotalLossesUnits, decimal TotalLossesCost, int AlertsCount);