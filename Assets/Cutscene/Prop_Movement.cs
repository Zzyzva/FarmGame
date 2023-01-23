using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Movement : MonoBehaviour
{

    Vector3 targetLocation;
    float speed = 2f;
    bool waiting = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Check if we have reached the destination
        if(targetLocation != null){
            if(Vector3.Magnitude(targetLocation - transform.position) < .05  ){
                transform.position = targetLocation;
                if(waiting){
                    waiting = false;
                    Cutscene_Manager.instance.RunCutscene();
                    
                }
                
            } else{
                //Move to the next location
                Vector3 velocity = targetLocation - transform.position;
                transform.position += speed * Vector3.Normalize(velocity) * Time.deltaTime;
            }
        }
    }

    public void SetTargetLocation(float x, float y, float speed, int waiting){
        targetLocation = new Vector3(x,y,0);
        this.waiting = waiting == 1 ? true : false;
        this.speed = speed;
    }
}
