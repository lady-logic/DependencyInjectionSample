namespace sample.Services;

public interface ISingletonService
{
    Guid GetOperationId();
}

public class SingletonService : ISingletonService
{
    private readonly Guid _operationId = Guid.NewGuid();

    public Guid GetOperationId()
    {
       return _operationId;
    }
}