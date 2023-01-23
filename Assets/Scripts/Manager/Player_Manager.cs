using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{

    public static GameObject player;

    public GameObject emote;


    // Start is called before the first frame update
    void Awake()
    {
        if(player){
            Destroy(gameObject);
        }else{
            player = gameObject;
        }

    }


    public static void CanMove(bool canMove){
        //If the player cant move (because of some animation) then we shouldnt pause to interupt it
        if(canMove){
            Time_Manager.instance.canPause = true;
        } else{
            Time_Manager.instance.canPause = false;
        }
        player.GetComponent<Player_Movement>().canMove = canMove;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
    }

    public static void HidePlayer(){
        player.GetComponent<SpriteRenderer>().enabled = false;
    }

    public static void ShowPlayer(){
        player.GetComponent<SpriteRenderer>().enabled = true;
    }
}
