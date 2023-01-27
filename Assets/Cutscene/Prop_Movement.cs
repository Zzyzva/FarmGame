using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Movement : MonoBehaviour
{

    List<Vector3> targetLocations = new List<Vector3>();
    float speed = 2f;
    bool waiting = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Check if we have reached the destination
        if(targetLocations.Count != 0){
            if(Vector3.Magnitude(targetLocations[0] - transform.position) < .05  ){
                transform.position = targetLocations[0];
                targetLocations.RemoveAt(0);
                if(waiting && targetLocations.Count == 0){
                    waiting = false;
                    Cutscene_Manager.instance.RunCutscene();  
                }
                
            } else{
                //Move to the next location
                Vector3 velocity = targetLocations[0] - transform.position;
                transform.position += speed * Vector3.Normalize(velocity) * Time.deltaTime;
            }
        }
    }

    public void AddTargetLocation(float x, float y, float speed, int waiting){
        targetLocations.Add(new Vector3(x,y,0));
        this.waiting = waiting == 1 ? true : false;
        this.speed = speed;
    }
}
