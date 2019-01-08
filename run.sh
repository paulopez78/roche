rm -rf ./build
docker network create myvotingnetwork
docker build -f ./VotingApp.Api/Dockerfile -t paulopez/votingapp .
docker rm -f myvotingapp
docker run \
    -d \
    --network myvotingnetwork \
    --name myvotingapp \
    -p 8080:80 \
    paulopez/votingapp

sleep 5
set -e

docker build -t votingapp-test ./tests
docker run --rm --network myvotingnetwork -e API_URL=http://myvotingapp/api/voting votingapp-test

docker push paulopez/votingapp

#apt-get update && apt-get install libicu60 libssl1.0.0 -y
#docker commit containerId imageName