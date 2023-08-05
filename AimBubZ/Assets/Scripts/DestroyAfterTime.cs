using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
	public float Delay = 0.1f;
	private Transform EffectPosition;

    private void Start()
    {
		EffectPosition = GameObject.Find("ShootEffectPoint").GetComponent<Transform>();

	}

    void Update()
	{
		transform.position = EffectPosition.position;
		Delay -= Time.deltaTime;
		if (Delay < 0f)
			GameObject.Destroy(this.gameObject);
	}
}
