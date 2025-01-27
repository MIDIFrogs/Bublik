using UnityEngine;
using UnityEngine.SceneManagement;

public class end : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
            {
            SceneManager.LoadScene("Menu");
        }
    }
}
