using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public interface ILogger
{
    public void WriteLog(LoggerOperation operation, BaseMessage? message, bool isSuccess);
    public IEnumerable<LoggerResult> GetLog();
    public void ClearLog();
}