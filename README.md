dotnet tool install --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore.tools
Microsoft.EntityFrameworkCore.SqlServer

Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
 Microsoft.AspNetCore.Mvc.NewtonsoftJson


#Migration EF
 dotnet ef migrations add Init 
 dotnet ef database update

"Server=localhost,1433;Database=Lab365;User ID=sa;Password=kalleb09321@;Trusted_Connection=False; TrustServerCertificate=True;"

#Automapper

1 - dotnet add package AutoMapper
2 - dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1