using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Leskiv.EditorGuiElements
{
    public class BuiltInContentWindow : EditorWindow
    {
        private static class StylesFromAnimationWindow
        {
            public static GUIContent playContent = EditorGUIUtility.IconContent("Animation.Play");
            public static GUIContent recordContent = EditorGUIUtility.IconContent("Animation.Record");
            public static GUIContent prevKeyContent = EditorGUIUtility.IconContent("Animation.PrevKey");
            public static GUIContent nextKeyContent = EditorGUIUtility.IconContent("Animation.NextKey");
            public static GUIContent addKeyframeContent = EditorGUIUtility.IconContent("Animation.AddKeyframe");
            public static GUIContent addEventContent = EditorGUIUtility.IconContent("Animation.AddEvent");

            public static GUIStyle miniToolbar = new GUIStyle(EditorStyles.toolbar);
            public static GUIStyle miniToolbarButton = new GUIStyle(EditorStyles.toolbarButton);
            public static GUIStyle toolbarLabel = new GUIStyle(EditorStyles.toolbarPopup);

            static StylesFromAnimationWindow()
            {
                toolbarLabel.normal.background = null;
                miniToolbarButton.padding.top = 0;
                miniToolbarButton.padding.bottom = 3;
            }
        }

        private static class BuiltInStyles
        {
            public static GUIStyle box = "OL Box";
            public static GUIStyle title = "OL title";
            public static GUIStyle searchField = GetStyle("ToolbarSeachTextField");
            public static GUIStyle cancelSearchButton = GetStyle("ToolbarSeachCancelButton");
        }

        [MenuItem("Editor Gui Elements/Built In Stuff")]
        private static void OpenWindow()
        {
            GetWindow<BuiltInContentWindow>().Show();
            GetWindow<BuiltInContentWindow>().titleContent = new GUIContent("Built In Stuff");
        }

        private void OnGUI()
        {
            DrawAnimationWindowButtons();
            DrawSearchField();
            DrawBuiltInStyles();
        }

        private static void DrawSearchField()
        {
            var position = EditorGUILayout.GetControlRect();
            position.width -= 14f;
            EditorGUI.TextField(position, "Search Bar Title", "Search Text", BuiltInStyles.searchField);
            position.width += 14f;
            position.x += position.width - 14f;
            position.width = 14f;
            GUI.Button(position, "", BuiltInStyles.cancelSearchButton);
        }

        private static void DrawAnimationWindowButtons()
        {
            EditorGUILayout.BeginHorizontal(StylesFromAnimationWindow.miniToolbar, GUILayout.MinHeight(15f));
            GUILayout.Button(BuiltInContentWindow.StylesFromAnimationWindow.playContent, StylesFromAnimationWindow.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.StylesFromAnimationWindow.recordContent, StylesFromAnimationWindow.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.StylesFromAnimationWindow.nextKeyContent, StylesFromAnimationWindow.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.StylesFromAnimationWindow.prevKeyContent, StylesFromAnimationWindow.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.StylesFromAnimationWindow.addKeyframeContent, StylesFromAnimationWindow.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.StylesFromAnimationWindow.addEventContent, StylesFromAnimationWindow.miniToolbarButton);
            EditorGUILayout.EndHorizontal();
        }

        private static void DrawBuiltInStyles()
        {
            EditorGUILayout.BeginHorizontal(BuiltInStyles.title);
            EditorGUILayout.LabelField("OL title");
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal(BuiltInStyles.box);
            EditorGUILayout.LabelField("OL Box");
            EditorGUILayout.EndHorizontal();
        }

        private static GUIStyle GetStyle(string styleName)
        {
            GUIStyle gUIStyle = GUI.skin.FindStyle(styleName);
            if (gUIStyle == null)
            {
                gUIStyle = EditorGUIUtility.GetBuiltinSkin(EditorSkin.Inspector).FindStyle(styleName);
            }
            if (gUIStyle == null)
            {
                Debug.LogError("Missing built-in guistyle " + styleName);
            }
            return gUIStyle;
        }
    }
}