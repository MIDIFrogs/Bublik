using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace MIDIFrogs.Bubble.Navigation
{
    public class GameEnter : MonoBehaviour, ICoroutineRunner
    {
        private void Awake()
        {
            GameServices.Initialize(this);
            DontDestroyOnLoad(this);
        }
    }
}