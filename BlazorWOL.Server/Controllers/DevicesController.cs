using BlazorWOL.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BlazorWOL.Server.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class DevicesController : ControllerBase {
    DeviceStorage Storage { get; }

    public DevicesController(DeviceStorage deviceStorage) {
      Storage = deviceStorage;
    }

    [HttpGet]
    public IEnumerable<Device> GetDevices() =>
      Storage.GetDevices();
  }
}