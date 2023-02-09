using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    double lastMove;

    float minMoveTime = 3;
    float maxMoveTime = 4;


    float minRestTime = 5;
    float maxRestTime = 8;

    float moveTime;

    float walkSpeed = 2;

    bool moving = false;

    float maxMove = 8;
    Vector3 velocity;
    Vector3 goal;

    float maxX = 92;
    float maxY = 27;
    float minX = 72;
    float minY = 2;

    private void Update() {
        if(!Time_Manager.instance.pause){

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
                        if(x > minX && x < maxX && y > minY && y < maxY){
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
}
