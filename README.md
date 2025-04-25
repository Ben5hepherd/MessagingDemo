1. MassTransit serializes the message (e.g. { Text: "Hello, World!" }).
2. It publishes the message to RabbitMQ’s exchange that corresponds to the message type IMessage.
3. RabbitMQ routes that message to any bound queues (e.g. the one for MessageConsumer).
4. The registered MessageConsumer listens on that queue and automatically receives and processes the message.
5. Once processed, the message is acknowledged and removed from the queue.
