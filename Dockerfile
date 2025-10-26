FROM mcr.microsoft.com/dotnet/sdk:8.0 as builder

WORKDIR /app

# Copy ServUO source
COPY ServUO ./ServUO

WORKDIR /app/ServUO

# Build ServUO
RUN dotnet build -c Release

# Runtime image
FROM mcr.microsoft.com/dotnet/runtime:8.0

WORKDIR /app

COPY --from=builder /app/ServUO/bin/Release ./

# Create necessary directories
RUN mkdir -p /app/Saves /app/Data /app/Logs

# UO Server ports
EXPOSE 2593

# Start Server
CMD ["dotnet", "Server.dll"]
