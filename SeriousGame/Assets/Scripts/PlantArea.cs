using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantArea : MonoBehaviour
{
    GameObject grRef;
    Graine grScript;

    [SerializeField] private float tempAmount;
    [SerializeField] private float waterAmount;
    [SerializeField] private float dirtAmount;

    
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "drag")
        {
            grRef = other.gameObject;
            grScript = grRef.GetComponent<Graine>();
            Debug.Log("entrée if");

            if (grScript.getTempNeeded() == tempAmount && grScript.getWaterNeeded() == waterAmount && grScript.getDirtNeeded() == dirtAmount && grScript.getIsGrabbed() == false)
            {
                Debug.Log("planté");
                grScript.setPlanted();
            }
        }
    }
}
