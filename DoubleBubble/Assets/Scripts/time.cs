
using UnityEngine;

public class time : MonoBehaviour
{
    [SerializeField] private bool flag = false;
    private void Awake()
    {
        if (flag) StopTime();
    }
    public void StopTime() {  Time.timeScale = 0; }
    public void Continue() {  Time.timeScale = 1; }
}
