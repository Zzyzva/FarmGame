using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;



public class Player_Movement : MonoBehaviour
{
    public int speed;
    public bool canMove = true;

    [DllImport("user32.dll")]
    public static extern short GetAsyncKeyState(int vkey);
    public const int W = 0x57;
    public const int A = 0x41;
    public const int S = 0x53;
    public const int D = 0x44;

    
    void FixedUpdate()
    {
        if(!Time_Manager.instance.pause && canMove){
            //RIP
            //Unity sometimes drops inputs between scenes, it's a known bug
            //using user32.dll technically fixes it, but its bad practice. However, with the way I designed the scenes, its all I got
            //float inputX = Input.GetAxisRaw("Horizontal");
            //float inputY = Input.GetAxisRaw("Vertical");
            float inputX = 0;
            float inputY = 0;
            if ((GetAsyncKeyState(A) & 0x8000) > 0) {
                inputX -= 1;
            }
            if ((GetAsyncKeyState(W) & 0x8000) > 0) {
                inputY += 1;
            }
            if ((GetAsyncKeyState(S) & 0x8000) > 0) {
                inputY -= 1;
            }
            if ((GetAsyncKeyState(D) & 0x8000) > 0) {
                inputX += 1;
            }

            Vector2 movement = new Vector2(inputX, inputY);
            movement.Normalize();
            movement *= speed;


            GetComponent<Rigidbody2D>().velocity = movement;
        } else{
            Vector2 movement = new Vector3(0, 0);

            GetComponent<Rigidbody2D>().velocity = movement;
        }
    }
}
