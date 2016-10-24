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
            var rect = EditorGUILayout.GetControlRect();
//            GUI.DrawTexture(rect, Texture2D.whiteTexture);
            value = CusomGuiElements.MyCustomSlider(rect, value, GUI.skin.window);
        }
    }
}