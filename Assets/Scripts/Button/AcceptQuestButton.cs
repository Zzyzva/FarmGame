using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceptQuestButton : MonoBehaviour
{
    public Quest quest;
    public void ButtonPress(){
        quest.SetActive();
        Menu_Manager.instance.OpenBulletinMenu();
    }
}
