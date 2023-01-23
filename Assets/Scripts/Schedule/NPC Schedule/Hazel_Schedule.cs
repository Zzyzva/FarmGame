using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazel_Schedule : Schedule
{

    public override void childStart(){
        start = Location.innHazelBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.innHazelShelfPath);
            queue.Enqueue(Location.innHazelShelf);
        }

        //Check garden
        if(hour == 1 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.innHazelShelfPath);
            queue.Enqueue(Location.innHazelBedPath);
            queue.Enqueue(Location.innHallHigh);
            queue.Enqueue(Location.innHallLow);
            queue.Enqueue(Location.innBarHallHigh);
            queue.Enqueue(Location.innBarHallLow);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innGardenPath1);
            queue.Enqueue(Location.innGarden);
        }


        //Go to tavern
        if(hour == 4 && minute == 30 && meridiem == "pm"){
            queue.Enqueue(Location.innGardenPath1);
            queue.Enqueue(Location.innPath);
            queue.Enqueue(Location.innDoorOutside);
            queue.Enqueue(Location.innDoorInside);
            queue.Enqueue(Location.innDoorPath);
            queue.Enqueue(Location.innBarHallLow);
            queue.Enqueue(Location.innBarHallMid);

            queue.Enqueue(Location.innTable3.withWait(15));
            queue.Enqueue(Location.innTable4.withWait(15));
            queue.Enqueue(Location.innTableHallLow);
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTable1.withWait(15));
            queue.Enqueue(Location.innTable2.withWait(15));
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTableHallLow);
            queue.Enqueue(Location.innTable3.withWait(15));
            queue.Enqueue(Location.innTable4.withWait(15));
            queue.Enqueue(Location.innTableHallLow);
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTable1.withWait(15));
            queue.Enqueue(Location.innTable2.withWait(15));
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTableHallLow);
            queue.Enqueue(Location.innTable3.withWait(15));
            queue.Enqueue(Location.innTable4.withWait(15));
            queue.Enqueue(Location.innTableHallLow);
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTable1.withWait(15));
            queue.Enqueue(Location.innTable2.withWait(15));
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTableHallLow);
            queue.Enqueue(Location.innTable3.withWait(15));
            queue.Enqueue(Location.innTable4.withWait(15));
            queue.Enqueue(Location.innTableHallLow);
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTable1.withWait(15));
            queue.Enqueue(Location.innTable2.withWait(15));
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTableHallLow);
            queue.Enqueue(Location.innTable3.withWait(15));
            queue.Enqueue(Location.innTable4.withWait(15));
            queue.Enqueue(Location.innTableHallLow);
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTable1.withWait(15));
            queue.Enqueue(Location.innTable2.withWait(15));
            queue.Enqueue(Location.innTableHallHigh);
            queue.Enqueue(Location.innTableHallLow);
           
            queue.Enqueue(Location.innBarHallMid);
            queue.Enqueue(Location.innBarHallHigh);
            queue.Enqueue(Location.innHallLow);
            queue.Enqueue(Location.innHallHigh);
            queue.Enqueue(Location.innHazelBedPath);
            queue.Enqueue(Location.innHazelBed);
        }          
    }
}
