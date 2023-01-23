using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sophia_Schedule : Schedule
{


    public override void childStart(){
        start = Location.churchBack;
        
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){
        //Go to field
        if(hour == 2 && minute == 55 && meridiem == "pm"){
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.sophiaSpotPath);
            queue.Enqueue(Location.sophiaSpot);
            
            
        }


        //Go to tavern
        if(hour == 6 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.sophiaSpotPath);
            queue.Enqueue(Location.marketCenter);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innCenter1);
        }

        //Go home
        if(hour == 12 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.churchPath3);
            queue.Enqueue(Location.churchPath2);
            queue.Enqueue(Location.churchPath1);
            queue.Enqueue(Location.churchDoorOutside);
            queue.Enqueue(Location.churchDoorInside);
            queue.Enqueue(Location.churchBack);

            
            
            
        }
        
    }

    

    
}
