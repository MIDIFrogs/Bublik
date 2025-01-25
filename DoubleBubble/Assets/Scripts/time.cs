using System.Diagnostics.Contracts;
using UnityEngine;

public class time : MonoBehaviour
{
    public void StopTime() {  Time.timeScale = 0; }
    public void Continue() {  Time.timeScale = 1; }
}
