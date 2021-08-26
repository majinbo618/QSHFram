using System.Collections.Generic;

public class Guild_Info
{
    /// <summary>
    /// 工会id
    /// </summary>
    public long Guildid { get; private set; }
    /// <summary>
    /// 工会等级
    /// </summary>
    public byte Level { get; private set; }
    /// <summary>
    /// 工会名字
    /// </summary>
    public string Guildname { get; private set; }
    /// <summary>
    /// 工会徽章图标
    /// </summary>
    public byte EmblemIconId { get; private set; }
    /// <summary>
    /// 工会徽章背景
    /// </summary>
    public byte EmblemBgId { get; private set; }
    /// <summary>
    /// 最低入会角色等级
    /// </summary>
    public byte LimitLevel { get; private set; }

}