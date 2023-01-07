using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieceScript : MonoBehaviour
{
    [SerializeField] private float Identity;
    [SerializeField] private bool Filled = false;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "drag")
        {
            if (other.gameObject.GetComponent<TruePuzzlePieceScript>() != null && other.gameObject.GetComponent<TruePuzzlePieceScript>().getPlaced() == false)
            {
                if (other.gameObject.GetComponent<TruePuzzlePieceScript>().getIdentity() == Identity)
                {

                    
                    Debug.Log("ça fonctionne frero");
                    

                    other.gameObject.transform.position = this.transform.position + new Vector3(0,1,0);
                    other.gameObject.transform.rotation = this.transform.rotation;
                    other.GetComponent<MeshCollider>().convex = false;
                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().freezeRotation = true;
                    other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    other.GetComponent<TruePuzzlePieceScript>().setPlaced();
                    Filled = true;
                    

                }
            }
        }

        
    }
    public bool getFilled()
    {
        return Filled;
    }
}
