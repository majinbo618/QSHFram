public class Friend_PlayerInfo : Base_PlayerInfo
{
    /// <summary>
    /// 亲密度
    /// </summary>
    public uint Intimacy { get; private set; }
    /// <summary>
    /// 当前所在地图
    /// </summary>
    public uint MapId { get; private set; }
    /// <summary>
    /// 是否可接受其他玩家赠送
    /// </summary>
    public bool Sendable { get; private set; }
    /// <summary>
    /// 是否可领取该好友赠送的碎片
    /// 0 已赠送给自己  
    /// 1 还未已赠送给自己  
    /// 2 已经领取
    /// </summary>
    public byte Recvable { get; private set; }
}

