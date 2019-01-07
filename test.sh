#!/bin/bash
url=${API_URL:-"http://localhost:5000/api/voting"}
curl  --url $url --request POST --silent --Header "Content-Type: application/json" --data "['c#', 'java']"
curl  --url $url --request PUT --silent --Header "Content-Type: application/json" --data "'java'"
winner=$(curl  --url $url --request DELETE --silent --Header "Content-Type: application/json" | jq -r '.winner')

echo "and the winner is" $winner
if [ "$winner" = "java" ]; then
    echo "test passed!"
    exit 0
else
    echo "test failed!"
    exit 1
fi