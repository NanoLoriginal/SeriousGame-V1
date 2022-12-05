using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingButton : MonoBehaviour
{
    [SerializeField] private Canvas infoCanvas;

    private bool isDisplayed = false;

    public void activateCanvas(bool val)
    {
        infoCanvas.gameObject.SetActive(val);
    }

    public bool getDisplayed() { 
        return isDisplayed;
    }
    public void setDisplayed(bool val)
    {
        isDisplayed = val;
    }

}
