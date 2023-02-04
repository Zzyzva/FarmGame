using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesBoulder : MonoBehaviour
{
    public Date clearDate = new Date(4, Month.Spring, 1);
    // Start is called before the first frame update
    void Start()
    {
        if(Time_Manager.instance.date.CompareDate(clearDate) >= 0){
            gameObject.SetActive(false);
        }
       
    }

}


