using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SetNewList : MonoBehaviour
{
    public List<TextLine> newText = new List<TextLine>();
    public DialougeController dc;
    public PlayableDirector pd;

    public void assignNewText() {

        Debug.Log(dc.timelines.IndexOf(pd));
        dc.currTimeline = dc.timelines.IndexOf(pd);

        dc.textId = 0;
        dc.toDisplay = newText;

    }
}
