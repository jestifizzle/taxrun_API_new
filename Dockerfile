FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["taxrun_API_new.csproj", ""]
RUN dotnet restore "./taxrun_API_new.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "taxrun_API_new.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "taxrun_API_new.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "taxrun_API_new.dll"]