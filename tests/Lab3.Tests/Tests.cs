using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.Display;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.User;
using Itmo.ObjectOrientedProgramming.Lab3.Addressee.User.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Message.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Messenger;
using Xunit;
using Xunit.Abstractions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Tests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void SendMessage()
    {
        // Arrange
        var name = new UserName("Vasiliy", "Vasiliev");
        var photo = new UserPhoto("c:/photos/photo.png");
        var date = new DateTime(2011, 04, 19);
        var user = new User(name, photo, date, MessageImportance.MiddlePriority, new List<UserMessage>());
        var adapter = new UserAdapter(user);
        var topic = new Topic.Topic("VItmo oop", adapter);

        var title = new MessageTitle("I have problem");
        var body = new MessageBody("How solve this task");
        var message = new UserMessage(title, body, MessageImportance.HighPriority, false);
        Logger.Logger.Instance.ClearLog();

        // Act
        topic.SendMassage(message);

        // Assert
        var exp = new UserMessage(title, body, MessageImportance.HighPriority, false);
        var expMessages = new List<UserMessage> { exp };
        Assert.Equal(expMessages, user.Messages);
    }

    [Fact]
    public void SendAndReadMessage()
    {
        // Arrange
        var name = new UserName("Vasiliy", "Vasiliev");
        var photo = new UserPhoto("c:/photos/photo.png");
        var date = new DateTime(2011, 04, 19);
        var user = new User(name, photo, date, MessageImportance.MiddlePriority, new List<UserMessage>());
        var adapter = new UserAdapter(user);

        var topic = new Topic.Topic("VItmo oop", adapter);

        var title = new MessageTitle("I have problem");
        var body = new MessageBody("How solve this task");
        var message = new UserMessage(title, body, MessageImportance.HighPriority, false);
        Logger.Logger.Instance.ClearLog();

        // Act
        topic.SendMassage(message);
        user.ReadMessage(message);

        // Assert
        var exp = new UserMessage(title, body, MessageImportance.HighPriority, true);
        var expMessages = new List<UserMessage> { exp };
        Assert.Equal(expMessages, user.Messages);
    }

    [Fact]
    public void SendAndReadReadMessage()
    {
        // Arrange
        var name = new UserName("Vasiliy", "Vasiliev");
        var photo = new UserPhoto("c:/photos/photo.png");
        var date = new DateTime(2011, 04, 19);
        var user = new User(name, photo, date, MessageImportance.MiddlePriority, new List<UserMessage>());
        var adapter = new UserAdapter(user);
        var topic = new Topic.Topic("VItmo oop", adapter);

        var title = new MessageTitle("I have problem");
        var body = new MessageBody("How solve this task");
        var message = new UserMessage(title, body, MessageImportance.HighPriority, false);
        Logger.Logger.Instance.ClearLog();

        // Act
        topic.SendMassage(message);
        user.ReadMessage(message);

        // Assert
        void Action() => user.ReadMessage(message);
        ArgumentException exception = Assert.Throws<ArgumentException>(Action);
        var exp = new ArgumentException("Message already is read");
        Assert.Equal(exp.Message, exception.Message);
    }

    [Fact]
    public void SendNoImportanceMessage()
    {
        // Arrange
        var name = new UserName("Vasiliy", "Vasiliev");
        var photo = new UserPhoto("c:/photos/photo.png");
        var date = new DateTime(2011, 04, 19);
        var user = new User(name, photo, date, MessageImportance.MiddlePriority, new List<UserMessage>());
        var adapter = new UserAdapter(user);

        var topic = new Topic.Topic("VItmo oop", adapter);

        var title = new MessageTitle("I have problem");
        var body = new MessageBody("How solve this task");
        var message = new UserMessage(title, body, MessageImportance.LowPriority, false);
        Logger.Logger.Instance.ClearLog();

        // Act
        topic.SendMassage(message);

        // Assert
        if (user.Messages != null)
            Assert.Empty(user.Messages);
    }

    [Fact]
    public void SendMessageAndSaveLogFile()
    {
        // Arrange
        var name = new UserName("Vasiliy", "Vasiliev");
        var photo = new UserPhoto("c:/photos/photo.png");
        var date = new DateTime(2011, 04, 19);
        var user = new User(name, photo, date, MessageImportance.MiddlePriority, new List<UserMessage>());
        var adapter = new UserAdapter(user);

        var topic = new Topic.Topic("VItmo oop", adapter);

        var title1 = new MessageTitle("I have problem");
        var body1 = new MessageBody("How solve this task");
        var message1 = new UserMessage(title1, body1, MessageImportance.HighPriority, false);
        Logger.Logger.Instance.ClearLog();

        // Act
        topic.SendMassage(message1);

        // Assert
        var file = Logger.Logger.Instance.GetLog().ToList();
        var exc = new List<LoggerResult>
        {
            new LoggerResult(LoggerOperation.Send, message1, true),
            new LoggerResult(LoggerOperation.Take, message1, true),
        };

        Assert.Equal(exc, file);
    }

    [Fact]
    public void SendToMessenger()
    {
        // Arrange
        var messenger = new Messenger.Messenger(new List<MessengerMessage>());
        var adapter = new MessengerAdapter(messenger);

        var topic = new Topic.Topic("VItmo oop", adapter);

        var title1 = new MessageTitle("I have problem");
        var body1 = new MessageBody("How solve this task");
        BaseMessage message1 = new UserMessage(title1, body1, MessageImportance.HighPriority, false);
        var title2 = new MessageTitle("I have problem v2");
        var body2 = new MessageBody("How solve this task v2");
        BaseMessage message2 = new UserMessage(title2, body2, MessageImportance.HighPriority, false);
        Logger.Logger.Instance.ClearLog();

        // Act
        topic.SendMassage(message1);
        topic.SendMassage(message2);

        // Assert
        IList<MessengerMessage>? expMessage = new List<MessengerMessage>()
        {
            new MessengerMessage(title1, body1, MessageImportance.HighPriority),
            new MessengerMessage(title2, body2, MessageImportance.HighPriority),
        };

        Assert.Equal(expMessage, messenger.Massages);
    }

    [Fact]
    public void DisplayDraw()
    {
        // Arrange
        var display = new Display(null, MessageImportance.MiddlePriority);
        var adapter = new DisplayAdapter(display);

        var topic = new Topic.Topic("VItmo oop", adapter);

        var title1 = new MessageTitle("Blue message");
        var body1 = new MessageBody("I am blue))");
        BaseMessage message = new DisplayMessage(title1, body1, MessageImportance.HighPriority, ConsoleColor.Blue);
        Logger.Logger.Instance.ClearLog();

        // Act
        topic.SendMassage(message);
        display.DrawMessage();

        // Assert
        Assert.Equal("Blue message\nI am blue))\nColor: Blue", display.Message?.ToString());
    }
}