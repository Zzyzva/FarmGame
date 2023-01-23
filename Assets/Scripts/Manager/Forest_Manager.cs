using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest_Manager : MonoBehaviour
{
    public static Forest_Manager instance;

    public bool hasGenerated = false;
    public string[,] map;

    private void Awake() {
        if(instance == null){
            instance = this;
        } else{
            Destroy(gameObject);
        }
    }

    public void NewDay(){
        map = null;
        hasGenerated = false;
    }
}
