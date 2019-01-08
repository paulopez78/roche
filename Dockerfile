FROM microsoft/dotnet:aspnetcore-runtime

WORKDIR /app
COPY build .
ENTRYPOINT [ "dotnet", "VotingApp.Api.dll"]