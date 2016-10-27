using UnityEditor;
using UnityEngine;

public class FlashingButtonInfo
{
    private double mouseDownAt;

    public void MouseDownNow()
    {
        mouseDownAt = EditorApplication.timeSinceStartup;
    }

    public bool IsFlashing(int controlID)
    {
        if (GUIUtility.hotControl != controlID)
            return false;

        double elapsedTime = EditorApplication.timeSinceStartup - mouseDownAt;
        if (elapsedTime < 2f)
            return false;

        return (int)((elapsedTime - 2f) / 0.1f) % 2 == 0;
    }
}