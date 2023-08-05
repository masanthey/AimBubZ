using UnityEngine.Events;

public class GlobalEventManager 
{
    public static UnityEvent OnPlayerShoot = new UnityEvent();
    public static UnityEvent OnTargetDiePerPlayer = new UnityEvent();
    public static UnityEvent OnTargetDie = new UnityEvent();
    public static UnityEvent OnTargetSpawn = new UnityEvent();
    public static UnityEvent OnPlayerHitTarget = new UnityEvent();

    public static void SendPlayerShooted() 
    {
        OnPlayerShoot.Invoke();
    }
    public static void TargetDiePerPlayer() 
    {
        OnTargetDiePerPlayer.Invoke();
    }

    public static void TargetDie()
    {
        OnTargetDie.Invoke();
    }

    public static void TargetSpawn()
    {
        OnTargetSpawn.Invoke();
    }
    public static void PlayerHitEnemy()
    {
        OnPlayerHitTarget.Invoke();
    }
}
