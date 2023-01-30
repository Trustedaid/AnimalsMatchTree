using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animals : MonoBehaviour
{
    private int animalX;
    private int animalY;

    public int columns = 0;
    public int rows = 0;

    public Sprite[] animalSprites;
    public GameObject animalPrefab;

    public Transform animalHolder;

    public Grid grid;



    public void Start()
    {

        SelectRandomSprite();

    }

    void Update()
    {

    }

    private void SelectRandomSprite()
    {
        animalX = 0;
        animalY = 0;




        for (int i = 0; i < (grid.gridSquares.Count); i++)
        {
            int randomAnimalIndex = Random.Range(0, animalSprites.Length);
            GameObject copyAnimals = Instantiate(animalPrefab);
            copyAnimals.transform.SetParent(animalHolder);
            copyAnimals.GetComponent<Image>().sprite = animalSprites[randomAnimalIndex];
            copyAnimals.GetComponent<RectTransform>().anchoredPosition = grid.gridSquares[1].GetComponent<RectTransform>().anchoredPosition;

            Debug.Log(grid.gridSquares[i].GetComponent<RectTransform>().anchoredPosition);
            Debug.Log(grid.gridSquares[i].name);
        }





    }

    

}
