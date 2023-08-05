using UnityEngine;

public class MenuControl : MonoBehaviour
{
	[SerializeField] private  GameObject _canvas;
     public bool Paused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Paused == true)
			{
				Pause();
				Paused = false;
			}
			else
			{
				Resume();
				Paused = true;
			}
		}
	}
	public void Pause()
	{
		Time.timeScale = 0.0f;
		_canvas.gameObject.SetActive(true);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
	}

	public void Resume()
	{
		Time.timeScale = 1.0f;
		_canvas.gameObject.SetActive(false);
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}
