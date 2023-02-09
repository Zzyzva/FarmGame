using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNotification : MonoBehaviour
{

    public float showTime = 1;
    float lastShow;


    void Start(){
        lastShow = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Player_Manager.player.transform.position;
        pos.y +=1;
        gameObject.transform.position = pos;


        if(Time.time > lastShow + showTime){
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void SetItem(Item item){
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = item.icon;
        lastShow = Time.time;
    }
}
