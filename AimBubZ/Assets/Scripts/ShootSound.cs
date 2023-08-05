using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSound : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip Shoot_Clip;
    [SerializeField] private AudioClip Hit_Clip;
    [SerializeField] private AudioClip Button_Clip;

    public float Volume = 0.5f;

    private void Awake()
    {
        GlobalEventManager.OnPlayerShoot.AddListener(PlayShootSound);
        GlobalEventManager.OnTargetDiePerPlayer.AddListener(PlayHitSound);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void PlayShootSound() 
    {
        audioSource.PlayOneShot(Shoot_Clip, Volume);
    }

    private void PlayHitSound() 
    {
        audioSource.PlayOneShot(Hit_Clip, Volume);
    } 
}
