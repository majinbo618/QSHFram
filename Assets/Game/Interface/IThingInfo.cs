using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IThingInfo
{
    /// <summary>
    /// 物品id（道具，装备，货币，经验等 id不能重复）
    /// </summary>
    public uint Id { get; }
    /// <summary>
    /// 物品类型 （道具，装备，货币，经验等）
    /// </summary>
    public byte Type { get; }
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name { get; }
    /// <summary>
    /// 物品品质
    /// </summary>
    public string Quality { get; }
    /// <summary>
    /// 说明
    /// </summary>
    public string Desc { get; }
    /// <summary>
    /// 排序
    /// </summary>
    public string Sorting { get; }
    /// <summary>
    /// 物品图标名
    /// </summary>
    public string Icon { get; }
    /// <summary>
    /// 物品本身最大堆叠数
    /// </summary>
    public string NumMaxStacked { get; }

}

