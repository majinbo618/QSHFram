using System.Collections.Generic;

public class Guild_Data
{
    public Guild_Info SelfGuildInfo { get; private set; }
    /// <summary>
    /// 职位名称--》等级 字典
    /// </summary>
    public Dictionary<string, byte> PositionLevelNameDict { get; private set; }
    /// <summary>
    /// 职位等级--》名称 字典
    /// </summary>
    public Dictionary<string, byte> PositionNameLevelDict { get; private set; }
    /// <summary>
    /// 工会玩家列表
    /// </summary>
    public List<Guild_PlayerInfo> PlayerList { get; private set; }

    /// <summary>
    /// 工会当前经验
    /// </summary>
    public string Exp { get; private set; }
    /// <summary>
    /// 工会会长id
    /// </summary>
    public long LeaderId { get; private set; }
    /// <summary>
    /// 当前等待审批的申请入会人员
    /// </summary>
    public List<IBasePlayerInfo> ApplyPlys { get; private set; }
    /// <summary>
    /// 工会日志信息
    /// </summary>
    public Guild_LogList LogTbl { get; private set; }
    /// <summary>
    /// 工会扩展信息
    /// </summary>
    public Guild_Extinfo Extinfo { get; private set; }
    /// <summary>
    /// 解散剩余时间
    /// </summary>
    public int DisbandTime { get; private set; }

}
