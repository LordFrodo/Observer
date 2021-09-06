using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangeScene : MonoBehaviour
{
    private bool select;
    [SerializeField] Image fill_Image;


    public void ChangeSceneVideo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    private void Update()
    {
        if (select)
        {
            fill_Image.fillAmount += Time.deltaTime;
        } 
        if (fill_Image.fillAmount == 1)
        {
            ChangeSceneVideo("TextureVideo");
        }
    }
    public void SelecVideo(bool trigger_enter)
    {
        select = trigger_enter;
        Debug.Log("Entre");
    }
    public void ExitVideo(bool exit)
    {
        select = exit;
        fill_Image.fillAmount = 0;
    }
}
