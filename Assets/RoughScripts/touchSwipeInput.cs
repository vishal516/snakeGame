
using UnityEngine;

public class touchSwipeInput : MonoBehaviour
{
    #region privateVariables
    private Vector2 mouseStartPos;
    private Vector2 mouseEndPos;
    private Vector2 drag;
    #endregion

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseEndPos = Input.mousePosition;
            TouchSwipes();
        }
    }

    void TouchSwipes()
    {
        drag = mouseStartPos - mouseEndPos;
        if (Mathf.Abs(drag.x) > Mathf.Abs( drag.y))
        {
            if (drag.x > 0)
            {
                print("X :: Left");
            }
            else
                print("X :: Right");
        }
        else
        {
            if (drag.y > 0)
            {
                print("Y :: Up");
            }
            else
                print("Y :: Down");
        }
            
    }


}
