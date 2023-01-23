using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameFish : MonoBehaviour

{
    
    public float maxSpeed;
    public int difficulty;
    
    public bool hover = false;
    public Fish.FishType type;

    float speed = 0;
    Vector3 goal;
    Vector3 origin; //position of center of minigame in real world
    public float width; //width of minigame
    public float height; //height of minigame
    float acceleration;


    bool side = true;
    bool top = true;

    //Dash fish
    float pauseTime = .3f;
    float lastPause;
    bool pausing = false;

    //Jagged fish
    int dashes = 0;
    int maxDashes = 6;





    // Start is called before the first frame update
    void Start()
    {
        origin = Camera.main.ViewportToWorldPoint(new Vector3(.5f, .5f, 10));

        Vector2 start = FindGoal();
        goal = ConvertGoal(FindGoal());
        pausing = false;
        transform.position = goal;

    }

    
    void FixedUpdate()
    {
        if(!pausing){
            if(Vector3.Magnitude(goal - transform.position) < .3  ){
                do{
                    goal = ConvertGoal(FindGoal());
                } while(Vector3.Magnitude(goal - transform.position) < 3); //Ensure new goal isn't too close
                
            }
            MoveToGoal();
        }
        else{
            if(pauseTime + lastPause <= Time.time){
                pausing = false;
            }
        }
         
    }

    void Update() {
        //Checks for successful reel
        if(Input.GetKeyDown("space")){
            if(hover)
            {
                Fishing_Manager.instance.Reel(difficulty);
            }
            
        }
    }

    //Check if mouse is over object
    private void OnMouseEnter() {
        hover = true;
    }
    private void OnMouseExit() {
        hover = false;
    }


    Vector2 FindGoal(){
        float x;
        float y;
        //Move the fish to a random spot
        if(type == Fish.FishType.random){
            x = Random.Range(0, width);
            y = Random.Range(0, height);
            return new Vector2(x,y);
        

        //Dash across the field and pause
        } else if(type == Fish.FishType.dash){
            
            if(side){
                x = Random.Range(width - width / 4, width);
                y = Random.Range(0, height);
            } else{
                x = Random.Range(0, width / 4);
                y = Random.Range(0, height);
            }
            
            side = !side;
            pausing = true;
            lastPause = Time.time;
            return new Vector2(x,y);
        
                

        //Several vertical dashes before stopping
        } else if(type == Fish.FishType.jagged){
            
            if(dashes > maxDashes){
                side = !side;
                dashes = 0;
                pausing = true;
                lastPause = Time.time;
            }


            if(side){
                if(top){
                    x = Random.Range(dashes * 2, dashes * 2 + 1);
                    y = Random.Range(height * .75f, height);
                } else{
                    x = Random.Range(dashes * 2, dashes * 2 + 1);
                    y = Random.Range(0, height * .25f);
                }
            } else{
                if(top){
                    x = Random.Range(width - dashes * 2 - 1, width - dashes * 2);
                    y = Random.Range(height * .75f, height);
                } else{
                    x = Random.Range(width - dashes * 2 - 1, width - dashes * 2);
                    y = Random.Range(0, height * .25f);
                }
            }
            
            dashes++;
            top = !top;
            
            
            return new Vector2(x,y);

        }
        return new Vector2(0,0);
    }


    //Changes the goal from relative minigame space to actual game position
    Vector3 ConvertGoal(Vector2 relativeGoal){
        //Account for origin being at the center, while relative 0,0 is bottom left
        relativeGoal.x -= width / 2;
        relativeGoal.y -= height / 2;

        //Change from relative to actual
        relativeGoal.x += origin.x;
        relativeGoal.y += origin.y;

        return new Vector3(relativeGoal.x,relativeGoal.y,-2);
    }

    void MoveToGoal(){
        if(type == Fish.FishType.jagged){
            StaticMoveToGoal();
            return;
        }
        //If close to goal, decelerate
        if(Vector3.Magnitude(goal - transform.position) < 1.8f ){
            speed = Mathf.Max(speed - acceleration * Time.deltaTime, .5f);
        } else{
            speed = Mathf.Min(speed + acceleration * Time.deltaTime, maxSpeed);
        }
        Vector3 velocity = goal - gameObject.transform.position;
        transform.position += speed * Vector3.Normalize(velocity) * Time.deltaTime;
    }

    void StaticMoveToGoal(){
        Vector3 velocity = goal - gameObject.transform.position;
        transform.position += maxSpeed * Vector3.Normalize(velocity) * Time.deltaTime;
    }

    public void SetMaxSpeed(float maxSpeed){
        this.maxSpeed = maxSpeed;
        acceleration = maxSpeed * 1.5f;
    }
}
