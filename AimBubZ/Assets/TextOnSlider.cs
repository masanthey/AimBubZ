using UnityEngine.UI;
using UnityEngine;

public class TextOnSlider : MonoBehaviour
{
    private Slider slider;
    private void Start()
    {
        slider = GetComponentInParent<Slider>();
    }
    void Update()
    {
        this.GetComponent<Text>().text = "" + slider.value ;
    }
}
