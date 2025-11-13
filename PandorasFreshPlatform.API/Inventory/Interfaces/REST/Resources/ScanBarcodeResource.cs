namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

/// <summary>
/// Resource to scan a barcode
/// </summary>
/// <param name="Barcode">
/// The barcode to scan
/// </param>
/// <param name="DeviceId">
/// The ID of the device performing the scan
/// </param>
public record ScanBarcodeResource(string Barcode, string DeviceId);