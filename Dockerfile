FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
EXPOSE 80
EXPOSE 443

WORKDIR /app
COPY app/publish .
ENTRYPOINT ["dotnet", "DummyCDCI.dll"]
