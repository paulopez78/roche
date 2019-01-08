FROM ubuntu

RUN apt-get update && apt-get install libicu60 libssl1.0.0 -y
ENV ASPNETCORE_URLS=http://+:80
WORKDIR /app
ENTRYPOINT [ "bash", "-c", "./VotingApp.Api"]