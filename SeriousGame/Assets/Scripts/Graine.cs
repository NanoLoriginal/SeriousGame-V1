using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graine : MonoBehaviour
{
    [SerializeField] private Color baseColor;
    [SerializeField] private Color plantedColor;


    [SerializeField] private float tempNeeded;
    [SerializeField] private float waterNeeded;
    [SerializeField] private float dirtNeeded;


    [SerializeField] private ParticleSystem plantedFX;
    [SerializeField] private GameObject plant;

    [SerializeField] private GameObject infoCanvas = null;

    [SerializeField] private GameObject floatingTextPrefab;

    private Material mat;
    private bool isGrabbed = false;
    
    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        baseColor = mat.color;
    }

    private void Update()
    {
        if(this.isGrabbed == true)
        {
            mat.color = baseColor;

            if(infoCanvas != null)
            {
                infoCanvas.SetActive(true);
            }
            
        }
        if(this.isGrabbed == false)
        {
            if(infoCanvas != null)
            {
                infoCanvas.SetActive(false);
            }
            
        }
    }

    public Color getColor()
    {
        return mat.color;
    }
    public void setBaseColor()
    {
        mat.color = baseColor;
    }
    public void setPlanted()
    {
        //mat.color = plantedColor;
        ParticleSystem pFX = Instantiate<ParticleSystem>(plantedFX);
        pFX.transform.position = transform.position;
        pFX.Play();
        GameObject p = Instantiate<GameObject>(plant);
        p.transform.position = transform.position;
        p.transform.localScale = new Vector3(340,340,340);

        //floating text pour dire que la graine est plantée 

        if (floatingTextPrefab)
        {
            ShowFloatingText();
        }

        GetComponent<SphereCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject,2f);
        

    }

    public float getTempNeeded() => tempNeeded;
    public float getWaterNeeded() => waterNeeded;
    public float getDirtNeeded() => dirtNeeded;
    

    public bool getIsGrabbed()
    {
        return isGrabbed;
    }

    public void setIsGrabbed(bool val)
    {
        isGrabbed = val;
    }

    void ShowFloatingText()
    {
        var tm = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        tm.GetComponent<TextMesh>().text = "Successfully planted !";
    }
}
