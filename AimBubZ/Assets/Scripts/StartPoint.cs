using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private TargetSpawn _TargetSpawnSingalton;

    private void Start() 
    {
        _TargetSpawnSingalton = TargetSpawn.TargetSpawnSingalton;
    }

    public void OnTrigger() 
    {
        _TargetSpawnSingalton.IsStart = !_TargetSpawnSingalton.IsStart;
    }
}
