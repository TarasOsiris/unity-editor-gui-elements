using UnityEditor;

namespace Leskiv.EditorGuiElements
{
    public class DemoEditorWindow : EditorWindow
    {
        [MenuItem("Editor Gui Elements/Open Demo Window")] static void OpenWindow()
        {
            GetWindow<DemoEditorWindow>();
        }

        void OnGUI()
        {
		    
        }
    }
}