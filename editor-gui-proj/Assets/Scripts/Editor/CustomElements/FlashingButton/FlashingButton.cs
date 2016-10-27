using UnityEngine;
using System.Collections;

public static class FlashingButton
{
    public static bool DrawFlashingButton(Rect rc, GUIContent content, GUIStyle style)
    {
        int controlID = GUIUtility.GetControlID(FocusType.Native);

        // Get (or create) the state object
        var state = (FlashingButtonInfo)GUIUtility.GetStateObject(
            typeof(FlashingButtonInfo), 
            controlID);

        switch (Event.current.GetTypeForControl(controlID))
        {
            case EventType.Repaint:
                {
                    GUI.color = state.IsFlashing(controlID) 
                        ? Color.red 
                        : Color.green;
                    style.Draw(rc, content, controlID);
                    break;
                }
            case EventType.MouseDown:
                {
                    if (rc.Contains(Event.current.mousePosition)
                        && Event.current.button == 0
                        && GUIUtility.hotControl == 0)
                    {
                        GUIUtility.hotControl = controlID;
                        state.MouseDownNow();
                    }
                    break;
                }
            case EventType.MouseUp:
                {
                    if (GUIUtility.hotControl == controlID)
                        GUIUtility.hotControl = 0;
                    break;
                }
        }

        return GUIUtility.hotControl == controlID;
    }
}
