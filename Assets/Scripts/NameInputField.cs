using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInputField : MonoBehaviour
{

    public TMP_InputField field;

    public void OnNameEnter(){
        Inventory_Manager.instance.playerName = field.text;
    }

    public void OnStartClick(){
        Save_Manager.instance.StartNewGame();
    }

}
