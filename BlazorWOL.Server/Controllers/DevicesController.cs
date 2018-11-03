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

    [HttpGet, Route("{id}")]
    public IActionResult GetDevice(Guid id) {
      var device = Storage.GetDevice(id);
      if (device is null) { return NotFound(); }
      return Ok(device);
    }

    [HttpPost]
    public IActionResult AddDevice([FromBody] Device device) {
      Storage.AddDevice(device);
      return Ok(device);
    }

    [HttpPut, Route("{id}")]
    public IActionResult UpdateDevice(Guid id, [FromBody]Device device) {
      Storage.UpdateDevice(id, device);
      return Ok();
    }

    [HttpDelete, Route("{id}")]
    public IActionResult DeleteDevice(Guid id) {
      var deleted = Storage.DeleteDevice(id);
      if (deleted is null) { return NotFound(); }
      return Ok();
    }
  }
}