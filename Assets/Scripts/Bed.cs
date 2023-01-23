using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    private void OnMouseDown() {
        if(!Time_Manager.instance.pause){
            Time_Manager.instance.Sleep();
        }
    }
}
