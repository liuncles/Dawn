namespace Dawn.Entities.Base
{
    public interface ICreated : ICreatedTime
    {
        int? CreatedId { get; }
        string CreatedBy { get; }
    }
    public interface ICreatedTime
    {
        DateTime? CreatedTime { get; }
    }
}
