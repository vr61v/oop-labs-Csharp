using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Logger.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Logger;

public class Logger : ILogger
{
    private static Logger? _instance;
    private IList<LoggerResult> _log = new List<LoggerResult>();
    private Logger() { }

    public static Logger Instance
    {
        get
        {
            _instance ??= new Logger();
            return _instance;
        }
    }

    public void WriteLog(LoggerOperation operation, BaseMessage? message, bool isSuccess)
    {
        _log.Add(new LoggerResult(operation, message, isSuccess));
    }

    public IEnumerable<LoggerResult> GetLog()
    {
        return _log.AsReadOnly();
    }

    public void ClearLog()
    {
        _log.Clear();
    }
}