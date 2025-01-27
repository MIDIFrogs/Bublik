using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Confirming: MonoBehaviour{
    
    [SerializeField] private GameObject BackConfirm;
    [SerializeField] private GameObject ButtonConfirm;
    [SerializeField] private string sceneName;
    [SerializeField] private AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D col)
    {
        BackConfirm.SetActive(true);
        audioSource.Play(); 
        ButtonConfirm.SetActive(true);
        Invoke("TimeStop", 0.2f);
    }

    public void TimeStop()
    {
        Time.timeScale = 0f;
    }

    public void ToNewLvl()
    {
        Debug.Log(sceneName);
        if (sceneName == "exit")
        {
            Debug.Log("hh");
            Application.Quit();
            BackConfirm.SetActive(false);
            ButtonConfirm.SetActive(false);
        }
        else
        {
            Debug.Log(sceneName);
            SceneManager.LoadScene(sceneName);
            BackConfirm.SetActive(false);
            ButtonConfirm.SetActive(false);
            Time.timeScale = 1f;
        }
    }

}
