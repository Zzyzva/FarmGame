using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matthew_Schedule : Schedule
{

    public override void childStart(){
        start = Location.eastFarmHutMatthewBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        if(hour == 7 && minute == 30 && meridiem == "am"){
            queue.Enqueue(Location.eastFarmHutTopBedPath1);
            queue.Enqueue(Location.eastFarmHutTopBedPath2);
            queue.Enqueue(Location.eastFarmHutChair5);
        }
        //Work the farm
        if(hour == 8 && minute == 45 && meridiem == "am"){
            queue.Enqueue(Location.eastFarmHutHallHigh);
            queue.Enqueue(Location.eastFarmHutHallLow);
            queue.Enqueue(Location.eastFarmHutDoorPath);
            queue.Enqueue(Location.eastFarmHutDoorInside);
            queue.Enqueue(Location.eastFarmHutDoorOutside);
            queue.Enqueue(Location.matthewPath1);
            queue.Enqueue(Location.matthewPath2);
            queue.Enqueue(Location.matthewFarm1.withWait(30));
            queue.Enqueue(Location.matthewFarm2.withWait(30));
            queue.Enqueue(Location.matthewFarm3.withWait(30));
            queue.Enqueue(Location.matthewFarm4.withWait(30));
            queue.Enqueue(Location.matthewFarm5.withWait(30));
            queue.Enqueue(Location.matthewFarm6.withWait(30));
            queue.Enqueue(Location.matthewFarm7.withWait(30));
            queue.Enqueue(Location.matthewFarm8.withWait(30));
            queue.Enqueue(Location.matthewFarm9.withWait(30));
            queue.Enqueue(Location.matthewFarm8.withWait(30));
            queue.Enqueue(Location.matthewFarm7.withWait(30));
            queue.Enqueue(Location.matthewFarm6.withWait(30));
            queue.Enqueue(Location.matthewFarm5.withWait(30));
            queue.Enqueue(Location.matthewFarm4.withWait(30));
            queue.Enqueue(Location.matthewFarm3.withWait(30));
            queue.Enqueue(Location.matthewFarm2.withWait(30));
            queue.Enqueue(Location.matthewFarm1.withWait(30));
            queue.Enqueue(Location.matthewPath2);
            queue.Enqueue(Location.matthewPath1);
            queue.Enqueue(Location.eastFarmHutDoorOutside);
            queue.Enqueue(Location.eastFarmHutDoorInside);
            queue.Enqueue(Location.eastFarmHutDoorPath);
            queue.Enqueue(Location.eastFarmHutHallLow);
            queue.Enqueue(Location.eastFarmHutHallHigh);
            queue.Enqueue(Location.eastFarmHutChair5);
        }

        if(hour == 9 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.eastFarmHutTopBedPath2);
            queue.Enqueue(Location.eastFarmHutTopBedPath1);
            queue.Enqueue(Location.eastFarmHutMatthewBed);

        }

              
    }
}
