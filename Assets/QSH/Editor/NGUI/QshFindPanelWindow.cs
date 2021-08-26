#if ENABLE_NGUI

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QshFindPanelWindow : EditorWindow
{
    private Transform[] findArr = null;
    private Vector2 scrollPosition = Vector2.zero;
    private bool isChanged = false;
    private List<int> removeList = new List<int>();
    private void OnGUI()
    {
        EditorGUILayout.Space();
        if (GUILayout.Button("查找编辑器中选择对象的panenl"))
        {
            findArr = Selection.GetTransforms(SelectionMode.TopLevel);
        }

        scrollPosition = EditorGUILayout.BeginScrollView(
            scrollPosition, GUILayout.Width(500), GUILayout.Height(600));


        if (findArr != null)
        {

            for (int i = 0; i < findArr.Length; i++)
            {
                if (findArr[i] == null || findArr[i].gameObject == null)
                {
                    removeList.Add(i);
                }
                else
                {
                    ShowGUI(findArr[i]);
                }
            }
            for (int i = removeList.Count - 1; i >= 0; i--)
            {
                findArr[removeList[i]] = null;
            }
            removeList.Clear();
        }

        EditorGUILayout.EndScrollView();
        if (isChanged)
        {
            isChanged = false;
            AssetDatabase.SaveAssets();
        }

    }

    private void ShowGUI(Transform trans)
    {
        if (trans == null)
            return;
        EditorGUILayout.Space();
        UIPanel[] childrens = trans.GetComponentsInChildren<UIPanel>(true);

        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button(trans.name))
            {
                Selection.activeObject = trans;
            }

            if (GUILayout.Button("修改(暂不支持)"))  //按顺序递增在原基础上递增（若小于前面pannel 则在）
            {
                int mindepth = 1;
                if (childrens.Length >= 1)
                    Debug.Log("=============== 界面 =============== " + trans.name);
                for (int index = 0; index < childrens.Length; index++)
                {
                    if (mindepth < childrens[index].depth)
                        mindepth = childrens[index].depth;
                    else
                    {
                        childrens[index].depth = ++mindepth;
                        EditorUtility.SetDirty(childrens[index]);
                    }
                    Debug.Log("  panelName: " + childrens[index].name + "   depth: " + childrens[index].depth);
                }
            }
        }
        GUILayout.EndHorizontal();


        for (int i = 0; i < childrens.Length; i++)
        {
            EditorGUILayout.BeginHorizontal();
            {
                EditorGUILayout.ObjectField(childrens[i].name, childrens[i], typeof(Transform), true);
                int old = childrens[i].depth;
                childrens[i].depth = EditorGUILayout.DelayedIntField("Depth:", childrens[i].depth);
                if (old != childrens[i].depth)
                {
                    EditorUtility.SetDirty(childrens[i]);
                    isChanged = true;
                }
                EditorUtility.IsPersistent(childrens[i]);

            }
            EditorGUILayout.EndHorizontal();
        }
    }


}

#endif