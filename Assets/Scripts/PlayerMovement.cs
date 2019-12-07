
/*==================================================================
    Vishal singh    
    vrx3ds@gmail.com
====================================================================*/


using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region publicVariables
    public GameObject tile;
    #endregion

    #region privateVariables
    private GameObject[,] grid = new GameObject[20, 20];

    private int x = 0;
    private int y = 0;
    private Vector2Int direction;
    private Vector2 mouseStartPos;
    private Vector2 mouseEndPos;
    private Vector2 drag;
    #endregion


    private void Start()
    {
        CreateGrid();//create grid for easy position tracking/visibility of the player
    }

    private void Update()
    {
        InputDirection();//change direction according to touchSwipe direction
        ForwardMovement();//keep moving Forward
    }

    private void InputDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            mouseEndPos = Input.mousePosition;
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        drag = mouseStartPos - mouseEndPos;
        if (Mathf.Abs(drag.x) > Mathf.Abs(drag.y))
        {
            if (drag.x > 0)
            {
                //print("X :: Left");
                if (direction.y == -1)
                {
                    y = Mathf.FloorToInt(transform.localPosition.y);
                }
                else
                {
                    y = Mathf.CeilToInt(transform.localPosition.y);
                }
                x = Mathf.CeilToInt(transform.localPosition.x);

                direction.y = 0;
                direction.x = -1;

            }
            else
            {
                //print("X :: Right");
                if (direction.y == -1)
                {
                    y = Mathf.FloorToInt(transform.localPosition.y);
                }
                else
                {
                    y = Mathf.CeilToInt(transform.localPosition.y);
                }
                x = Mathf.CeilToInt(transform.localPosition.x);

                direction.y = 0;
                direction.x = 1;

            }
        }
        else
        {
            if (drag.y > 0)
            {
                //print("Y :: Down");
                if (direction.x == -1)
                {
                    x = Mathf.FloorToInt(transform.localPosition.x);
                }
                else
                {
                    x = Mathf.CeilToInt(transform.localPosition.x);
                }
                y = Mathf.CeilToInt(transform.localPosition.y);

                direction.x = 0;
                direction.y = -1;

            }
            else
            {
                //print("Y :: Up");
                if (direction.x == -1)
                {
                    x = Mathf.FloorToInt(transform.localPosition.x);
                }
                else
                {
                    x = Mathf.CeilToInt(transform.localPosition.x);
                }
                y = Mathf.CeilToInt(transform.localPosition.y);

                direction.y = 1;
                direction.x = 0;
            }
        }
        transform.localPosition = new Vector2(x, y);
    }


    private void ForwardMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(x, y), 5f * Time.deltaTime);
        {
            x += direction.x;
            y += direction.y;

            //reset position if position is out of range
            if (transform.localPosition.x > 19)
            {
                x = 0;
                transform.position = new Vector2(x, y);
            }
            if (transform.localPosition.x < 0)
            {
                x = 19;
                transform.position = new Vector2(x, y);
            }
            if (transform.localPosition.y > 19)
            {
                y = 0;
                transform.position = new Vector2(x, y);
            }
            if (transform.localPosition.y < 0)
            {
                y = 19;
                transform.position = new Vector2(x, y);
            }
        }
    }

    private void CreateGrid()
    {
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                grid[i, j] = Instantiate(tile, new Vector2(i, j), Quaternion.identity);
                grid[i, j].transform.SetParent(transform.parent);
            }
        }
    }

}

