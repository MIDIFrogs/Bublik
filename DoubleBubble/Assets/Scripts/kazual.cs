using UnityEngine;
using UnityEngine.SceneManagement;

public class kazual : MonoBehaviour
{
    [SerializeField] private string name;
    public void kazualich()
    {
        SceneManager.LoadScene(name);
    }
}
