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



5. Create DB

 ```bash
  CREATE DATABASE SupermarketsDb;
  GO
  ```

6. Run migration CLI

 ```bash
  dotnet tool install --global dotnet-ef
  ```

 ```bash
  dotnet ef migrations add InitialCreate -p Infrastructure -s Web.API -o Persistence/Migrations
  ```

 ```bash
  dotnet ef database update -p Infrastructure -s Web.API
  ```

7. Run migration(In VS: Tool > NuGet Package manager > Package manager console)

 ```bash
  update-database
  ```

8. Run project by CLI

 ```bash
  dotnet build
  ```

 ```bash
  dotnet run --project Web.API
  ```