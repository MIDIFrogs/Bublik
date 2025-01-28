using MIDIFrogs.Bubble.UI;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace MIDIFrogs.Bubble.Navigation
{
    public class MainMenuButton : MonoBehaviour
    {
        [SerializeField] private DialogWindow dialog;
        [SerializeField] private UnityEvent onConfirm; 
        [SerializeField] private AudioSource audioSource;

        void OnTriggerEnter2D(Collider2D col)
        {
            audioSource.Play();
            StartCoroutine(Confirm());
        }

        public IEnumerator Confirm()
        {
            yield return new WaitForSeconds(0.2f);
            yield return dialog.OpenDialog();
            Debug.Log($"Dialog has been closed with result {dialog.Result}");
            if (dialog.Result == DialogResult.Yes)
            {
                onConfirm.Invoke();
            }
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}