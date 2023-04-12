using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescisionManager : MonoBehaviour
{
    public GameObject acceptTimeline;
    public GameObject declineTimeline;

    public bool desciding = false;

    public void StartDescide() {
        desciding = true;
    }

    public void Choose(bool accepted) {
        desciding = false;
        if(accepted) {
            acceptTimeline.SetActive(true);
        } else {
            declineTimeline.SetActive(false);
        }
    }

    public void UpdateAcceptTimeline (GameObject newTimeline) {
        acceptTimeline = newTimeline;
    }

    public void UpdateDeclineTimeline(GameObject newTimeline) {
        declineTimeline = newTimeline;
    }
}
