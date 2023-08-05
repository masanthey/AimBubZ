using UnityEngine;

public class ShootPoint : MonoBehaviour
{
    private float TimeFireRate;
    [SerializeField] private float TimeReload;
    [SerializeField] private MenuControl MC;
    void Update()
    {
        if (TimeFireRate <= 0)
        {
            if (Input.GetMouseButton(0) && MC.Paused)
            {
                Shoot();
                TimeFireRate = TimeReload;
            }
        } 
        else
            TimeFireRate -= Time.deltaTime;
    }

    public void Shoot() 
    {
        GlobalEventManager.SendPlayerShooted();

        RaycastHit hitInfo;
        Ray ray = new Ray(transform.position, transform.forward );
        Physics.Raycast(ray, out hitInfo);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Target"))
            {
                GlobalEventManager.PlayerHitEnemy();
                hitInfo.collider.GetComponent<TargetSphere>().TakeDamage(1f);
            }
            if (hitInfo.collider.CompareTag("Start"))
            {
                hitInfo.collider.GetComponent<StartPoint>().OnTrigger();
            }
        }
    }
}
