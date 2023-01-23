using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float maxDistance;
    public Vector3 origin;

    void Update()
    {
        if(!Time_Manager.instance.pause){
            if(Mathf.Abs(Vector3.Magnitude(origin - transform.position)) > maxDistance){
                Destroy(gameObject);
            }
        }
    }
}
