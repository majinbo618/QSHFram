#if ENABLE_NGUI

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class QshFindPanel
{

    [MenuItem("QshTool/ClearPref")]
    static public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }


    [MenuItem("QshTool/FindPanel")]
    static public void OpenAtlasMaker()
    {
        EditorWindow.GetWindow<QshFindPanelWindow>(false, "查找修改pannel层级", true).Show();
    }


    //[MenuItem("QshTool/FindAllHaveMaskPrefabInUipanel")]
    static public void FindAllHaveMaskPrefabInUipanel()
    {
        GameObject[] gameObjects = Selection.gameObjects;
        Transform find = null;
        List<string> nameList = new List<string>();
        for (int index = 0; index < gameObjects.Length; index++)
        {
            find = gameObjects[index].transform.Find("mask");
            if(find != null)
            {
                nameList.Add(gameObjects[index].name);
                continue;
            }

            find = gameObjects[index].transform.Find("Mask");
            if (find != null)
            {
                nameList.Add(gameObjects[index].name);
                continue;
            }

        }
        nameList.Sort();
        for (int index = 0; index < nameList.Count; index++)
        {
            Debug.Log("Name:" + nameList[index]);
        }

    }

    [MenuItem("QshTool/FindObjectBySpriteName")]
    public static void FindObjectBySpriteName()
    {
        EditorWindow.GetWindow<QshFindFindObjectByGUID>(false, "查找修改图片名对象", true).Show();
    }



}

#endif