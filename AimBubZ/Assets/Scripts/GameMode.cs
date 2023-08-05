using UnityEngine;

public class GameMode : MonoBehaviour
{
    public static GameMode GameModeSingalton { get; private set; }

    [SerializeField] private GameObject ReactionTimer;
    [SerializeField] private GameObject ScorePointer;

    public Mode ModeValue;

    public float TargetSize;
    public float TargetLiveTime;
    public float TargetHealth;
    public float MaxCountTargets;
    public float TargetSpeed;
    public float TimePerSpawnTargets;

    private void Awake()
    {
        if (GameModeSingalton != null && GameModeSingalton != this)
            Destroy(this);
        else
            GameModeSingalton = this;
    }

    private void Update()
    {
        UpdateSettings();// del 
    }

    public void UpdateSettings() 
    {
        if (ModeValue == Mode.Reaction)
        {
            TargetSize = 10f;
            TargetHealth = 1f;
            MaxCountTargets = 1;
            TargetSpeed = 0f;
        }
        if(ModeValue == Mode.FastAim) 
        {

        }
        if (ModeValue == Mode.Control)
        {
            MaxCountTargets = 1;
            TargetLiveTime = 3600f;
        }
    }

    public void SetModeValue(Mode value) 
    {
        ModeValue = value;
    }
    public void SetTargetSize(float value) 
    {
        TargetSize = value;
    }
    public void SetTargetLiveTime(float value)
    {
        TargetLiveTime = value;
    }
    public void SetTargetHealth(float value)
    {
        TargetHealth = value;
    }
    public void SetMaxCountTargets(float value)
    {
        MaxCountTargets = value;
    }
    public void SetTargetSpeed(float value)
    {
        TargetSpeed = value;
    }
    public void SetTimePerSpawnTargets(float value)
    {
        TimePerSpawnTargets = value;
    }

    public void SetGameModeDefault() 
    {
        ModeValue = Mode.Default;
    }
    public void SetGameModeReactiom()
    {
        ModeValue = Mode.Reaction;
    }
}

public enum Mode
{
    Default,
    Reaction,
    FastAim,
    Control,
};
