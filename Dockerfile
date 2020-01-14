FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
WORKDIR /app
COPY /out .

ENV PRM_LISTEN_PORT=5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "Api.dll"]
