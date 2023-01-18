using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private FloatingJoystick flotingJoystick;
   
    private float x_max = -3.5f;
    private float x_min = -7.5f;
    private int y_max = 4;
    private int y_min = -4;


    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 movement = new Vector3(flotingJoystick.Horizontal, flotingJoystick.Vertical,0);

        // GET THE POSITION
        float xPos = transform.position.x + movement.x * moveSpeed * Time.fixedDeltaTime;
        float yPos = transform.position.y + movement.z * moveSpeed * Time.fixedDeltaTime;

        //CLAMP THE X BOUNDIES
        if (xPos > x_max || xPos < x_min)
        {
            if (xPos > x_max)
                transform.position = new Vector3(x_max, transform.position.y, 0);
            else
                transform.position = new Vector3(x_min, transform.position.y, 0);
            movement.x = 0;
        }

        //CLAMP THE Y BOUNDIES
        if (yPos > y_max || yPos < y_min)
        {
            if (yPos > y_max)
                transform.position = new Vector3(transform.position.x, y_max, 0);
            else
                transform.position = new Vector3(transform.position.x, y_min, 0);
            movement.z = 0;
        }

        transform.Translate(movement * moveSpeed * Time.deltaTime) ;
    }


}
