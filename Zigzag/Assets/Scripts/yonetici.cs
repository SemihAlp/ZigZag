using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yonetici : MonoBehaviour
{

    bool oyun_durduruldu = false;

    public void durdur_btn()
    {

        oyun_durduruldu = !oyun_durduruldu;

        if (oyun_durduruldu == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public void tryAgain_btn()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void play_btn()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void mainMenu_btn()
    {
        SceneManager.LoadScene("Scenes/Main Menu");
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
