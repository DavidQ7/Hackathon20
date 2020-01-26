# Instruction 
## Staging https://hackathon2020.herokuapp.com/
## Client(Angular)

Install the dependencies

```sh
$ npm install -g @angular/cli
$ cd Client
$ npm install
$ npm run start
```

## Server(asp-net core 3.1)
 - Download asp-net core sdk version 3.1 : https://dotnet.microsoft.com/download/dotnet-core/3.1
 - cd Server
 - do migration CLI: "dotnet ef database update" or Package Manager Console: "Update-Database"
 - cd Server(Hackathon20\Server\Server)
 - console: "dotnet build"
 - console: "dotnet run"
 - Also, you can build project from visual studio 2017+
