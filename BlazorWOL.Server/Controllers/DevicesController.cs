using Microsoft.AspNetCore.Mvc;

namespace BlazorWOL.Server.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class DevicesController : ControllerBase {
    DeviceStorage Storage { get; }

    public DevicesController(DeviceStorage deviceStorage) {
      Storage = deviceStorage;
    }
  }
}