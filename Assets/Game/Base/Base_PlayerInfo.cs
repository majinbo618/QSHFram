public class Base_PlayerInfo : IBasePlayerInfo
{
    /// <summary>
    /// 玩家数据库id
    /// </summary>
    public long PlayerDBid { get; private set;}
    /// <summary>
    /// 玩家昵称
    /// </summary>
    public string NickName { get; private set;}
    /// <summary>
    /// 游戏头像id
    /// </summary>
    public byte HeadId { get; private set;}
    /// <summary>
    /// 游戏头像边框
    /// </summary>
    public byte HeadBox { get; private set;}
    /// <summary>
    /// 平台头像MD5
    /// </summary>
    public string PlatformHead { get; private set;}
    /// <summary>
    /// 人物等级
    /// </summary>
    public byte RoleLevel { get; private set;}
    /// <summary>
    /// 上一次在线时间，(1<<32)-1表示当前在线，其他值表示最后在线时间
    /// </summary>
    public uint LastOnline { get; private set;}

}