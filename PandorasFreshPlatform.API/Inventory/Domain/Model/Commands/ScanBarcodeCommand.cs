namespace PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;

/// <summary>
/// Command to scan a barcode.
/// </summary>
/// <param name="Barcode">
/// The barcode to scan.
/// </param>
/// <param name="DeviceId">
/// The ID of the device performing the scan.
/// </param>
public record ScanBarcodeCommand(string Barcode, string DeviceId);