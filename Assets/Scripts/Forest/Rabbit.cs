using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : ForestObject
{

    public Item pelt;
    public Item meat;

    public GameObject rabbitHole;
    GameObject rabbitHoleInstance;

    double lastMove;

    float minMoveTime = .2f;
    float maxMoveTime = 1;


    float minRestTime = 1;
    float maxRestTime = 3;

    float moveTime;

    float walkSpeed = 5;
    float runSpeed = 8;

    float fleeDistance = 6;


    bool moving = false;
    bool fleeing = false;

    float maxMove = 4;
    Vector3 velocity;
    Vector3 goal;

    float maxX = 78;
    float maxY = 78;

    //Used for reentering the forest
    public bool dead = false;





    //Creates the rabbit hole and sets up movement variables
    private void Start() {
        rabbitHoleInstance = Instantiate(rabbitHole);
        rabbitHoleInstance.transform.position = gameObject.transform.position;
        if(dead){
            Destroy(gameObject);
            return;
        }   
        
        lastMove = Time.time;
        moveTime = Random.Range(minMoveTime, maxMoveTime);
    }

    //Checks for elapsed time
    //If moving, stops and sets new time
    //If not moving, picks a random direction to move
    private void Update() {
        if(!Time_Manager.instance.pause){
            //Check if it needs to flee
            if(( Player_Manager.player.transform.position - gameObject.transform.position ).magnitude < fleeDistance){
                fleeing = true;
            } 
            if(fleeing){
                Vector2 velocity = rabbitHoleInstance.transform.position - gameObject.transform.position;
                velocity.Normalize();
                velocity *= runSpeed;
                gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
                return;
            }

            if(lastMove + moveTime < Time.time){
                lastMove = Time.time;
                //If moving, stop for a random time
                if(moving){
                    moving = false;
                    moveTime = Random.Range(minRestTime, maxRestTime);
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
                //If not moving
                } else{
                    moving = true;
                    moveTime = Random.Range(minMoveTime, maxMoveTime);
                    int emergency = 0;
                    float x = gameObject.transform.position.x;
                    float y = gameObject.transform.position.y;
                    while(emergency < 1000){
                        emergency++;
                        x = gameObject.transform.position.x + Random.Range(-maxMove, maxMove);
                        y = gameObject.transform.position.y + Random.Range(-maxMove, maxMove);
                        goal = new Vector3(x,y,0);
                        //Check if goal is in bounds
                        if(x > 2 && x < maxX && y > 2 && y < maxY){
                            if(!Physics2D.Linecast(transform.position, goal, Physics2D.DefaultRaycastLayers, -1, -1)){
                                break;
                            }
                    
                        } else {
                            x = gameObject.transform.position.x;
                            y = gameObject.transform.position.y;
                        }
                    }
                    goal = new Vector3(x,y,0);
                    velocity = goal - gameObject.transform.position;
                }
            }
            //If moving, move
            if(moving){
                if(Vector3.Magnitude(goal - transform.position) > .2  ){
                    transform.position += walkSpeed * Vector3.Normalize(velocity) * Time.deltaTime;
                }
            }
        }
    }

    public void SetBounds(int x, int y){
        maxX = x;
        maxY = y;
    }


    //If hit by arrow, die
    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Weapon"){
            Inventory_Manager.instance.AddItem(pelt, 1);
            Inventory_Manager.instance.AddItem(meat, 1);
            Skills_Manager.instance.AddForestryXP(15);
            Forest_Manager.instance.map[forestPosX, forestPosY] = "dead rabbit";
            Destroy(gameObject);
        } else if(other.gameObject == rabbitHoleInstance && fleeing){
            Destroy(gameObject);
        }
    }
}
