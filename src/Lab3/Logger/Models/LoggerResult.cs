using System;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;

public class LoggerResult
{
    public LoggerResult(LoggerOperation operation, BaseMessage? message, bool isSuccess)
    {
        Operation = operation;
        Message = message;
        IsSuccess = isSuccess;
    }

    public LoggerOperation Operation { get; private init; }
    public BaseMessage? Message { get; private init; }
    public bool IsSuccess { get; private init; }

    public override bool Equals(object? obj)
    {
        var result = obj as LoggerResult;

        return Equals(result);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine((int)Operation, Message, IsSuccess);
    }

    private bool Equals(LoggerResult? other)
    {
        return other is not null &&
               Operation == other.Operation &&
               Equals(Message, other.Message) &&
               IsSuccess == other.IsSuccess;
    }
}