using Dawn.Entities;
using Dawn.Entities.Dto.TasksQz;
using Dawn.Entities.TasksQz;

namespace Dawn.Tasks.QuartzNet
{
    /// <summary>
    /// 任务调度管理中心
    /// 接口
    /// </summary>
    public interface ISchedulerCenterServer
    {
        /// <summary>
        /// 开启任务调度
        /// </summary>
        /// <returns></returns>
        Task<MsgEntity<string>> StartScheduleAsync();

        /// <summary>
        /// 停止任务调度
        /// </summary>
        /// <returns></returns>
        Task<MsgEntity<string>> StopScheduleAsync();

        /// <summary>
        /// 添加计划任务
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<MsgEntity<string>> AddScheduleJobAsync(TasksQz sysSchedule);

        /// <summary>
        /// 停止一个任务
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<MsgEntity<string>> StopScheduleJobAsync(TasksQz sysSchedule);

        /// <summary>
        /// 检测任务是否存在
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<bool> IsExistScheduleJobAsync(TasksQz sysSchedule);

        /// <summary>
        /// 暂停指定的计划任务
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<MsgEntity<string>> PauseJob(TasksQz sysSchedule);

        /// <summary>
        /// 恢复一个任务
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<MsgEntity<string>> ResumeJob(TasksQz sysSchedule);

        /// <summary>
        /// 获取任务触发器状态
        /// </summary>
        /// <param name="sysSchedule"></param>
        /// <returns></returns>
        Task<List<TaskInfoDto>> GetTaskStaus(TasksQz sysSchedule);

        /// <summary>
        /// 获取触发器标识
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetTriggerState(string key);

        /// <summary>
        /// 立即执行 一个任务
        /// </summary>
        /// <param name="tasksQz"></param>
        /// <returns></returns>
        Task<MsgEntity<string>> ExecuteJobAsync(TasksQz tasksQz);
    }
}
