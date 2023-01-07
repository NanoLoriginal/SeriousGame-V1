using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> puzzleList = new List<GameObject>();
    [SerializeField] public List<GameObject> puzzlePiecesList = new List<GameObject>();
    [SerializeField] private GameObject PlantPrefab;
    [SerializeField] private ParticleSystem plantedFX;
    [SerializeField] private TextMesh floatingTextPrefab;

    [SerializeField] private Canvas questCanva;
    [SerializeField] private Canvas InfoCanva;

    private int compteur;

    private int doOnce = 0;

    private void Start()
    {
        compteur = 0;
    }

    private void Update()
    {
        StartCoroutine(check());
    }

    IEnumerator check()
    {
        
        checkLevelFinished();
        new WaitForSeconds(1);
        yield return null;
    }

    void checkLevelFinished()
    {
        for (int i = 0; i < puzzleList.Count; i++)
        {
            if(puzzleList[i].GetComponent<PuzzlePieceScript>().getFilled() == true)
            {
                compteur++;
            }
        }

        if ((compteur == puzzleList.Count) && doOnce == 0)
        {
            setLevelFinished();
            StopAllCoroutines();
            doOnce = 1;
        }
        else
        {
            compteur = 0;
        }
    }

    public void setLevelFinished()
    {
        for (int i = 0; i < puzzleList.Count; i++)
        {
            puzzleList[i].GetComponent<MeshRenderer>().enabled = false;
            puzzleList[i].GetComponentInParent<MeshRenderer>().enabled = false;
            puzzlePiecesList[i].GetComponentInParent<MeshRenderer>().enabled = false;

            puzzleList[i].SetActive(false);
        }


        ParticleSystem pFX = Instantiate<ParticleSystem>(plantedFX);
        pFX.transform.position = transform.position + new Vector3(0, 1, 0);



        pFX.Play();

        if (floatingTextPrefab)
        {
            ShowFloatingText();
        }

        GameObject p = Instantiate(PlantPrefab);
        p.transform.position = this.transform.position;
        p.transform.localScale = new Vector3(20, 20, 20);


        questCanva.enabled = false;

        InfoCanva.enabled = true;
        InfoCanva.gameObject.SetActive(true);

    }

    void ShowFloatingText()
    {
        var tm = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
        tm.GetComponent<TextMesh>().text = "Successfully planted !";
        
    }
}
