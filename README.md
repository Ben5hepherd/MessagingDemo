1. MassTransit serializes the message (e.g. { Text: "Hello, World!" }).
2. It publishes the message to RabbitMQ’s exchange that corresponds to the message type IMessage.
3. RabbitMQ routes that message to any bound queues (e.g. the one for MessageConsumer).
4. The registered MessageConsumer listens on that queue and automatically receives and processes the message.
5. Once processed, the message is acknowledged and removed from the queue.

Note:
This command can be used to set up the RabbitMQ application on a locally running Docker instance:
docker run -d --hostname rabbitmq --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:4-management
