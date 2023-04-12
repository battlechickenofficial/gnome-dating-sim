using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class DialougeController : MonoBehaviour
{
    public List<PlayableDirector> timelines = new List<PlayableDirector>();
    public int currTimeline = 0;

    public RectTransform textbox, targetBoxPosition, closedBoxPosition;
    public AudioSource _audio, _audio2;
    public TMP_Text text;
    public float speed;
    private int count = 0;
    public int textId = 0;

    public List<TextLine> toDisplay = new List<TextLine>();

    public bool closeBoxWhenDone = true;
    private bool textPlaying = false;
    private bool textWriting = false;


    public CamTarg cam;

    public void AddToTimeline() {
        currTimeline++;
    }

    public void PlayText()
    {
        timelines[currTimeline].playableGraph.GetRootPlayable(0).Pause();

        count = 0;
        textPlaying = true;

        if(closeBoxWhenDone)
            LeanTween.moveY(textbox, targetBoxPosition.position.y, .5f).setEase(LeanTweenType.easeInOutBack);

        text.text = "";
        StartCoroutine(ReadLine());
;    }

    private void Update()
    {
        if(textPlaying)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space)) {
                if(textWriting) {
                    StopAllCoroutines();
                    text.text = toDisplay[textId].text[count];
                    textWriting = false;
                } else {
                    count++;
                    text.text = "";
                    if (count >= toDisplay[textId].text.Length) 
                    {
                        if (closeBoxWhenDone)
                            LeanTween.moveY(textbox, closedBoxPosition.position.y, .5f).setEase(LeanTweenType.easeInOutBack);
                        textPlaying = false;
                        textId++;
                        
                        StartCoroutine(ResumeTimeline());
                    }
                    else
                    {
                        StartCoroutine(ReadLine());
                    }
                }
            }
        }
    }

    private IEnumerator ReadLine()
    {
        cam.target = toDisplay[textId].camTarget;
        textWriting = true;
        foreach(char c in toDisplay[textId].text[count])
        {
            yield return new WaitForSeconds(speed);
            text.text += c;
            if (Random.Range(0, 2) < 1)
                _audio.Play();
            else
                _audio2.Play();
        }
        textWriting = false;
    }

    private IEnumerator ResumeTimeline()
    {
        yield return new WaitForSeconds(0.5f);
        timelines[currTimeline].playableGraph.GetRootPlayable(0).Play();
    }
}
