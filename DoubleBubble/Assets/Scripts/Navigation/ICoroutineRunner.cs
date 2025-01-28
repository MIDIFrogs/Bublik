using System.Collections;
using UnityEngine;

namespace MIDIFrogs.Bubble.Navigation
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}