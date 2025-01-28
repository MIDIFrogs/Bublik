using System;
using System.Collections;
using UnityEngine;

namespace MIDIFrogs.Bubble.UI
{
    [Serializable]
	public enum DialogResult
	{
		None,
		OK,
		Cancel,
		Abort,
		Retry,
		Yes,
		No,
		Continue,
	}

	public class DialogWindow : MonoBehaviour
	{
		[SerializeField] private PauseManager pauseManager;
		[SerializeField] private DialogResult result;
		private bool isOpened = false;

		public DialogResult Result => result;

		public Coroutine OpenDialog()
		{
			if (pauseManager != null)
				pauseManager.IsPaused = true;
			gameObject.SetActive(true);
			isOpened = true;
			result = DialogResult.None;
			return StartCoroutine(WaitUntilClicked());
		}

        private IEnumerator WaitUntilClicked()
        {
			yield return new WaitWhile(() => isOpened);
			gameObject.SetActive(false);
        }

		public void OnClick(DialogResult result)
		{
			if (pauseManager != null)
				pauseManager.IsPaused = false;
			this.result = result;
			isOpened = false;
		}

        public void OnClick(DialogResultDTO result) => OnClick(result.result);
    }
}