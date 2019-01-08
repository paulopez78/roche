rm -rf ./build-linux
dotnet publish VotingApp.Api -r linux-x64 -o ../build-linux
docker run -it -v /$(PWD)/build-linux:/app ubuntu

#apt-get update && apt-get install libicu60 libssl1.0.0 -y