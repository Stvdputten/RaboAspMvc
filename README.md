# Overview MVC C# example start up 
Project end state is included

1. dotnet new webapp -o aspnetcoreapp
2. Install package nuget packages Microsoft.EntityFrameworkCore.Design and Npgsql.EntityFrameworkCore.PostgreSQL and cli ef through dotnet tool install --global dotnet-ef https://docs.microsoft.com/en-us/ef/core/cli/dotnet
3. Create Models -> create Controllers 
4. Set up Postgresdatabase (docker or something), choice is yours obviously and connect to it by using the models
5. update controllers to reflect database
6. (optionals) use some database client to check database, dBeaver or some docker pgadmin or some other dbclient
7. create migration files: (a) dotnet ef migrations add "Firstmigration" then (b) dotnet ef database update there should be some newly created migrations folder with the migrations in it