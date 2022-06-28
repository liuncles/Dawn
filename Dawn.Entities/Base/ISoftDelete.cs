namespace Dawn.Entities.Base
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
        void SoftDelete();
    }
}
