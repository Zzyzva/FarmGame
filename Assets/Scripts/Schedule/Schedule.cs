using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Schedule : MonoBehaviour
{
    public Queue<Location> queue;
    public Location start;
    
    float speed = 2.5f;
    Location location;
    Vector3 position;
    bool waiting = false;
    int waitTime;




    
    void Start()
    {
        queue = new Queue<Location>();
        Time_Manager.instance.schedules.Add(this);
        childStart();
        location = start;
        position = location.position;

    }

    public void NewDay(){
        queue.Clear();
        queue.Enqueue(Location.sleep);
        queue.Enqueue(start);
        location = queue.Dequeue();
        position = location.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!Time_Manager.instance.pause){
            //Check if NPC is in current scene
            if(SceneManager.GetActiveScene().name != location.scene){
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Script>().canTalk = false;
            } else{
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<Script>().canTalk = true;
            }

            //Check if NPC is waiting, if so break (Is this bad?)
            //If for some reason a second is skipped the NPC will not stop waiting, potential bug
            if(waiting && waitTime != Time_Manager.instance.GetTime()){
                return;
            }

            //Check if we have reached the destination
            if(Vector3.Magnitude(location.position - position) < .05  ){
                //If the destination has a wait time
                if(location.wait != 0 && !waiting){
                    //If we haven't started waiting yet, start waiting and return
                    waiting = true;
                    waitTime = Time_Manager.instance.GetTimeAfterInterval(location.wait);
                    gameObject.transform.position = position;
                    location.wait = 0;
                    return;
                }
                waiting = false;
                
                position = location.position;

                if(queue.Count != 0){
                    if(location.scene != queue.Peek().scene){
                    position = queue.Peek().position;
                }
                location = queue.Dequeue();
                }   
            }

            //Move to the next location
            if(location != null){
                Vector3 velocity = location.position - position;
                position += speed * Vector3.Normalize(velocity) * Time.deltaTime;
                if(SceneManager.GetActiveScene().name == location.scene){
                    gameObject.transform.position = position;
                }
            }
        }
    }


    public abstract void childStart();
    public abstract void UpdateSchedule(int hour, int minute, string meridiem, string day);
}
