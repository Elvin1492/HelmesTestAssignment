# SectorApp.Web.UI



## Installation

Projects on solution developed by .Net Core 2.2, so you should install correct [version](https://dotnet.microsoft.com/download/visual-studio-sdks) for build and run. I used Database First Entityframework. So I don't have Core level in N-tiers( Actually I could seperate it, but for any change on Db I have to do this again)


## Usage

Solution consists of 4 projects and 2 unit test projects. The Web project is Angular SPA project and first time run can take more time to install correspond npm packages.

```
Tests
-SectorApp.Repository.UnitTests
-SectorApp.Service.UnitTests
SectorApp.DataAccess
SectorApp.Repository
SectorApp.Service
SectorApp.Web.UI
```
Script.js file is in _SectorApp.DataAccess.Scripts_ Folder. Execute it in SSMS. Then change data source in appsettings.json and _AppUserServiceTest_
```
 "ConnectionStrings": {
    "DefaultConnection": "Data Source=MAMMADOVE10;Initial Catalog=SectorApp;Integrated Security=True;"
  }
```
```C#
 optionsBuilder.UseSqlServer("Server=MAMMADOVE10;Database=SectorApp;Trusted_Connection=True;");
```
## Notes
Because of I developed app in .Net Core 2.2, the unit test using directly database for test (.Net Core 2.2 doesn't support UseInMemoryDatabase options), but queries is not excuted, so it is still unit test, not integration
