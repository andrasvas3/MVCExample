# HelloWorld

` mkdir MVCExample `

` dotnet new sln `

` mkdir src\MVCExample `

` dotnet new mvc -o src\MVCExample --use-program-main `

` dotnet sln add src\MVCExample `

` dotnet add src\MVCExample package Microsoft.EntityFrameworkCore.Sqlite `

` dotnet run --project src\MVCExample `
