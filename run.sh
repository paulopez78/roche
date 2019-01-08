rm -rf ./build
dotnet publish VotingApp.Api -o ../build
docker build -f Dockerfile -t paulopez/votingapp .
docker rm -f $(docker ps -qa)
docker run \
    -d \
    -p 8080:80 \
    paulopez/votingapp

sleep 5
./test.sh

docker push paulopez/votingapp

#apt-get update && apt-get install libicu60 libssl1.0.0 -y
#docker commit containerId imageName