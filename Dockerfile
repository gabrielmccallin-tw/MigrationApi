FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY /out .

ENTRYPOINT ["dotnet", "Api.dll"]
