from mcr.microsoft.com/dotnet/sdk:8.0
workdir app
run dotnet new console -n DotnetKafka
workdir DotnetKafka
copy . .
run dotnet restore
run dotnet build
entrypoint dotnet run
