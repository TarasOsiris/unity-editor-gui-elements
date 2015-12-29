using UnityEngine;
using System.Collections;
using UnityEditor;

namespace Leskiv.EditorGuiElements
{
    public class BuiltInContentWindow : EditorWindow
    {
        internal static class Styles
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

            static Styles()
            {
                toolbarLabel.normal.background = null;
                miniToolbarButton.padding.top = 0;
                miniToolbarButton.padding.bottom = 3;
            }
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
        }

        private static void DrawAnimationWindowButtons()
        {
            EditorGUILayout.BeginHorizontal(Styles.miniToolbar, GUILayout.MinHeight(15f));
            GUILayout.Button(BuiltInContentWindow.Styles.playContent, Styles.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.Styles.recordContent, Styles.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.Styles.nextKeyContent, Styles.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.Styles.prevKeyContent, Styles.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.Styles.addKeyframeContent, Styles.miniToolbarButton);
            GUILayout.Button(BuiltInContentWindow.Styles.addEventContent, Styles.miniToolbarButton);
            EditorGUILayout.EndHorizontal();
        }
    }
}