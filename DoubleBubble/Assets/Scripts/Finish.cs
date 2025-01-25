using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private string sceneName; 
    [SerializeField] private GameObject winScreen;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player") 
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ToNewLvl() {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
