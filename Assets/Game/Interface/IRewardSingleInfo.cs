using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IRewardSingleInfo
{
    /// <summary>
    /// 物品Id
    /// </summary>
    public IThingInfo ThingInfo { get;}
    /// <summary>
    /// 数量
    /// </summary>
    public uint Num { get;}
    /// <summary>
    /// 持续时间
    /// </summary>
    public int Time { get;}
}
