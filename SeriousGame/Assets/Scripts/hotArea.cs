using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotArea : MonoBehaviour
{
    GameObject grRef;
    Graine grScript;

    [SerializeField] private float temp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "drag")
        {
            grRef = other.gameObject;
            grScript = grRef.GetComponent<Graine>();
            if (grScript.getTempNeeded() == temp && grScript.getIsGrabbed() == false)
            {
                grScript.setPlanted();
            }
        }

    }

    

}
