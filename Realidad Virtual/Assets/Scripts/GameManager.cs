using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]private float time;
    [SerializeField] private Text ui_time;
    public bool ingame;
    [SerializeField]GameObject player;
    [SerializeField] Transform lose, win, lvl1;


    // Start is called before the first frame update
    void Start()
    {
        EnemyController.lose_event += Lose;

    }

    // Update is called once per frame
    void Update()
    {
        if (ingame)
        {
            ui_time.text = ("Tiempo restante: " + (int)time);
            time -= Time.deltaTime;
        }
        
        if(time <= 0)
        {
            ChangeScene("Win");
        }

    }
    public void Lose()
    {
        if (ingame == false)
        {
            EnemyController.lose_event -= Lose;
            player.transform.position = lose.position;
            //SceneManager.LoadScene("Lose", LoadSceneMode.Additive);

        }
        
    }
    public void ChangeScene(string scene_name)
    {
        //SceneManager.LoadScene(scene_name, LoadSceneMode.Additive);
        
        if(scene_name == "Win")
        {
            player.transform.position = win.position;
            ingame = false;
        }
        else
        {
            ingame = true;
            player.transform.position = lvl1.position;
        }

    }
    
}
