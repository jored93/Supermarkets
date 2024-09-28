# Base Clean Architecture .net

## Steps

1. Create project folder

 ```bash
  dotnet new sln -o Supermarkets
  ```

 ```bash
  cd Supermarkets
  ```

2. Create layer clean architecture CLI command or create by the IDE (right click, add project and select new classlib)

 ```bash
  dotnet new classlib -o Domain -f net8.0
  ```

 ```bash
  dotnet new classlib -o Application -f net8.0
  ```

 ```bash
  dotnet new classlib -o Infrastructure -f net8.0
  ```

 ```bash
  dotnet new webapi -o Web.API -f net8.0 -controllers
  ```

3. Add internal references

 ```bash
  dotnet add Application/Application.csproj reference Domain/Domain.csproj
  ```

 ```bash
  dotnet add Infrastructure/Infrastructure.csproj reference Domain/Domain.csproj
  ```

 ```bash
  dotnet add Infrastructure/Infrastructure.csproj reference Application/Application.csproj
  ```

 ```bash
  dotnet add Web.API/Web.API.csproj reference Application/Application.csproj Infrastructure/Infrastructure.csproj
  ```

4. (Optional) In case of create the classlib by CLI

 ```bash
  dotnet sln add Web.API/Web.API.csproj
  ```

 ```bash
  dotnet sln add Application/Application.csproj
  ```

 ```bash
  dotnet sln add Infrastructure/Infrastructure.csproj
  ```

 ```bash
  dotnet sln add Domain/Domain.csproj
  ```

5. (Optional) Run project by CLI

 ```bash
  dotnet build
  ```

 ```bash
  dotnet run --project Web.API
  ```

6. Create docker MSSQL database

 ```bash
  docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong#Password" -p 1433:1433 -d --name sqlserver  mcr.microsoft.com/mssql/server:2022-latest
  ```

7. Run migration(In VS: Tool > NuGet Package manager > Package manager console)

 ```bash
  update-database
  ```