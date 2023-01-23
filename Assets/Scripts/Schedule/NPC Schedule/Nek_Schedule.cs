using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nek_Schedule : Schedule
{

    public override void childStart(){
        start = Location.nekHutBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){
        //Work the fields
        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.nekHutBedPath);
            queue.Enqueue(Location.nekHutDoorInside);
            queue.Enqueue(Location.nekHutDoorOutside);
            queue.Enqueue(Location.nekPath1);
            queue.Enqueue(Location.nekPath2);
            queue.Enqueue(Location.nekFarm1.withWait(30));
            queue.Enqueue(Location.nekFarm2.withWait(30));
            queue.Enqueue(Location.nekFarm3.withWait(30));
            queue.Enqueue(Location.nekFarm4.withWait(30));
            queue.Enqueue(Location.nekFarm5.withWait(30));
            queue.Enqueue(Location.nekFarm6.withWait(30));
            queue.Enqueue(Location.nekFarm7.withWait(30));
            queue.Enqueue(Location.nekFarm8.withWait(30));
            queue.Enqueue(Location.nekFarm9.withWait(30));
            queue.Enqueue(Location.nekFarm8.withWait(30));
            queue.Enqueue(Location.nekFarm7.withWait(30));
            queue.Enqueue(Location.nekFarm6.withWait(30));
            queue.Enqueue(Location.nekFarm5.withWait(30));
            queue.Enqueue(Location.nekFarm4.withWait(30));
            queue.Enqueue(Location.nekFarm3.withWait(30));
            queue.Enqueue(Location.nekFarm2.withWait(30));
            queue.Enqueue(Location.nekFarm1.withWait(30));
            queue.Enqueue(Location.nekPath2);
            queue.Enqueue(Location.nekPath1);
            queue.Enqueue(Location.nekHutDoorOutside);
            queue.Enqueue(Location.nekHutDoorInside);
            queue.Enqueue(Location.nekHutChairPath);
            queue.Enqueue(Location.nekHutChair);
        }

        if(hour == 10 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.nekHutChairPath);
            queue.Enqueue(Location.nekHutBedPath);
            queue.Enqueue(Location.nekHutBed);
            
        }
              
    }
}
