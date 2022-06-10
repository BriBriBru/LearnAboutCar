using UnityEngine;
using UnityEngine.UI;

public class ChangeToggleColor : MonoBehaviour
{
    public Color newColor;

    private Toggle _toggle;
    private ColorBlock _colorBlock;

    void Start()
    {
        _toggle = gameObject.GetComponent<Toggle>();
        _colorBlock = _toggle.colors;
    }

    public void ChangeColor(bool isOn)
    {
        if (isOn)
        {
            _colorBlock.normalColor = newColor;
            _toggle.colors = _colorBlock;
        }
    }
}
