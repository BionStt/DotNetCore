# DotNetCore.Objects

The package provides generic classes for **objects**.

## Entity

```cs
public abstract class Entity : IEquatable<Entity>
{
    public long Id { get; protected set; }

    public static bool operator !=(Entity a, Entity b) { }

    public static bool operator ==(Entity a, Entity b) { }

    public override bool Equals(object obj) { }

    public bool Equals(Entity other) { }

    public override int GetHashCode() { }
}
```

## Event

```cs
public abstract class Event
{
    public Guid Id { get; } = Guid.NewGuid();

    public DateTime DateTime { get; } = DateTime.UtcNow;
}
```

## ValueObject

```cs
public abstract class ValueObject
{
    public static bool operator !=(ValueObject a, ValueObject b) { }

    public static bool operator ==(ValueObject a, ValueObject b) { }

    public override bool Equals(object obj) { }

    public override int GetHashCode() { }

    protected abstract IEnumerable<object> GetEquals();
}
```

## BinaryFile

```cs
public class BinaryFile
{
    public BinaryFile(Guid id, string name, byte[] bytes, long length, string contentType) { }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public byte[] Bytes { get; private set; }

    public long Length { get; private set; }

    public string ContentType { get; private set; }

    public static async Task<BinaryFile> ReadAsync(string directory, Guid id) { }

    public async Task SaveAsync(string directory) { }
}
```

## BinaryFileExtensions

```cs
public static class BinaryFileExtensions
{
    public static async Task<IEnumerable<BinaryFile>> SaveAsync(this IEnumerable<BinaryFile> files, string directory) { }
}
```

## Order

```cs
public class Order
{
    public Order() { }

    public bool Ascending { get; set; }

    public string Property { get; set; }
}
```

## Page

```cs
public class Page
{
    public Page() { }

    public int Index { get; set; }

    public int Size { get; set; }
}
```

## PagedListParameters

```cs
public class PagedListParameters
{
    public Order Order { get; set; }

    public Page Page { get; set; }
}
```

## PagedList

The **PagedList\<T\>** class performs the sort and pagination logic, returning the total count and the paged list.

```cs
public class PagedList<T>
{
    public PagedList(IQueryable<T> queryable, PagedListParameters parameters) { }

    public long Count { get; }

    public IEnumerable<T> List { get; }
}
```

## IResult

```cs
public interface IResult
{
    bool Failed { get; }

    string Message { get; }

    bool Succeeded { get; }
}
```

## Result

```cs
public class Result : IResult
{
    protected Result() { }

    public bool Failed { get; protected set; }

    public string Message { get; protected set; }

    public bool Succeeded { get; protected set; }

    public static IResult Fail() { }

    public static IResult Fail(string message) { }

    public static IResult Success() { }

    public static IResult Success(string message) { }
}
```

## IDataResult

```cs
public interface IDataResult<out T> : IResult
{
    T Data { get; }
}
```

## DataResult

```cs
public class DataResult<T> : Result, IDataResult<T>
{
    protected DataResult() { }

    public T Data { get; protected set; }

    public static new IDataResult<T> Fail() { }

    public static new IDataResult<T> Fail(string message) { }

    public static new IDataResult<T> Success() { }

    public static new IDataResult<T> Success(string message) { }

    public static IDataResult<T> Success(T data) { }

    public static IDataResult<T> Success(T data, string message) { }
}
```
