#if ENABLE_NGUI
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class QshFindFindObjectByGUID : EditorWindow
{
    private string spriteName = "";
    private Transform[] findArr = null;

    private string path = "";
    private string guid = "";

    private void OnGUI()
    {

        guid = EditorGUILayout.TextField("guid:", guid);
        path = AssetDatabase.GUIDToAssetPath(guid);
        EditorGUILayout.TextField("path:", path);

        EditorGUILayout.Space();

        if (findArr != null)
        {
            for (int i = 0; i < findArr.Length; i++)
            {
                if (findArr[i] == null || findArr[i].gameObject == null)
                {
                    continue;
                }
                else
                {
                    ShowGUI(findArr[i]);
                }
            }
        }

        spriteName = EditorGUILayout.TextField("spriteName:", spriteName);
        if (GUILayout.Button("查找"))  //按顺序递增在原基础上递增（若小于前面pannel 则在）
        {
            findArr = Selection.GetTransforms(SelectionMode.TopLevel);
        } 

        
    }
    private void ShowGUI(Transform trans)
    {
        if (trans == null || spriteName == "")
            return;
        EditorGUILayout.Space();
        UISprite[] childrens = trans.GetComponentsInChildren<UISprite>(true);
        List<Transform> list = new List<Transform>();
        for (int index = 0; index < childrens.Length; index++)
        {
            if(childrens[index].spriteName == spriteName)
            {
                list.Add(childrens[index].transform);
            }
        }
        for (int i = 0; i < list.Count; i++)
        {
            EditorGUILayout.ObjectField("UISprite", list[i], typeof(Transform), true);
        }

        UIButton[] buttonChildrens = trans.GetComponentsInChildren<UIButton>(true);
        list = new List<Transform>();
        for (int index = 0; index < buttonChildrens.Length; index++)
        {
            if (buttonChildrens[index].disabledSprite == spriteName || buttonChildrens[index].normalSprite == spriteName || buttonChildrens[index].pressedSprite == spriteName || buttonChildrens[index].hoverSprite == spriteName)
            {
                list.Add(buttonChildrens[index].transform);
            }
        }

        for (int i = 0; i < list.Count; i++)
        {
            EditorGUILayout.ObjectField("UIButton", list[i], typeof(Transform), true);
        }



    }

   


}
#endif