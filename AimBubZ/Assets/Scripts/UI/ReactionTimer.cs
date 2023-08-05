using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReactionTimer : MonoBehaviour
{
    private Text timerText;  
    private float elapsedTime;  
    private bool isRunning;

    private void Start()
    {
        timerText = GetComponent<Text>();
    }

    private void Awake()
    { 
        GlobalEventManager.OnTargetSpawn.AddListener(StartTimer);
        GlobalEventManager.OnTargetDiePerPlayer.AddListener(StopTimer);
    }


    private IEnumerator UpdateTimer()
    {
        while (isRunning)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = FormatTime(elapsedTime);
            yield return null;
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);
        return string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }


    public void StartTimer()
    {
        if (!isRunning)
        {
            isRunning = true;
            ResetTimer();
            StartCoroutine(UpdateTimer());
        }
    }

    public void StopTimer()
    {
        if (isRunning)
        {
            isRunning = false;
        }
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        timerText.text = FormatTime(elapsedTime);
    }
}
