# HelloWorld

` mkdir MVCExample `

` dotnet new sln `

` mkdir src\MVCExample `

` dotnet new mvc -o src\MVCExample --use-program-main `

` dotnet sln add src\MVCExample `

` dotnet add src\MVCExample package Microsoft.EntityFrameworkCore.Sqlite `

` dotnet run --project src\MVCExample `

# Container

` podman build --tag mvcexample -f Containerfile . `

` podman run --detach --rm --publish 8080:8080/tcp --name mvcexample mvcexample `
