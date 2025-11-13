using PandorasFreshPlatform.API.Inventory.Domain.Model.Commands;
using PandorasFreshPlatform.API.Inventory.Interfaces.REST.Resources;

namespace PandorasFreshPlatform.API.Inventory.Interfaces.REST.Transform;

public static class ScanBarcodeCommandFromResourceAssembler
{
    public static ScanBarcodeCommand ToCommandFromResource(ScanBarcodeResource resource)
    {
        return new ScanBarcodeCommand(resource.Barcode, resource.DeviceId);
    }
}