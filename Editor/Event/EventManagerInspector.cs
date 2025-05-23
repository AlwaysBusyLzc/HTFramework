﻿using UnityEditor;
using UnityEngine;

namespace HT.Framework
{
    [CustomEditor(typeof(EventManager))]
    [GiteeURL("https://gitee.com/SaiTingHu/HTFramework")]
    [GithubURL("https://github.com/SaiTingHu/HTFramework")]
    [CSDNBlogURL("https://wanderer.blog.csdn.net/article/details/85689865")]
    internal sealed class EventManagerInspector : InternalModuleInspector<EventManager, IEventHelper>
    {
        private bool _isShowEvent = false;

        protected override void OnInspectorRuntimeGUI()
        {
            base.OnInspectorRuntimeGUI();

            if (_helper == null)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("No Runtime Data!");
                GUILayout.EndHorizontal();
                return;
            }

            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            _isShowEvent = EditorGUILayout.Foldout(_isShowEvent, $"Event List: {_helper.EventHandlerList.Count}", true);
            GUILayout.EndHorizontal();

            if (_isShowEvent)
            {
                foreach (var item in _helper.EventHandlerList)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Space(20);
                    GUILayout.Label(item.Key.Name);
                    GUILayout.FlexibleSpace();
                    GUI.enabled = item.Value != null;
                    if (GUILayout.Button("Throw", GUILayout.Width(50)))
                    {
                        Target.Throw(item.Key);
                    }
                    GUI.enabled = true;
                    GUILayout.EndHorizontal();
                }
            }
        }
    }
}