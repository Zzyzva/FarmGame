using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    public string startScene;
    public Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        //Time_Manager.instance.Pause();
        //Time_Manager.instance.HUD.alpha = 0f;
        //SceneManager.LoadScene("Title");
        Save_Manager.instance.StartNewGame();
        //LevelLoader.instance.LoadLevel(startScene, startPos);
    }


}
