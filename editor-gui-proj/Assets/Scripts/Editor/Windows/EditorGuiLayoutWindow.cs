using UnityEditor;
using UnityEngine;

namespace Leskiv.EditorGuiElements
{
    public class EditorGuiLayoutWindow : EditorWindow
    {
        Bounds bounds = new Bounds(Vector3.zero, Vector3.one);
        Color color = Color.white;
        AnimationCurve curve = AnimationCurve.Linear(0,0,10,10);

        float floatField = 0.0f;
        double doubleField = 0;
        int intField = 1;

        [MenuItem("Editor Gui Elements/EditorGuiLayout")] static void OpenWindow()
        {
            var window = GetWindow<EditorGuiLayoutWindow>();
            window.Show();
        }

        void OnGUI()
        {
            DrawHelpBoxes();
            bounds = EditorGUILayout.BoundsField("Bounds Field", bounds);
            color = EditorGUILayout.ColorField(color);
            curve = EditorGUILayout.CurveField("Animation Curve", curve);
            DrawNumericFields();
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
            floatField = EditorGUILayout.FloatField("Float field", floatField);
        }
    }
}
