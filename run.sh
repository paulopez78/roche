rm -rf ./build-linux
dotnet publish VotingApp.Api -r linux-x64 -o ../build-linux
docker run \
    -w //app \
    -p 8080:80 \
    -v /$(PWD)/build-linux:/app \
    -e ASPNETCORE_URLS=http://+:80 \
    ubuntu-dotnet-deps bash -c "./VotingApp.Api"

#apt-get update && apt-get install libicu60 libssl1.0.0 -y
#docker commit containerId imageName