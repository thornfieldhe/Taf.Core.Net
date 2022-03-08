FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Taf.Core.Net.Web/Taf.Core.Net.Web.csproj", "Taf.Core.Net.Web/"]
RUN dotnet restore "Taf.Core.Net.Web/Taf.Core.Net.Web.csproj"
COPY . .
WORKDIR "/src/Taf.Core.Net.Web"
RUN dotnet build "Taf.Core.Net.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Taf.Core.Net.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taf.Core.Net.Web.dll"]
