using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMaker : MonoBehaviour
{
    public GameObject redBox;
    public GameObject blueBox;
    public GameObject greenBox;
    public GameObject yellowBox;
    private GameObject[] PrefabList;
    private List<List<GameObject>> Grid;
    // Start is called before the first frame update
    void Start()
    {
        Grid = new List<List<GameObject>>();
        PrefabList = new GameObject[4] { redBox, blueBox, greenBox, yellowBox};
        CreateGrid();
        FillNeighbourList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateGrid()
    {
        float yPos = 4f;
        for (int i = 0; i < 8; i++)
        {
            Grid.Add(new List<GameObject>());
            float xPos = -2.18f;
            
            for (int j = 0; j < 5; j++)
            {
                int randChoice = Random.Range(0, 4);
                Grid[i].Add(Instantiate(PrefabList[randChoice], new Vector3(xPos, yPos, 0), Quaternion.identity));
                xPos += 1.1f;
                
            }
            yPos -= 1.1f; 
        }
    }

    void FillNeighbourList()
    {
        for(int i = 0; i < Grid.Count; i++)
        {
            for(int j = 0; j < Grid[i].Count; j++)
            {
                if (i == 0)
                {
                    if (j == 0)
                    {
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j + 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j]); 
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j + 1]);
                    }
                    else if (j == 4)
                    {
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j]);
                    }
                    else
                    {
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j + 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j + 1]);
                    }
                }
                else if (i == 7)
                {
                    if (j == 0)
                    {
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j+1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j + 1]);
                    }
                    else if (j == 4)
                    {
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j - 1]);
                    }
                    else
                    {
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j + 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j + 1]);
                    }
                }
                else
                {
                    if (j == 0)
                    {
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j+1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j + 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j + 1]);
                    }
                    else if (j == 4)
                    {
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j - 1]);
                    }
                    else
                    {
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j-1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i - 1][j + 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i][j + 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j - 1]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j]);
                        Grid[i][j].GetComponent<Box>().neighbourList.Add(Grid[i + 1][j + 1]);
                    }
                }
            }
        }
    }
}
