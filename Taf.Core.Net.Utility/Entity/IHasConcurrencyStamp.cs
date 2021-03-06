// 何翔华
// Taf.Core.Net.Utility
// IHasConcurrencyStamp.cs

namespace Taf.Core.Net.Domain.Entities;

public interface IHasConcurrencyStamp{
    /// <summary>
    /// 更新锁,用于确保乐观锁 
    /// </summary>
    public string ConcurrencyStamp{ get; set; } 
}
