using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEffect : MonoBehaviour
{
    public GameObject Effect;
    private void Awake()
    {
        GlobalEventManager.OnPlayerShoot.AddListener(PlayShootEffect);
    }

    private void PlayShootEffect()
    {
        Instantiate(Effect, transform.position, transform.rotation);
    }
}
