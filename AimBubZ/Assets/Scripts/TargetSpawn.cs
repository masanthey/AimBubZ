using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public Transform PointA, PointB;
    public bool IsStart;
    private GameMode _GameModeSingalton;
    public GameObject Targets;
    public static TargetSpawn TargetSpawnSingalton { get; private set; }

    private float MaxCountTargets;
    private float TimePerSpawnTargets;

    private float totalCountTargets;
    private float timeCnt;

    private void Start()
    {
        _GameModeSingalton = GameMode.GameModeSingalton;
        UpdateSettings();
        totalCountTargets = 0;
    }

    private void Awake()
    {
        if (TargetSpawnSingalton != null && TargetSpawnSingalton != this)
            Destroy(this);
        else
            TargetSpawnSingalton = this;

        GlobalEventManager.OnTargetDie.AddListener(SubtractFromTotalCountTargets);
    }

    private void Update()
    {
        UpdateSettings();
        if (_GameModeSingalton.ModeValue == Mode.Default  || _GameModeSingalton.ModeValue == Mode.Control)
        {
            if (IsStart)
            {
                if (totalCountTargets < MaxCountTargets)
                {
                    if (timeCnt <= 0)
                    {
                        Vector3 randomPosition = new Vector3(
                            Random.Range(PointB.position.x, PointA.position.x),
                            Random.Range(PointA.position.y, PointB.position.y),
                            PointA.position.z);
                        Instantiate(Targets, randomPosition, PointA.rotation);
                        totalCountTargets++;
                        timeCnt = TimePerSpawnTargets;
                    }
                    else
                        timeCnt -= Time.deltaTime;
                }
            }

        }
         else if(_GameModeSingalton.ModeValue == Mode.Reaction) 
          {
              if (IsStart)
              {
                  if (totalCountTargets <= MaxCountTargets)
                  {
                      if (timeCnt <= 0)
                      {
                          GlobalEventManager.TargetSpawn();
                          Vector3 randomPosition = new Vector3(0f, 11f, 45f);
                          Instantiate(Targets, randomPosition, PointA.rotation);
                          totalCountTargets++;
                          timeCnt = Random.Range(1f,7f);
                      }
                      else
                          timeCnt -= Time.deltaTime;
                  }
              }
          }
    }


    public void UpdateSettings()
    {
        MaxCountTargets = _GameModeSingalton.MaxCountTargets;
        TimePerSpawnTargets = _GameModeSingalton.TimePerSpawnTargets;
    }
    private void SubtractFromTotalCountTargets() 
    {
        totalCountTargets -= 1;
    }

}


