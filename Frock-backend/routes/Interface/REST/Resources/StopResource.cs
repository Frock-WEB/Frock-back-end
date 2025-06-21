namespace Frock_backend.routes.Interface.REST.Resources
{
    public record StopResource
    (
        int id, // The unique identifier for the stop
        string name, // The name of the stop
        string address
    );
}
