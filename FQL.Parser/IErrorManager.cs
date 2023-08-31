namespace FQL.Parser;

public interface IErrorManager
{
    void Add(FQLError error);
    void Remove(FQLError error);
    void Clear();
    void Show();
    bool HasErrors(FQLErrorSeverity fqlErrorSeverity);
}