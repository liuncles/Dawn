namespace Dawn.Entities.Base
{
    public interface IModified : IModifiedTime
    {
        int? ModifiedId { get; }
        string ModifiedBy { get; }
    }
    public interface IModifiedTime
    {
        DateTime? ModifiedTime { get; }
    }
}
