FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Fibonacci.Calculator/Fibonacci.Calculator.csproj", "Fibonacci.Calculator/"]
COPY ["Fibonacci.Calculator.Infrastructure/Fibonacci.Calculator.Infrastructure.csproj", "Fibonacci.Calculator.Infrastructure/"]
COPY ["Fibonacci.Calculator.Domain/Fibonacci.Calculator.Domain.csproj", "Fibonacci.Calculator.Domain/"]
RUN dotnet restore "Fibonacci.Calculator/Fibonacci.Calculator.csproj"
COPY . .
WORKDIR "/src/Fibonacci.Calculator"
RUN dotnet build "Fibonacci.Calculator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fibonacci.Calculator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fibonacci.Calculator.dll"]