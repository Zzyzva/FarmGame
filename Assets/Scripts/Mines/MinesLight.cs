using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinesLight : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Player_Manager.player.transform.position;
        pos.z = -2;
        gameObject.transform.position = pos;
    }
}
