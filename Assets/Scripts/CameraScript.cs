using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public static GameObject player;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    float height;
    float width;

    Vector3 targetLocation;
    bool waiting = false;
    float speed = 0;


    void Start(){
        player = Player_Manager.player;
        Camera cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        minX += width / 2;
        maxX -= width / 2;
        minY += height / 2;
        maxY -= height / 2;

        
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!Cutscene_Manager.instance.cutsceneIsRunning){
            Vector3 position = new Vector3(player.GetComponent<Transform>().position.x,player.GetComponent<Transform>().position.y,-10);
            

            if(minX < maxX){
            position.x = Mathf.Clamp(position.x, minX, maxX);     
            } else{
                position.x = (minX + maxX) / 2;
            }
            
            if(minY < maxY){
                position.y = Mathf.Clamp(position.y, minY, maxY);
            } else {
                position.y = (minY + maxY) / 2;
            }
            transform.position = position;
        //Panning Camera in cutscenes
        } else { 
            if(targetLocation != null){
                if(Vector3.Magnitude(targetLocation - transform.position) < .05  ){
                    transform.position = targetLocation;
                    if(waiting){
                        Cutscene_Manager.instance.RunCutscene();
                        waiting = false;
                    }
                    
                } else{
                    //Move to the next location
                    Vector3 velocity = targetLocation - transform.position;
                    transform.position += speed * Vector3.Normalize(velocity) * Time.deltaTime;
                }
            }
        }
    }

    public void SetTargetLocation(float x, float y, float speed, int waiting){
        targetLocation = new Vector3(x,y,-10);
        this.waiting = waiting == 1 ? true : false;
        this.speed = speed;
    }
}