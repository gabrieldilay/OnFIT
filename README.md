1 Comandos para gerar a versão inicial

dotnet new webapi -o MyFood
cd MyFood
dotnet restore
dotnet add package Microsoft.AspNetCore.Authentication
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design

2 Comandos para gerar o banco de dados

dotnet tool install --global dotnet-ef
dotnet ef migrations add Inicial
dotnet ef database update

3 Comando para rodar a aplicação

dotnet watch run
