﻿using BlazorWOL.Shared;
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
  }
}