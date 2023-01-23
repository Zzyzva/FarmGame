using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CursorItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetActive(Item item){
        gameObject.GetComponentInChildren<Image>().enabled = true;
        gameObject.GetComponentInChildren<Image>().sprite = item.icon;
        string text;
         if(item.count == 1 || item.count == 0){
                text = "";
            } else{
                text = item.count.ToString();
            }
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }

    public void SetInactive(){
        gameObject.GetComponentInChildren<Image>().enabled = false;
        gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "";
    }
}
