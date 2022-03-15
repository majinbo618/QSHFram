using System.IO;
using UnityEngine;
using UnityEditor;
using LuaFramework;

public class PathConst
{

    private static string _projectRootPath = Directory.GetCurrentDirectory();
    /// <summary>
    /// 工程根目录
    /// </summary>
    public static string ProjectRootPath
    {
        get
        {
            return _projectRootPath;
        }
    }


    public static string StreamingAssetsPath
    {
        get
        {
#if UNITY_EDITOR
            return Application.streamingAssetsPath;
#else
             if(Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.WindowsPlayer)
             {
                 return "file://" + Application.streamingAssetsPath;
             }
            return Application.streamingAssetsPath;
#endif
        }
    }

    public static string PersistentDataPath
    {
        get
        {
#if UNITY_EDITOR
            return Application.persistentDataPath;
#else
             if(Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.WindowsPlayer)
             {
                 return "file://" + Application.persistentDataPath;
             }
            return Application.persistentDataPath;
#endif
        }
    }

    public const string BetterManifestName = "better.manifest";

    private static string _betterManifestPath = Combine(StreamingAssetsPath, BetterManifestName);
    ///更新文件路径
    public static string BetterManifestFullName
    {
        get
        {
            return _betterManifestPath;
        }
    }

    private static string _remoteLoadPath = Combine(PersistentDataPath, "download");
    /// <summary>
    /// 工程外资源加载地址
    /// </summary>
    public static string RemoteLoadPath
    {
        get
        {
            return _remoteLoadPath;
        }
    }

    private static string _runtimeLocalBetterManifestFullName = Combine(PersistentDataPath, BetterManifestName);

    public static string RuntimeLocalBetterManifestFullName
    {
        get
        {
            return _runtimeLocalBetterManifestFullName;
        }
    }



#if UNITY_EDITOR
    private static string _remoteBuildPath = Combine(ProjectRootPath, "ServerData");
    /// <summary>
    /// 工程外资源打包导出地址
    /// </summary>
    public static string RemoteBuildPath
    {
        get
        {
            return Combine(_remoteBuildPath, EditorUserBuildSettings.activeBuildTarget.ToString());
        }
    }

    public static string RemoteBuildBetterManifestFullName
    {
        get
        {
            return Combine(RemoteBuildPath, BetterManifestName);
        }
    }

#endif


    private static string _httpServerResRootPath = "http://192.168.8.128:81/";

    public static string HttpServerResRootPath
    {
        get
        {
            return _httpServerResRootPath;
        }
    }


    public static string Combine(params string[] paths)
    {
        string str = Path.Combine(paths).Replace("\\", "/");
        return str;
    }


}