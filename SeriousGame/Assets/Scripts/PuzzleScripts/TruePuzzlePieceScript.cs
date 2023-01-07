using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruePuzzlePieceScript : MonoBehaviour
{
    [SerializeField] private float Identity;
    [SerializeField] private bool IsPlaced = false;
    [SerializeField] private bool isGrabbed = false;



    public float getIdentity()
    {
        return Identity;
    }


    public bool getPlaced()
    {
        return IsPlaced;
    }

    public void setPlaced()
    {
        IsPlaced = true;
    }

    public bool getIsGrabbed()
    {
        return isGrabbed;
    }

    public void setIsGrabbed(bool val)
    {
        isGrabbed = val;
    }

}
