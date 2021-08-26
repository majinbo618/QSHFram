public interface IDragonInfo
{
    /// <summary>
    /// 龙的静态id——ExclId
    /// </summary>
    public uint PetExclId { get; }
    /// <summary>
    /// 龙的昵称
    /// </summary>
    public string PetName { get; }
    /// <summary>
    /// 龙的属性
    /// </summary>
    public PetAttrs PetAttrs { get; }

}

public struct PetAttrs
{
    public byte Level { get; }
}
