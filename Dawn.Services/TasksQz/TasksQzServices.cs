using Dawn.Entities.TasksQz;
using Dawn.IServices;

namespace Dawn.Services
{
    /// <summary>
    /// 任务计划服务
    /// </summary>
    public partial class TasksQzServices : ServicesBase<TasksQz>, ITasksQzServices
    {
        IRepositoryBase<TasksQz> _dal;
        public TasksQzServices(IRepositoryBase<TasksQz> dal)
        {
            this._dal = dal;
            base._iRepositoryBase = dal;
        }
    }
}
