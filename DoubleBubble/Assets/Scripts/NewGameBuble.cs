using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameBuble: MonoBehaviour {
    
    [SerializeField] private GameObject ConfirmNewGameScreen;
    [SerializeField] private string sceneName;

    void OnTriggerEnter2D(Collider2D col)
    {
        ConfirmNewGameScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ToNewLvl()
    {
        SceneManager.LoadScene(sceneName);
        ConfirmNewGameScreen.SetActive(false);
    }

}
