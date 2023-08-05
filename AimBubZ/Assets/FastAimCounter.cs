using UnityEngine;

public class FastAimCounter : MonoBehaviour
{
    private int count;
    private TargetSpawn _TargetSpawnSingalton;

    private void Start()
    {
        GlobalEventManager.OnTargetDiePerPlayer.AddListener(AddCount);
        
    }

    private void AddCount() 
    {

    }
}
