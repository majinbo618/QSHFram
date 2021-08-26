using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IUseInfo
{
    /// <summary>
    /// 是否可以直接使用
    /// </summary>
    public bool IsCanUse { get; }
    /// <summary>
    /// 使用的最低角色等级限制  （大于等于该值可使用）
    /// </summary>
    public byte MinRoleLevalLimit { get; }
    /// <summary>
    /// 使用类型
    /// </summary>
    public byte UseType { get; }
}

