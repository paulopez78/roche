FROM microsoft/dotnet:sdk AS builder

COPY ./VotingApp.Api/VotingApp.Api.csproj ./VotingApp.Api
COPY ./VotingApp.Lib/VotingApp.Lib.csproj ./VotingApp.Lib
COPY ./VotingApp.Tests/VotingApp.Tests.csproj ./VotingApp.Tests

RUN dotnet restore VotingApp.Api
RUN dotnet restore VotingApp.Tests

COPY . .
RUN dotnet test VotingApp.Tests
RUN dotnet publish VotingApp.Api -o /build

####################################################
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=builder /build .
ENTRYPOINT [ "dotnet", "VotingApp.Api.dll"]