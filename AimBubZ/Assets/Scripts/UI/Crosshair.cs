using UnityEngine;
using UnityEngine.UI;
public class Crosshair : MonoBehaviour
{
    [SerializeField] private CHLine UpLine_Image;
    [SerializeField] private CHLine LeftLine_Image;
    [SerializeField] private CHLine RightLine_Image;
    [SerializeField] private CHLine DownLine_Image;
    [SerializeField] private GameObject Point_Image;

    [Header("CrossHairSettings")]
    [SerializeField] private float Ch_Gap; // size per dot and line
    [SerializeField] private float Ch_Dot; // dot size | 0 = Disable, 0 > Enable
    [SerializeField] private float Ch_Long;
    [SerializeField] private float Ch_Thickness;
    [SerializeField] private float Ch_pointScale;
     private Color Ch_Color;
    [SerializeField] private float ColorR;
    [SerializeField] private float ColorG;
    [SerializeField] private float ColorB;
    [SerializeField] private float ColorT;

    private void Start()
    {
        GetData();
    }

    void Update() // delete this
    {
        ApplySettings();
    }

    public void ApplySettings() 
    {
        Ch_Color.a = ColorT;
        Ch_Color.b = ColorB;
        Ch_Color.g = ColorG;
        Ch_Color.r = ColorR;

        UpLine_Image.LineInitialize(Ch_Gap, Ch_Long, Ch_Thickness, Ch_Color); // LineInitialize(float gap, float _long, float thickness, Color _color)
        LeftLine_Image.LineInitialize(Ch_Gap, Ch_Long, Ch_Thickness, Ch_Color);
        RightLine_Image.LineInitialize(Ch_Gap, Ch_Long, Ch_Thickness, Ch_Color);
        DownLine_Image.LineInitialize(Ch_Gap, Ch_Long, Ch_Thickness, Ch_Color);
        Point_Image.GetComponent<Image>().color = Ch_Color;
        Vector3 pointScale = new Vector3(Ch_Dot, Ch_Dot, Ch_Dot);
        Point_Image.GetComponent<RectTransform>().localScale = pointScale;
    }

    public void ResetDataToDefaultSettings()
    {
        PlayerPrefs.SetFloat("Ch_Gap", 9f);
        PlayerPrefs.SetFloat("Ch_Dot", 0f);
        PlayerPrefs.SetFloat("Ch_Long", 0.1f);
        PlayerPrefs.SetFloat("Ch_Thickness", 0.07f);
        PlayerPrefs.SetFloat("ColorR", 0f);
        PlayerPrefs.SetFloat("ColorB", 0f);
        PlayerPrefs.SetFloat("ColorG", 0f);
        PlayerPrefs.SetFloat("ColorT", 1f);
        PlayerPrefs.Save();
        GetData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("Ch_Gap", Ch_Gap);
        PlayerPrefs.SetFloat("Ch_Dot", Ch_Dot);
        PlayerPrefs.SetFloat("Ch_Long", Ch_Long);
        PlayerPrefs.SetFloat("Ch_Thickness", Ch_Thickness);
        PlayerPrefs.SetFloat("ColorR", Ch_Color.r);
        PlayerPrefs.SetFloat("ColorB", Ch_Color.b);
        PlayerPrefs.SetFloat("ColorG", Ch_Color.g);
        PlayerPrefs.SetFloat("ColorT", Ch_Color.a);
        PlayerPrefs.Save();

    }

    public void GetData()
    {
        if (PlayerPrefs.HasKey("Ch_Gap"))
        {
            Ch_Gap = PlayerPrefs.GetFloat("Ch_Gap");
            Ch_Dot = PlayerPrefs.GetFloat("Ch_Dot");
            Ch_Long = PlayerPrefs.GetFloat("Ch_Long");
            Ch_Thickness = PlayerPrefs.GetFloat("Ch_Thickness");
            ColorR = PlayerPrefs.GetFloat("ColorR");
            ColorG = PlayerPrefs.GetFloat("ColorG");
            ColorB = PlayerPrefs.GetFloat("ColorB");
            ColorT = PlayerPrefs.GetFloat("ColorT");
            Ch_Color.a = ColorT;
            Ch_Color.b = ColorB;
            Ch_Color.g = ColorG;
            Ch_Color.r = ColorR;
        }
        else
        {
            ResetDataToDefaultSettings();
        }
    }

    public void SetColorR(float Value)
    {
        ColorR = Value;
    }
    public void SetColorG(float Value)
    {
        ColorG = Value;
    }
    public void SetColorB(float Value)
    {
        ColorB = Value;
    }
    public void SetCh_Gap(float Value)
    {
        Ch_Gap = Value;
    }
    public void SetCh_Dot(float Value)
    {
        Ch_Dot = Value;
    }
    public void SetCh_Long(float Value)
    {
        Ch_Long = Value;
    }
    public void SetCh_Thickness(float Value)
    {
        Ch_Thickness = Value;
    }
    
}
