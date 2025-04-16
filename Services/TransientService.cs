namespace sample.Services;

public interface ITransientService
{
    Guid GetOperationId();
}

public class TransientService : ITransientService
{
    private readonly Guid _operationId = Guid.NewGuid();
    
    public Guid GetOperationId()
    {
        return _operationId;
    }
}