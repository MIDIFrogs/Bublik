
using UnityEngine;

public class time : MonoBehaviour
{
    [SerializeField] private bool flag = false;
    [SerializeField] private GameObject gameobject;

    private void Awake()
    {
        if (flag) StopTime();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
        StopTime(); 
        gameobject.SetActive(true);
        }
        
    }

public void StopTime() {  Time.timeScale = 0; }
    public void Continue() {  Time.timeScale = 1; }
}
