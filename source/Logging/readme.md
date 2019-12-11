# DotNetCore.Logging

The package provides interface and classe for **logging**.

## ILogService

```cs
public interface ILogService
{
    void Debug(string message);

    void Debug(string message, object data);

    void Error(Exception exception);

    void Error(Exception exception, object data);

    void Error(string message);

    void Error(string message, object data);

    void Fatal(Exception exception);

    void Fatal(Exception exception, object data);

    void Information(string message);

    void Information(string message, object data);

    void Warning(string message);

    void Warning(string message, object data);
}
```

## LogService

The **LogService** class uses the **Serilog** package. It reads the settings from the **AppSettings.json** file.

```cs
public class LogService : ILogService
{
    public LogService(IConfiguration configuration) { }

    public void Debug(string message) { }

    public void Debug(string message, object data) { }

    public void Error(Exception exception) { }

    public void Error(Exception exception, object data) { }

    public void Error(string message) { }

    public void Error(string message, object data) { }

    public void Fatal(Exception exception) { }

    public void Fatal(Exception exception, object data) { }

    public void Information(string message) { }

    public void Information(string message, object data) { }

    public void Warning(string message) { }

    public void Warning(string message, object data) { }
}
```
