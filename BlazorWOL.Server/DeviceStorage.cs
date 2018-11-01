using BlazorWOL.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BlazorWOL.Server {
  public class DeviceStorage {
    string StoragePath { get; }
    List<Device> Devices { get; } = new List<Device>();

    public DeviceStorage(string storagePath) {
      StoragePath = storagePath;
      if (File.Exists(StoragePath)) {
        var json = File.ReadAllText(StoragePath);
        var devices = JsonConvert.DeserializeObject<Device[]>(json);
        Devices.AddRange(devices);
      }
    }

    public List<Device> GetDevices() {
      lock (this) {
        return Devices;
      }
    }

    public void AddDevice(Device device) {
      lock (this) {
        this.Devices.Add(device);
        FlushToStorage();
      }
    }

    private Device GetDevice(Guid id) {
      lock (this) {
        return Devices.Find(device => device.Id == id);
      }
    }

    public void UpdateDevice(Guid id, Device device) {
      lock (this) {
        Device updateTo = GetDevice(id);
        updateTo.Name = device.Name;
        updateTo.MACAddress = device.MACAddress;
        FlushToStorage();
      }
    }

    public Device DeleteDevice(Guid id) {
      lock (this) {
        Device deleteTo = GetDevice(id);
        if (deleteTo != null) {
          Devices.Remove(deleteTo);
        }
        FlushToStorage();
        return deleteTo;
      }
    }

    private void FlushToStorage() {
      lock (this) {
        var json = JsonConvert.SerializeObject(Devices);
        File.WriteAllText(StoragePath, json);
      }
    }
  }
}
