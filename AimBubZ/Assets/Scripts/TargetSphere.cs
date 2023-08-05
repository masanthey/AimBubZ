using UnityEngine;

public class TargetSphere : MonoBehaviour
{
    [Header("Movement")]
    public bool OnMove;
    public float Speed;
   // private Transform PointA;
   // private Transform PointB;
    //private bool isMovementFromAtoB = true;
   // private Vector3 destPos;

    [Header("LiveTime")]
    public bool HaveLiveTime;
    public float MaxLiveTime;
    private float liveTime = 0f;

    [Header("OtherSettings")]
    public float Size;
    public float Health;

    private GameMode _GameModeSingalton;
    private TargetSpawn _TargetSpawnSingalton;

    ///////////////////////////////////

    private Vector3 targetPosition;
    [SerializeField] private float changeDirectionDistance = 5f;
    public float minMoveX = -5f;
    public float maxMoveX = 5f;
    public float minMoveY = -5f;
    public float maxMoveY = 5f;


    private void Start()
    {
        _TargetSpawnSingalton = TargetSpawn.TargetSpawnSingalton;
        _GameModeSingalton = GameMode.GameModeSingalton;
        Size = _GameModeSingalton.TargetSize;
        Health = _GameModeSingalton.TargetHealth;
        Speed = _GameModeSingalton.TargetSpeed;
        gameObject.GetComponent<Transform>().localScale = gameObject.GetComponent<Transform>().localScale * Size;

        if (MaxLiveTime == 0f)
            HaveLiveTime = false;
        if (Speed > 0f)
            OnMove = true;

        /////////
        targetPosition = transform.position;
    }

    private void Update()
    {

        if (!_TargetSpawnSingalton.IsStart) 
        {
            Destroy(gameObject);
        }

        if (HaveLiveTime) 
        {
            if(liveTime >= MaxLiveTime)
                Destroy(gameObject);
            else
               liveTime -= Time.deltaTime;
        }

        if (OnMove) 
        {
            Moving();
          // if (isMovementFromAtoB)
          //    destPos = PointA.position;
          // else
          //     destPos = PointB.position;
          //
          //  float step = Speed * Time.deltaTime;
          //  transform.position = Vector3.MoveTowards(transform.position, destPos, step);
          //
          //  if (transform.position == destPos)
          //     isMovementFromAtoB = !isMovementFromAtoB;
        }
    }

    private void OnDestroy()
    {
        GlobalEventManager.TargetDie();
    }

    public void TakeDamage(float dmg) 
    {
        Health -= dmg;
        if (HaveLive())
        {
            GlobalEventManager.TargetDiePerPlayer();
            Destroy(gameObject);
        }
    }

    private bool HaveLive() 
    {
        return Health <= 0;
    }

    private void Moving() 
    {
        if (Vector3.Distance(transform.position, targetPosition) < changeDirectionDistance)        
            targetPosition = new Vector3(
                Random.Range(_TargetSpawnSingalton.PointB.position.x, _TargetSpawnSingalton.PointA.position.x), 
                Random.Range(_TargetSpawnSingalton.PointB.position.y, _TargetSpawnSingalton.PointA.position.y),
               _TargetSpawnSingalton.PointB.position.z);      

        transform.position = Vector3.Lerp(transform.position, targetPosition, Speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(targetPosition - transform.position);
    }
}
