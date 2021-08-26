using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QSH
{
    public class PathTools
    {

        /// <summary>
        /// 更新文件存放路径
        /// </summary>
        public static string UpdateFilePath
        {
            get
            {
                return Path.Combine(UpdateDirectory, AppConst.UpdateFileName);
            }
        }

        /// <summary>
        /// 更新文件存放的文件夹路径
        /// </summary>

        public static string UpdateDirectory
        {
            get
            {
                string updateDirectory = "";
                if (AppConst.UpdateMode)
                {
                    updateDirectory = "file://" + Path.Combine(PersistentDataPath, AppConst.AppName);
                }
                else
                {
                    updateDirectory = "file://" + Path.Combine(AppStreamingPath, AppConst.AppName);
                }
                return updateDirectory;
            }
        }

        public static string TempUpdateDirectory
        {
            get
            {
                string tempDirectoryPath = "";
                if (AppConst.UpdateMode)
                {
                    tempDirectoryPath = "file://" + Path.Combine(PersistentDataPath, AppConst.AppName + "_temp");
                }
                else
                {
                    tempDirectoryPath = "file://" + Path.Combine(AppStreamingPath, AppConst.AppName + "_temp");
                }
                return tempDirectoryPath;
            }
        }

        public static string PersistentDataPath
        {
            get
            {
                return Application.persistentDataPath;
            }
        }

        /// <summary>
        /// 应用程序资源路径
        /// </summary>
        public static string AppStreamingPath
        {
            get
            {
                if (Application.platform == RuntimePlatform.IPhonePlayer)
                {
                    return Application.streamingAssetsPath;
                }
                else if (Application.platform == RuntimePlatform.Android)
                {
                    return Application.streamingAssetsPath;
                }
                else if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                {
                    return Application.streamingAssetsPath;
                }
                else if (Application.platform == RuntimePlatform.OSXEditor)
                {
                    return Application.streamingAssetsPath;
                }
                return "c:/";
            }
        }

        public static void DeleteAndRecreate(string path, bool isRecreate)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            if(isRecreate)
            {
                 Directory.CreateDirectory(path);
            }
        }


    }

}
