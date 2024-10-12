ARG DOCKER_IMAGE=mcr.microsoft.com/dotnet/sdk:8.0

# Use the .NET SDK image to build the project
FROM $DOCKER_IMAGE AS build
WORKDIR /src

# Install Git
RUN apt-get update && apt-get install -y git

# Clone git repository
ARG REPO_URL=https://github.com/schernev/live-pricing-tool.git
RUN git clone $REPO_URL .

# Verify the directory structure
RUN ls -la /src && echo "Directory structure listed above"

# Pause for debugging purposes
#RUN sleep 6

# Restore dependencies for the Server.WS project
WORKDIR /src/PricingToolServer/Server.WS
RUN dotnet restore "Server.WS.csproj"

# Build and publish the project
WORKDIR /src/PricingToolServer
RUN dotnet publish "Server.WS/Server.WS.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the ASP.NET runtime image for the final stage
FROM $DOCKER_IMAGE AS final
WORKDIR /app
#ENV ASPNETCORE_URLS=http://+:8888
EXPOSE 8888

# Copy the published output from the build stage
COPY --from=build /app/publish .

# Set the entry point to run the application
ENTRYPOINT ["dotnet", "Server.WS.dll"]