using BlazorWOL.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWOL.Client {
  public class DevicesService {
    List<Device> Devices { get; } = new List<Device> {
      new Device {
        Name = "Odin",
        MACAddress = "00:15:5D:52:CA:B6"
      },
      new Device {
        Name = "Thor",
        MACAddress = "00:0C:29:30:7D:5D"
      },
      new Device {
        Name = "Fenrir",
        MACAddress = "00:50:56:01:43:86"
      },
    };

    public async Task<IEnumerable<Device>> GetDeviceAsync() =>
      await Task.FromResult(Devices);

    public async Task AddDeviceAsync(Device device) =>
      await Task.Run(() => Devices.Add(device));

    public async Task<Device> GetDeviceAsync(Guid id) =>
      await Task.Run(() => Devices.FirstOrDefault(d => d.Id == id));

    public async Task UpdateDeviceAsync(Guid id, Device device) =>
      await Task.Run(() => {
        var target = Devices.FirstOrDefault(d => d.Id == id);
        target.Name = device.Name;
        target.MACAddress = device.MACAddress;
      });
  }
}
