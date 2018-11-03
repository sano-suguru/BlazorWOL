using BlazorWOL.Shared;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWOL.Client {
  public class DeviceService {
    readonly HttpClient httpClient;

    public DeviceService(HttpClient httpClient) {
      this.httpClient = httpClient;
    }

    public async Task<IEnumerable<Device>> GetDevicesAsync() =>
      await httpClient.GetJsonAsync<Device[]>("api/devices");

    public async Task AddDeviceAsync(Device device) =>
      await httpClient.PostJsonAsync("api/devices", device);

    public async Task<Device> GetDeviceAsync(Guid id) {
      try {
        return await httpClient.GetJsonAsync<Device>($"api/devices/{id}");
      } catch (HttpRequestException e) when (e.Message == "404 (Not Found)") {
        return null;
      }
    }

    public async Task UpdateDeviceAsync(Guid id, Device device) =>
      await httpClient.PutJsonAsync($"api/devices/{id}", device);

    public async Task DeleteDeviceAsync(Guid id) =>
      await httpClient.DeleteAsync($"api/devices/{id}");

    public async Task WakeupAsync(Guid id) =>
      await httpClient.PostJsonAsync($"api/devices/{id}/wakeup", "");
  }
}
