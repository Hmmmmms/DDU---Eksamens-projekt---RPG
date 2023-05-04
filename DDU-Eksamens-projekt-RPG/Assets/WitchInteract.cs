using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WitchInteract : MonoBehaviour
{
    public bool isInRange;
    public UnityEvent interactAction;

    public GameObject Witch;

    public Collider2D StartBossRound1;

    public Collider2D StartBossRound2;

    public Vector3 interactPosition;

    public Vector3 Bosspositon;

    public bool DialogTriggered = false;

    public bool WitchDialogueFinished = false;

    private void Update()
    {
        if (!WitchDialogueFinished && !DialogTriggered)//If we're in range
        {
            interactAction.Invoke();
            DialogTriggered = true;
        }
        if (WitchDialogueFinished)
        {
            StartBossRound1.enabled = false;
            StartBossRound2.enabled = false;

            Witch.transform.position = new Vector3(47.3f, 6.47f, 0f);
        }

    }

    public void WitchDialogueFinishedMethod()
    {
        WitchDialogueFinished = true;
    }

}