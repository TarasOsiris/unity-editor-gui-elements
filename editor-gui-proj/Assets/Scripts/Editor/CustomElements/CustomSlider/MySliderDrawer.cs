using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MySliderAttribute))]
public class MySliderDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight;
    }

    private GUISkin _sliderSkin;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
//        if (_sliderSkin == null)
//            _sliderSkin = (GUISkin)EditorGUIUtility.LoadRequired("MyCustomSlider Skin");

        CustomSlider.MyCustomSlider(position, property, EditorStyles.miniButtonMid, label);
    }
}