using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] GameMode GM;
    [SerializeField] GameObject ReacrionHUD;
    [SerializeField] GameObject FastAimHUD;

    void Update()
    {
        if (GM.ModeValue == Mode.Reaction)       
            ReacrionHUD.SetActive(true);       
        else
            ReacrionHUD.SetActive(false);


        if (GM.ModeValue == Mode.FastAim)
            FastAimHUD.SetActive(true);
        else
            FastAimHUD.SetActive(false);
    }
}
