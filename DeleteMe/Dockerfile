FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DeleteMe/DeleteMe.csproj", "DeleteMe/"]
RUN dotnet restore "DeleteMe/DeleteMe.csproj"
COPY . .
WORKDIR "/src/DeleteMe"
RUN dotnet build "DeleteMe.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeleteMe.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeleteMe.dll"]
