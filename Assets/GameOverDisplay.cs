using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverDisplay : MonoBehaviour {

    void Start() {
        PlayerHandler.inst.GetComponent<Health>().death.AddListener(toggleGameOverScreenOverlay);
    }

    void toggleGameOverScreenOverlay() {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = (canvasGroup.alpha == 0) ? 1 : 0;
    }

    void OnDestroy() {
        if (PlayerHandler.inst != null)
            PlayerHandler.inst.GetComponent<Health>().death.RemoveListener(toggleGameOverScreenOverlay);
    }
}
