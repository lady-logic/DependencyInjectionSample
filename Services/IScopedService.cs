namespace sample.Services;

public interface IScopedService
{
    Guid GetOperationId();
}

public class ScopedService : IScopedService
{
    private readonly Guid _operationId = Guid.NewGuid();

    public Guid GetOperationId()
    {
        return _operationId;
    }
}