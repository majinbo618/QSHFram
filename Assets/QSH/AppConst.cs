using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSH
{
    public enum LOGLEVEL
    {
        LOGLEVEL_Log,
        LOGLEVEL_Warning,
        LOGLEVEL_Error,
        LOGLEVEL_Exception,
    }

    public class AppConst
    {
        public static bool DebugMode = true;                        //调试模式-用于内部测试   
        public static bool UpdateMode = false;                      //更新模式-默认关闭 
        public static bool UseResource = true;
        public static LOGLEVEL LogLevel = LOGLEVEL.LOGLEVEL_Log;    
        public const int TimerInterval = 1;
        public const int GameFrameRate = 60;                       //游戏帧频 
        public const string AppName = "WOW";               //应用程序名称
        public const string UpdateFileName = "hotFix";
        public const string ChannelName = "chanel";


        

    }
}
