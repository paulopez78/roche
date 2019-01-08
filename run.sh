rm -rf ./build-linux
dotnet publish VotingApp.Api -r linux-x64 -o ../build-linux
docker build -f Dockerfile -t ubuntu-netcore-deps .
docker rm -f $(docker ps -qa)
docker run \
    -p 8080:80 \
    -v /$(PWD)/build-linux:/app \
    ubuntu-netcore-deps 

#apt-get update && apt-get install libicu60 libssl1.0.0 -y
#docker commit containerId imageName