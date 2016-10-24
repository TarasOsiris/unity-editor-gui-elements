using UnityEngine;
using System.Collections;

public static class CusomGuiElements
{
    public static float MyCustomSlider(Rect controlRect, float value, GUIStyle style)
    {
        int controlID = GUIUtility.GetControlID(FocusType.Passive);

        switch (Event.current.GetTypeForControl(controlID))
        {
            case EventType.Repaint:
                {
                    // Work out the width of the bar in pixels by lerping
                    int pixelWidth = (int)Mathf.Lerp(1f, controlRect.width, value);

                    // Build up the rectangle that the bar will cover
                    // by copying the whole control rect, and then setting the width
                    Rect targetRect = new Rect(controlRect){ width = pixelWidth };

                    // Tint whatever we draw to be red/green depending on value
                    GUI.color = Color.Lerp(Color.red, Color.green, value);

                    // Draw the texture from the GUIStyle, applying the tint
                    GUI.DrawTexture(targetRect, Texture2D.whiteTexture);

                    // Reset the tint back to white, i.e. untinted
                    GUI.color = Color.white;

                    break;
                }

            case EventType.MouseDown:
                {
                    // If the click is actually on us...
                    if (controlRect.Contains(Event.current.mousePosition)
                        // ...and the click is with the left mouse button (button 0)...
                        && Event.current.button == 0)
                        // ...then capture the mouse by setting the hotControl.
                        GUIUtility.hotControl = controlID;

                    break;
                }

            case EventType.MouseUp:
                {
                    // If we were the hotControl, we aren't any more.
                    if (GUIUtility.hotControl == controlID)
                        GUIUtility.hotControl = 0;

                    break;
                }


        }



        if (Event.current.isMouse && GUIUtility.hotControl == controlID)
        {

            // Get mouse X position relative to left edge of the control
            float relativeX = Event.current.mousePosition.x - controlRect.x;

            // Divide by control width to get a value between 0 and 1
            value = Mathf.Clamp01(relativeX / controlRect.width);

            // Report that the data in the GUI has changed
            GUI.changed = true;

            // Mark event as 'used' so other controls don't respond to it, and to
            // trigger an automatic repaint.
            Event.current.Use();
        }


        return value;
    }
}
