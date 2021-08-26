public class Guild_PlayerInfo : Base_PlayerInfo
{
    /// <summary>
    /// 工会中的职位等级
    /// 如：会长 1  副会长 2  精英3  .... 
    /// </summary>
    public byte Guild_PositionLevel { get; private set; }
    /// <summary>
    /// 声望等级
    /// </summary>
    public byte Guild_PrestigeLevel { get; private set; }
    /// <summary>
    /// 总贡献度
    /// </summary>
    public uint Guild_TotalContribute { get; private set; }
    /// <summary>
    /// 当前工会积分（可根据贡献度等发放）
    /// </summary>
    public uint Guild_CurFractions { get; private set; }
}