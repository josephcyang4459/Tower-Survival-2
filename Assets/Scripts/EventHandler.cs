using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// This is just a place to store various game events
public class EventHandler : MonoBehaviour {
    public static EventHandler inst { get; private set; }
    public UnityEvent goToNextWave;

    private void Awake() {
        if (inst == null) {
            inst = this;
            DontDestroyOnLoad(this);
        } else
            Destroy(this);
    }
}
