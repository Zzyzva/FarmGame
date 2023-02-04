using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{

    public enum Type{
        forest_lake,
        mountain_lake,
        river
    }
   
   public Type type;
   public void WaterHit(float maxWater){
       Farming_Manager.instance.RefillCan(maxWater + 1); //plus 1 since can pours one right after
   }
}
