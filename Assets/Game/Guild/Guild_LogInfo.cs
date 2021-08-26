using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Guild_LogInfo
{
    public ulong Logid { get; private set; }
    /// <summary>
    /// 产生时间
    /// </summary>
    public ulong OccTime { get; private set; }
    /// <summary>
    /// 日志类型
    /// </summary>
    public GuildLogType Gltype { get; private set; }
    /// <summary>
    /// 根据Gltype取参数
    /// </summary>
    public object[] Params { get; private set; }

    public void test(params object[] arrgs)
    {

    }

    public override string ToString()
    {
        if (Gltype == GuildLogType.Glt_Create)
            return string.Format("", Params[1]);
        else if (Gltype == GuildLogType.Glt_Join)
            return string.Format("", Params[1]);
        else if (Gltype == GuildLogType.Glt_Leave)
            return string.Format("", Params[1]);
        else if (Gltype == GuildLogType.Glt_Addexp)
            return string.Format("", Params[1], Params[2]);
        else if (Gltype == GuildLogType.Glt_Appoint)
            return string.Format("", Params[1], Params[2], Params[3]);
        else if (Gltype == GuildLogType.Glt_Activite)
            return string.Format("", Params[1], Params[2]);
        else if (Gltype == GuildLogType.Glt_Build)
            return string.Format("", Params[1]);
        else if (Gltype == GuildLogType.Glt_UpBuild)
            return string.Format("", Params[1], Params[2]);
        else if (Gltype == GuildLogType.Glt_UpGuild)
            return string.Format("", Params[1]);
        else if (Gltype == GuildLogType.Glt_MdfName)
            return string.Format("", Params[1], Params[2]);
        else if (Gltype == GuildLogType.Glt_MdfEmblem)
            return string.Format("", Params[1], Params[2]);
        else if (Gltype == GuildLogType.Glt_Kick)
            return string.Format("", Params[1], Params[2]);
        else
            return "";
    }
}

public enum GuildLogType : byte
{
    /// <summary>
    /// //创建   			参数(string:plynick)  								Exp: plynick 创建了公会
    /// </summary>
    Glt_Create = 0,
    /// <summary>
    ///  //加入				参数(string:plynick)								Exp: plynick 加入了公会
    /// </summary>
    Glt_Join = 1,
    /// <summary>
    ///  //退出				参数(string:plynick)								Exp: plynick 退出了公会
    /// </summary>
    Glt_Leave = 2,
    /// <summary>
    ///  //产生公会经验		参数(string:plynick, int32:addexp)					Exp: plynick 加了 addexp 公会经验
    /// </summary>
    Glt_Addexp = 3,
    /// <summary>
    /// //职位修改			参数(string:plynick1, string:plynick2, int32:pos)   Exp: plynick1 被 plynick2修改为pos
    /// </summary>
    Glt_Appoint = 4,
    /// <summary>
    ///  //活动开启			参数(string:plynick,  int32:actid)   				Exp: plynick 开启了 actid 活动
    /// </summary>
    Glt_Activite = 5,
    /// <summary>
    /// //建筑建造完成		参数(int32:builid)   								Exp: buildid 建造完成
    /// </summary>
    Glt_Build = 6,
    /// <summary>
    ///  //建筑升级			参数(int32:builid, int32:newlevel)   				Exp: buildid 升级为newlevel
    /// </summary>
    Glt_UpBuild = 7,
    /// <summary>
    ///  //公会升级			参数(int32:newlevel)   								Exp: 公会升级为newlevel
    /// </summary>
    Glt_UpGuild = 8,
    /// <summary>
    ///  //公会名字变更		参数(string:plynick, string:newname)   				Exp: plynick修改公会名为newname
    /// </summary>
    Glt_MdfName = 9,
    /// <summary>
    ///  //公会徽章变更		参数(string:plynick, int32:emblemid)   				Exp: plynick修改公会徽章为emblemid
    /// </summary>
    Glt_MdfEmblem = 10,
    /// <summary>
    ///  //被踢出公会		参数(string:plynick1, string:plynick2)   			Exp: plynick1 被 plynick2踢出了公会 
    /// </summary>
    Glt_Kick = 11,
}

