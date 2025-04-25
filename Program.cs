using MassTransit;
using MessagingDemo.Consumers;
using MessagingDemo.Contracts;
using MessagingDemo.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var app = builder.Build();

app.MapPost("/message", async (MessageDto message, IPublishEndpoint publishEndpoint) =>
{
    await publishEndpoint.Publish<IMessage>(new { message.Text });
    return Results.Ok("Message sent");
}).WithName("SendMessage");

app.Run();