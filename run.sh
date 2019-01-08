rm -rf ./build-linux
dotnet publish VotingApp.Api -r linux-x64 -o ../build-linux
docker run -it -p 8080:5000 -v /$(PWD)/build-linux:/app ubuntu-dotnet-deps

#apt-get update && apt-get install libicu60 libssl1.0.0 -y
#docker commit containerId imageName