using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Din_Schedule : Schedule
{


    public override void childStart(){
        start = Location.herbalistHutBed;
        
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        //Walk to stall
        if(hour == 7 && minute == 40 && meridiem == "am"){
            queue.Enqueue(Location.herbalistHutBedPath);
            queue.Enqueue(Location.herbalistHutDoorInside);
            queue.Enqueue(Location.herbalistHutDoorOutside);
            queue.Enqueue(Location.herbalistHutPath);
            queue.Enqueue(Location.leftStallPath);
            queue.Enqueue(Location.leftStall);
        }

        //Explore the garden
        if(hour == 5 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.leftStallPath);
            queue.Enqueue(Location.gardenPath1);
            queue.Enqueue(Location.garden1.withWait(15));
            queue.Enqueue(Location.garden2.withWait(15));
            queue.Enqueue(Location.garden3.withWait(15));
            queue.Enqueue(Location.garden4.withWait(15));
            queue.Enqueue(Location.garden1.withWait(15));
            queue.Enqueue(Location.garden2.withWait(15));
            queue.Enqueue(Location.garden3.withWait(15));
            queue.Enqueue(Location.garden4.withWait(15));
        }

        if(hour == 8 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.gardenPath2);
            queue.Enqueue(Location.herbalistHutPath);
            queue.Enqueue(Location.herbalistHutDoorOutside);
            queue.Enqueue(Location.herbalistHutDoorInside);
            queue.Enqueue(Location.herbalistHutCauldronPath);
            queue.Enqueue(Location.herbalistHutCauldron);
        }

        if(hour == 12 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.herbalistHutCauldronPath);
            queue.Enqueue(Location.herbalistHutBedPath);
            queue.Enqueue(Location.herbalistHutBed);
        }

        
        
    }
}
