using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResUISettings : MonoBehaviour
{
    public List<string> list = new List<string>() { "test0 (to)", "test1 (t1)" };
    public TMP_Dropdown TMPDropdown;
    public TMP_Text text;
    Resolution[] resolutions;

    void Start()
    {

        resolutions = Screen.resolutions;
        TMPDropdown.options.Clear();
        // Print the resolutions
        foreach (var res in resolutions)
        {
            TMPDropdown.options.Add(new TMP_Dropdown.OptionData() { text = res.width.ToString() + "x" + res.height.ToString() + " : " + res.refreshRate.ToString() });
        }
    }

    public void SetRes(int resIndex)
    {
        Screen.SetResolution(resolutions[resIndex].width, resolutions[resIndex].height, false);
        Canvas.ForceUpdateCanvases();
    }

}

