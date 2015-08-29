using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

public class FadeGroupExampleWindow : EditorWindow
{
    AnimBool showExtraFields;
    string stringField;
    Color colorField = Color.white;
    int numberField = 0;

    [MenuItem("Editor Gui Elements/Fade Group Example Window")]
    static void OpenWindow()
    {
        GetWindow<FadeGroupExampleWindow>().Show();
    }

    void OnEnable()
    {
        showExtraFields = new AnimBool(true);
        showExtraFields.valueChanged.AddListener(Repaint);
    }

    void OnGUI()
    {
        showExtraFields.target = EditorGUILayout.ToggleLeft("Show extra fields", showExtraFields.target);

        if (EditorGUILayout.BeginFadeGroup(showExtraFields.faded))
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PrefixLabel("Color");
            colorField = EditorGUILayout.ColorField(colorField);
            EditorGUILayout.PrefixLabel("Text");
            stringField = EditorGUILayout.TextField(stringField);
            EditorGUILayout.PrefixLabel("Number");
            numberField = EditorGUILayout.IntSlider(numberField, 0, 10);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.EndFadeGroup();
    }
}