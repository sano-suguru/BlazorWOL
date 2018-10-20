﻿using Microsoft.AspNetCore.Blazor.Hosting;

namespace BlazorWOL.Client {
  public class Program {
    static void Main(string[] args) {
      CreateHostBuilder(args).Build().Run();
    }

    public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
        BlazorWebAssemblyHost.CreateDefaultBuilder()
            .UseBlazorStartup<Startup>();
  }
}
