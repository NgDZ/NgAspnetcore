# Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:5.0
FROM ubuntu
COPY ./deploy .
CMD NgAspnetcore.HttpApi.Host
#CMD dotnet NgAspnetcore.HttpApi.Host.dll