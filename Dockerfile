FROM microsoft/dotnet:sdk AS builder
COPY . .
RUN dotnet test VotingApp.Tests
RUN dotnet publish VotingApp.Api -o /build
####################################################
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=builder /build .
ENTRYPOINT [ "dotnet", "VotingApp.Api.dll"]