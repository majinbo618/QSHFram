using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Game.Achieve
{

    interface IQuest
    {
        public int Qid { get; }
        public byte Qtype { get; }
        public int Prog { get; }        //最大进度
        public int ProgMax { get; }        //最大进度
        public uint Cmplttime { get; }  // 完成时间 (0:未完成)
    }

    interface IMission
    {
        public int ID { get; }  //本阶段生存任务的Id

        public int SurvPhase { get; }   //生存任务阶段

        public int SurvLevel { get; }     //生存等级  主线任务第多少步
    }

    class Achieve_Progress_info: IProgresInfo
    {
        public byte Achvtype { get; set; } = 0; // 子成就类型
        public int Pt { get; set; } = 0; // 成就点

        public List<IReward> Rewards { get; set; }  // 进度奖励
        public List<IProgresInfo> SubAchvs; // 子成就信息
        public List<IQuest> SubQuest; // 子任务信息
    }


    class Achieve_Sub_Progress_info
    {
        public byte Achvtype; // 子成就类型
        public int Pt = 0; // 子成就点
        public List<AchvReward> Rewards;  // 子进度奖励
        public List<AchvQuest> Quests; // 子任务
    }

    class AchvQuest
    {
        public int Qid; // 子成就类型
        public int Prog = 0; // 子成就点
        public int Progcap; // 子任务
        public uint Cmplttime;  // 子进度奖励
    }

    class AchvReward
    {
        public int Rtype = 0; // 奖励类型[0:总成就奖励   1:子成就奖励]
        public int Rid = 0; // achvreward表的id
        public uint Cmplttime = 0;  // 奖励时间
        public int Recvstte = 0;  // 领取状态 [0:未领取  1:领取]
    }


}
