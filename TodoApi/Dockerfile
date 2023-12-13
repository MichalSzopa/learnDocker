# Run locally: docker run -p XXXX:80 yyyyyyyyyy
# XXXX is the host port, yyyyyyyyyy is the name of built image

# Build an docker image: docker buildx build -t learn-docker-backend .

# Use the official .NET SDK image as the build image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the .csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image as the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose port 80 for the API
EXPOSE 80

# Define the entry point for the application
ENTRYPOINT ["dotnet", "TodoApi.dll"]