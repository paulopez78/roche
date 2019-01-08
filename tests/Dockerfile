FROM ubuntu
RUN apt-get update && apt-get install curl jq -y

COPY test.sh .
ENTRYPOINT ["bash", "-c", "./test.sh"]
