using UnityEditor;
using UnityEngine;

namespace Leskiv.EditorGuiElements
{
    public class CustomElementsWindow : EditorWindow
    {
        float value;

        [MenuItem("Editor Gui Elements/Custom Elements Window")] static void OpenWindow()
        {
            GetWindow<CustomElementsWindow>().Show();
        }

        void OnGUI()
        {
            var rect1 = EditorGUILayout.GetControlRect();
            value = CustomSlider.MyCustomSlider(rect1, value, EditorStyles.miniButtonMid);
            value = CustomSlider.MyCustomSlider(value, EditorStyles.miniButtonMid, GUILayout.Height(55));

            var rect2 = EditorGUILayout.GetControlRect();
            if (FlashingButton.DrawFlashingButton(rect2, new GUIContent("Hello", "Flashing button"), EditorStyles.miniTextField))
            {
//                Debug.Log("Click");
            }
        }

        void OnInspectorUpdate()
        {
            Repaint();
        }
    }
}