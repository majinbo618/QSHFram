#if ENABLE_NGUI

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class QshFindUnusePngWindow
{
    private static IEnumerator curEnumerator;
    private static Dictionary<string, string[]> fileStrArrDict = new Dictionary<string, string[]>();


    [MenuItem("QshTool/查找未使用的资源/UI图片(除texture)")]
    static private void StartFindPng()
    {
        curEnumerator = FindAllUnusePng();
        EditorApplication.update += Update;
    }

    [MenuItem("QshTool/查找未使用的资源/texture文件夹")]
    static private void StartFindTexture()
    {
        curEnumerator = FindAllUnuseTexture();
        EditorApplication.update += Update;
    }

    static private void StopFind()
    {
        curEnumerator = null;
        EditorApplication.update -= Update;
        EditorUtility.ClearProgressBar();
        EditorUtility.DisplayDialog("查找未使用的资源", "查找完成", "确定");
    }


    private static void Update()
    {
        if (curEnumerator == null)
        {
            StopFind();
        }
        try
        {
            if (!curEnumerator.MoveNext())
            {
                StopFind();
            }
        }
        catch (System.Exception)
        {
            StopFind();
            throw;
        }

    }


    static public IEnumerator FindAllUnusePng()
    {
        string pngDirectoryPath = Path.Combine(Application.dataPath, @"Art\UI");
        string prefabDirectoryPath = Path.Combine(Application.dataPath, @"Resources\ui\uipanel");
        string luaDirectoryPath = Path.Combine(Application.dataPath, @"LuaFramework\Lua");
        DirectoryInfo pngDirectoryInfo = new DirectoryInfo(pngDirectoryPath);
        DirectoryInfo prefabDirectoryInfo = new DirectoryInfo(prefabDirectoryPath);
        DirectoryInfo luaDirectoryInfo = new DirectoryInfo(luaDirectoryPath);
        /// string[] files = Directory.GetFiles(curDirPath, "*.*", SearchOption.AllDirectories);  下一步的更改方案
        FileInfo[] prefabFileInfos = prefabDirectoryInfo.GetFiles("*", SearchOption.AllDirectories);
        prefabFileInfos = RemoveMeta(prefabFileInfos);
        FileInfo[] luaFileInfos = luaDirectoryInfo.GetFiles("*", SearchOption.AllDirectories);
        luaFileInfos = RemoveMeta(luaFileInfos);
        DirectoryInfo[] pngDirectoryArr = pngDirectoryInfo.GetDirectories();

        List<FileInfo> unusedList = new List<FileInfo>();

        string pngName = "";

        for (int directoryIndex = 0; directoryIndex < pngDirectoryArr.Length; directoryIndex++)
        {
            if (pngDirectoryArr[directoryIndex].Name.EndsWith("texture"))
                continue;
            FileInfo[] pngFileInfos = pngDirectoryArr[directoryIndex].GetFiles("*", SearchOption.AllDirectories);
            pngFileInfos = RemoveMeta(pngFileInfos);
            int len = pngFileInfos.Length;
            string pngDirectoryName = pngDirectoryArr[directoryIndex].FullName;
            for (int i = 0; i < len; i++)
            {
                EditorUtility.DisplayProgressBar(pngDirectoryName, pngFileInfos[i].Name, (float)i / len);
                if (!pngFileInfos[i].Name.EndsWith(".png"))
                    continue;
                pngName = pngFileInfos[i].Name.Replace(".png", "");
                if (IsUsedInFileArr(pngName, prefabFileInfos))
                {
                    continue;
                }
                if (IsUsedInFileArr(pngName, luaFileInfos))
                {
                    continue;
                }
                unusedList.Add(pngFileInfos[i]);
                Debug.Log("未使用:" + pngFileInfos[i].Name);
                yield return new WaitForFixedUpdate();
            }
        }

    }

    static private bool IsUsedInFileArr(string pngName, FileInfo[] fileInfos)
    {
        bool isIn = false;

        for (int i = 0; i < fileInfos.Length; i++)
        {
            if (IsUsedInFile(pngName, fileInfos[i].FullName))
            {
                isIn = true;
                break;
            }
        }
        return isIn;
    }

    static private bool IsUsedInFile(string pngName, string tagFilePath)
    {
        bool isIn = false;
        if (!fileStrArrDict.ContainsKey(tagFilePath))
        {
            fileStrArrDict[tagFilePath] = File.ReadAllLines(tagFilePath);
        }
        string[] tagStrArr = fileStrArrDict[tagFilePath];
        foreach (var lineStr in tagStrArr)
        {
            if (lineStr.Contains(pngName))
            {
                isIn = true;
                break;
            }
        }
        return isIn;
    }

    static public FileInfo[] RemoveMeta(FileInfo[] fileArr)
    {
        List<FileInfo> list = new List<FileInfo>();
        for (int i = 0; i < fileArr.Length; i++)
        {
            if (fileArr[i].Name.EndsWith(".meta"))
                continue;
            list.Add(fileArr[i]);
        }
        return list.ToArray();
    }

   
    static public IEnumerator FindAllUnuseTexture()
    {
        string pngDirectoryPath = Path.Combine(Application.dataPath, @"Resources\ui\uitexture");
        DirectoryInfo pngDirectoryInfo = new DirectoryInfo(pngDirectoryPath);
        FileInfo[] pngFileInfos = pngDirectoryInfo.GetFiles("*", SearchOption.AllDirectories);

        string prefabDirectoryPath = Path.Combine(Application.dataPath, @"Resources\ui\uipanel");
        string luaDirectoryPath = Path.Combine(Application.dataPath, @"LuaFramework\Lua");
        DirectoryInfo prefabDirectoryInfo = new DirectoryInfo(prefabDirectoryPath);
        DirectoryInfo luaDirectoryInfo = new DirectoryInfo(luaDirectoryPath);
        FileInfo[] prefabFileInfos = prefabDirectoryInfo.GetFiles("*", SearchOption.AllDirectories);
        prefabFileInfos = RemoveMeta(prefabFileInfos);
        FileInfo[] luaFileInfos = luaDirectoryInfo.GetFiles("*", SearchOption.AllDirectories);
        luaFileInfos = RemoveMeta(luaFileInfos);
        List<FileInfo> unusedList = new List<FileInfo>();

        pngFileInfos = RemoveMeta(pngFileInfos);
        for (int i = 0; i < pngFileInfos.Length; i++)
        {
            EditorUtility.DisplayProgressBar(pngDirectoryInfo.Name, pngFileInfos[i].Name, (float)i / pngFileInfos.Length);
            string assetPath = FormatPath(pngFileInfos[i].FullName);
            string guid = AssetDatabase.AssetPathToGUID(assetPath);
            if (IsUsedInFileArr(guid, prefabFileInfos))
            {
                Debug.Log(" ==== 预制件中用到 ======   " + pngFileInfos[i].Name+"  guid:"+ guid);
                continue;
            }
            string name = pngFileInfos[i].Name;

            name = name.Replace(".png", "");
            name = name.Replace(".jpg", "");
            name = name.Replace(".psd", "");
            name = Regex.Replace(name, @"\d*$", "");
            if (IsUsedInFileArr(name, luaFileInfos))
            {
                Debug.LogWarning(" .....   代码中有用 ..... " + name);
                continue;
            }
            unusedList.Add(pngFileInfos[i]);
            Debug.Log(name + " ____ 找到未使用图片 ____ " + pngFileInfos[i].Name);
            yield return new WaitForFixedUpdate();
        }
    }

    private static string FormatPath(string path)
    {
        path = path.Replace(@"\", "/");
        string dataPath = Application.dataPath.Replace(@"\", "/");
        return path.Replace(dataPath, "Assets");
    }


    /// <summary>
    /// 正则表达式替换字符串
    /// </summary>
    /// <param name="inputString">字符串内容</param>
    /// <param name="pattern">替换字符</param>
    /// <param name="replaceStr">替换值</param>
    /// <returns></returns>
    public static string RegexReplace(string inputString, string pattern, string replaceStr)
    {
        return Regex.Replace(inputString, pattern, replaceStr);
    }

}

#endif