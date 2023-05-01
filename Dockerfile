# Build Stage

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . . 
RUN dotnet build

ENTRYPOINT ["dotnet", "run", "--no-launch-profile"]