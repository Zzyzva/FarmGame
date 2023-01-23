using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatWalking : MonoBehaviour
{
    //public int lines;
    //public float increment;

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.transform.position.y - other.transform.localScale.y / 15 > transform.position.y){
            other.GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder + 1;
        }
    }
}
