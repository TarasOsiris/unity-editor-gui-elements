using UnityEditor;
using UnityEngine;

namespace Leskiv.EditorGuiElements
{
    public class EditorGuiLayoutWindow : EditorWindow
    {
        Bounds bounds = new Bounds(Vector3.zero, Vector3.one);
        Color color = Color.white;
        AnimationCurve curve = AnimationCurve.Linear(0, 0, 10, 10);

        float floatField = float.MaxValue;
        double doubleField = double.MaxValue;
        int intField = int.MaxValue;
        long longField = long.MaxValue;
        bool boolField = false;

        Vector2 vector2field;
        Vector3 vector3field;
        Vector4 vector4field;

        [MenuItem("Editor Gui Elements/EditorGuiLayout")] static void OpenWindow()
        {
            GetWindow<EditorGuiLayoutWindow>().Show();
            GetWindow<EditorGuiLayoutWindow>().titleContent = new GUIContent("Default Controls");
        }

        void OnGUI()
        {
            DrawHelpBoxes();
            bounds = EditorGUILayout.BoundsField("Bounds Field", bounds);
            color = EditorGUILayout.ColorField(color);
            curve = EditorGUILayout.CurveField("Animation Curve", curve);
            DrawNumericFields();
            DrawVectorFields();
            boolField = EditorGUILayout.ToggleLeft("Toggle Left", boolField);
        }

        void DrawHelpBoxes()
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox("Just a message", MessageType.None);
            EditorGUILayout.HelpBox("Info", MessageType.Info);
            EditorGUILayout.HelpBox("Warning", MessageType.Warning);
            EditorGUILayout.HelpBox("Error", MessageType.Error);
            EditorGUILayout.EndHorizontal();
        }

        void DrawNumericFields()
        {
            intField = EditorGUILayout.IntField("Int field", intField);
            intField = EditorGUILayout.IntPopup("Int Popup", 1, new [] { "One", "Two", "Three" }, new [] { 1, 2, 3 });
            intField = EditorGUILayout.IntSlider("Int Slider", 2, 0, 10);
            floatField = EditorGUILayout.FloatField("Float field", floatField);
            doubleField = EditorGUILayout.DoubleField("Double Field", doubleField);
            longField = EditorGUILayout.LongField("Long Field", longField);

        }

        void DrawVectorFields()
        {
            vector2field = EditorGUILayout.Vector2Field("Vector 2", vector2field);
            vector3field = EditorGUILayout.Vector3Field("Vector 3", vector3field);
            vector4field = EditorGUILayout.Vector4Field("Vector 4", vector4field);
        }
    }
}
