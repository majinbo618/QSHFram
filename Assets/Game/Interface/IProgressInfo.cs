using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IProgressInfo
{
    /// <summary>
    /// 当前进度
    /// </summary>
    public int curProgress { get; }
    /// <summary>
    /// 总进度
    /// </summary>
    public int TotalProgress { get; }
    /// <summary>
    /// 完成时间 (0:未完成)
    /// </summary>
    public uint Cmplttime { get; }
}

