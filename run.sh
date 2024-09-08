git clone https://github.com/chupino/consumerkafka.git consumer
cd consumer

docker build -t consumer .

if [ $? -eq 0 ]; then
    echo "todo bien"
else
    echo "mal"
    exit 1
fi

docker run -d consumer