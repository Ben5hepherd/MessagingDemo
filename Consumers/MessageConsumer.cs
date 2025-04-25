using MassTransit;
using MessagingDemo.Contracts;

namespace MessagingDemo.Consumers
{
    public class MessageConsumer : IConsumer<IMessage>
    {
        public Task Consume(ConsumeContext<IMessage> context)
        {
            Console.WriteLine($"Received message: {context.Message.Text}");
            return Task.CompletedTask;
        }
    }
}
