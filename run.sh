rm -rf ./build
docker build -f Dockerfile -t paulopez/votingapp .
docker rm -f myvotingapp
docker run \
    -d \
    --name myvotingapp \
    -p 8080:80 \
    paulopez/votingapp

sleep 5
set -e
./test.sh

docker push paulopez/votingapp

#apt-get update && apt-get install libicu60 libssl1.0.0 -y
#docker commit containerId imageName