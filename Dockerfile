# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY ./deploy .
CMD dotnet NgAspnetcore.HttpApi.Host.dll