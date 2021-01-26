# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:5.0
COPY ./deploy .
CMD dotnet NgAspnetcore.HttpApi.Host.dll