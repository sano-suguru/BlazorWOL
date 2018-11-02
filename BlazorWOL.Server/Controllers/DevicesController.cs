using BlazorWOL.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
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

    [HttpGet, Route("{guid}")]
    public IActionResult GetDevice(Guid id) {
      var device = Storage.GetDevice(id);
      if (device == null) { return NotFound(); }
      return Ok(device);
    }

    [HttpPost]
    public IActionResult AddDevice([FromBody] Device device) {
      Storage.AddDevice(device);
      return Ok(device);
    }

    [HttpPut, Route("{guid}")]
    public IActionResult UpdateDevice(Guid guid, [FromBody]Device device) {
      Storage.UpdateDevice(guid, device);
      return Ok();
    }

    [HttpDelete, Route("{guid}")]
    public IActionResult DeleteDevice(Guid id) {
      var deleted = Storage.DeleteDevice(id);
      if (deleted is null) { return NotFound(); }
      return Ok();
    }
  }
}