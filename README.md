
# Cloud Products Application
The application is built for customers to view the available cars and create new car.
The application is built with front end using React 16.12.0 and back end using ASP.NET Core 3.1
## Getting started
### Prerequisites
1. Environment
  - Node.js Latest LTS Version
  - ASP.NET Core 3.1 SDK
2. A clone or download of this repo on your local machine
### Installation
1. Go to the project root
2. `cd` to MiniCarsales.Api folder and run `dotnet restore` for back end
3. `cd` to MiniCarsales.App folder and run `dotnet restore` for front end
### Running in development mode
#### Back end
- `cd` to MiniCarsales.Api folder
- Run `dotnet run`
#### Front end
- `cd` to MiniCarsales.App folder
- Run `dotnet run`
- Visit [http://localhost:3000/](http://localhost:3000/) on browser
### Running  in production mode
#### Back end
- `cd` to MiniCarsales.Api folder
- Run `dotnet publish MiniCarsales.Api.csproj -c Release -o bin/publish`
- `cd` to publish folder
- Run `dotnet MiniCarsales.Api.dll`
#### Front end
- `cd` to MiniCarsales.App folder
- Run `dotnet publish MiniCarsales.App.csproj -c Release -o bin/publish`
- `cd` to publish folder
- Run `dotnet MiniCarsales.App.dll`
- Visit [http://localhost:3000/](http://localhost:3000/) on browser
### Unit test
#### Back end
- `cd` to MiniCarsales.Api.UnitTests folder
- Run `dotnet test`
#### Front end
- `cd` to ClientApp folder under MiniCarsales.App
- Run `npm run test`