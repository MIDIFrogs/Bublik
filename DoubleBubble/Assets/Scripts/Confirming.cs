using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Confirming: MonoBehaviour{
    
    [SerializeField] private GameObject BackConfirm;
    [SerializeField] private GameObject ButtonConfirm;
    [SerializeField] private TMP_Text TextActive;
    [SerializeField] private string text;
    [SerializeField] private string sceneName;

    void OnTriggerEnter2D(Collider2D col)
    {
        BackConfirm.SetActive(true);
        ButtonConfirm.SetActive(true);
        Invoke("TimeStop", 0.2f);
        TextActive.text = text; 
    }

    public void TimeStop()
    {
        Time.timeScale = 0f;
    }

    public void ToNewLvl()
    {
        Debug.Log(sceneName);
        if (sceneName == null)
        {
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
            TextActive.text = "";
        }
    }

}
