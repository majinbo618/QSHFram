public interface IBasePlayerInfo
{
    /// <summary>
    /// 玩家数据库id
    /// </summary>
    public long PlayerDBid { get;}
    /// <summary>
    /// 玩家昵称
    /// </summary>
    public string NickName { get;}
    /// <summary>
    /// 游戏头像id
    /// </summary>
    public byte HeadId { get;}
    /// <summary>
    /// 游戏头像边框
    /// </summary>
    public byte HeadBox { get;}
    /// <summary>
    /// 平台头像MD5
    /// </summary>
    public string PlatformHead { get;}
    /// <summary>
    /// 人物等级
    /// </summary>
    public byte RoleLevel { get;}
    /// <summary>
    /// 上一次在线时间，(1<<32)-1表示当前在线，其他值表示最后在线时间
    /// </summary>
    public uint LastOnline { get;}

}