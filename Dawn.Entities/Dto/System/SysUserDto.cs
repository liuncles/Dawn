using Dawn.Entities.Dto.Base;

namespace Dawn.Entities.Dto.System
{
    /// <summary>
    /// 用户表Dto
    /// </summary>
    public class SysUserDto : SysUserDtoBase<int>
    {
        public Guid Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string? UserNick { get; set; }

        /// <summary>
        /// 性别（0未知，1男，2女）
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string? Portrait { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// 用户状态（0正常，1停用）
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        ///错误次数 
        /// </summary>
        public int ErrorCount { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime LastErrTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool? IsDeleted { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 角色名称集合
        /// </summary>
        public List<string>? RoleNames { get; set; }

        /// <summary>
        /// 机构名称集合
        /// </summary>
        public List<int>? Oids { get; set; }

        /// <summary>
        /// 机构名称
        /// </summary>
        public string? OrganizationName { get; set; }
    }
}
