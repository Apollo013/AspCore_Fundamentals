# DotNetCore_Fundamentals 

Developed with Visual Studio 2015 Community

---

###Techs
|Tech|
|----|
|ASP.NET Core|
|C#|

---

###Features
|Feature|Description|Project|
|-------|-----------|-------|
|Dependency Injection | Demonstrates transient & singleton injection with .NET CORE's builtin DI | [DependencyInjection](https://github.com/Apollo013/DotNetCore_Fundamentals/tree/master/DependencyInjection)|
|| Injecting an Action delegate for configuring options (IOption interface)| [ConfigurationManagement](https://github.com/Apollo013/DotNetCore_Fundamentals/tree/master/ConfigurationManagement) |
|Configuration| Demonstrates how to access the 'appsettings'json' file using IConfiguration.| [ConfigurationManagement](https://github.com/Apollo013/DotNetCore_Fundamentals/tree/master/ConfigurationManagement) |
| | Loading of specific appsettings file depending on environment setting  | [Environment] (https://github.com/Apollo013/DotNetCore_Fundamentals/blob/master/Environment/Startup.cs)|
|Middleware| Custom logging and terminal middleware using RequestDelegate's & 'IApplicationBuilder' extensions | [Middleware](https://github.com/Apollo013/DotNetCore_Fundamentals/tree/master/Middleware)|
|Static Files| Demonstrates provision of static files (.js, css, etc) with use of app.UseDefaultFiles(), UseStaticFiles(), UseWelcomePage("/hello"), DefaultFilesOptions & StaticFileOptions | [StaticFiles](https://github.com/Apollo013/DotNetCore_Fundamentals/tree/master/StaticFiles)|
|| Combining 'UseDefaultFiles()' & 'UseStaticFiles()' with 'app.UseFileServer()'|[StaticFiles](https://github.com/Apollo013/DotNetCore_Fundamentals/tree/master/StaticFiles)|

---

###Resources
|Title|Author|Website|
|-----|------|-------|
|[Introduction to ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/)||MSDN|
|[Dependency injection into controllers](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection#accessing-settings-from-a-controller)||MSDN|
|[Introduction to ASP.NET Core](https://dotnetcodr.com/2017/01/16/introduction-to-asp-net-core-part-1-anatomy-of-an-empty-web-project/)|Andras Nemes|dotnetcodr|
|[Codelabs Web-Dex](https://github.com/Microsoft-Build-2016/CodeLabs-WebDev)| |Microsoft|
