using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Johnson_Schedule : Schedule
{

    public override void childStart(){
        start = Location.shepardJohnsonBed;
    }

    public override void UpdateSchedule(int hour, int minute, string meridiem){

        //Watch sheep
        if(hour == 8 && minute == 0 && meridiem == "am"){
            queue.Enqueue(Location.shepardJohnsonBedPath1);
            queue.Enqueue(Location.shepardJohnsonBedPath2);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardBackDoor);
            queue.Enqueue(Location.sheepYardEnter);
            queue.Enqueue(Location.sheepYardPath1);
            queue.Enqueue(Location.sheepYardPath2);
            queue.Enqueue(Location.sheepYard1.withWait(60));
            queue.Enqueue(Location.sheepYard2.withWait(60));
            queue.Enqueue(Location.sheepYard3.withWait(60));
            queue.Enqueue(Location.sheepYard4.withWait(60));
            queue.Enqueue(Location.sheepYard5.withWait(60));
            queue.Enqueue(Location.sheepYard2.withWait(60));
            queue.Enqueue(Location.sheepYard3.withWait(60));
            queue.Enqueue(Location.sheepYard4.withWait(60));
            queue.Enqueue(Location.sheepYard5.withWait(60));
            queue.Enqueue(Location.sheepYard1);
            queue.Enqueue(Location.sheepYardPath2);
            queue.Enqueue(Location.sheepYardPath1);
            queue.Enqueue(Location.sheepYardEnter);
            queue.Enqueue(Location.shepardBackDoor);
            queue.Enqueue(Location.shepardHallHigh);
            queue.Enqueue(Location.shepardChair1Path);
            queue.Enqueue(Location.shepardChair1);

        }

        if(hour == 9 && minute == 0 && meridiem == "pm"){
            queue.Enqueue(Location.shepardChair1Path);
            queue.Enqueue(Location.shepardJohnsonBedPath2);
            queue.Enqueue(Location.shepardJohnsonBedPath1);
            queue.Enqueue(Location.shepardJohnsonBed);
        }
            

              
    }
}

