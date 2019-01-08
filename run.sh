docker-compose down
docker-compose up --build -d

sleep 5
set -e
docker-compose run --rm votingapp-test
docker-compose push votingapp

kubectl apply -f ./k8s/votingapp