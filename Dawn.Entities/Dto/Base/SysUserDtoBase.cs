namespace Dawn.Entities.Dto.Base
{
    public class SysUserDtoBase<Tkey> where Tkey : IEquatable<Tkey>
    {
        public Tkey UserId { get; set; }

        public List<Tkey> RoleIds { get; set; }
    }
}
