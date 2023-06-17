using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class RandomDamage : MonoBehaviour
{
    public GameObject[] damgeGameObject;
    public GameObject[] originalGameObject;
    public GameObject[] togglers;
    public bool[] isDamaged;
    public GameObject loseWinPanel;
    public GameObject testPanel;
    public TextMeshProUGUI losewinText;
    private void Start()
    {
        
        foreach (GameObject obj in damgeGameObject)
        {
            obj.SetActive(false);
           
        }

        int maxObjectsToEnable = Mathf.Min(damgeGameObject.Length, 5);
        int numberOfObjectsToEnable = Random.Range(1, maxObjectsToEnable + 1);
        Debug.Log(numberOfObjectsToEnable + " " + damgeGameObject.Length);

        
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < damgeGameObject.Length; i++)
        {
            availableIndices.Add(i);
            isDamaged[i] = true;
        }

       
        for (int i = 0; i < numberOfObjectsToEnable; i++)
        {
            if (availableIndices.Count == 0)
            {
                break; 
            }

            int randomIndex = Random.Range(0, availableIndices.Count);
            int chosenIndex = availableIndices[randomIndex];
            damgeGameObject[chosenIndex].SetActive(true);
            isDamaged[chosenIndex] = false;
           
            originalGameObject[chosenIndex].SetActive(false);
            availableIndices.RemoveAt(randomIndex);
        }
        
    }
   
    public void Check()
    {
        int num=0;
        for (int i = 0; i < isDamaged.Length; i++)
        {
            if (isDamaged[i] == togglers[i].GetComponent<Toggle>().isOn)
            {
                num++;
            }
        }
        if (num == isDamaged.Length)
        {
            print("good work");
            losewinText.text = "You Won";
        }
        else
        {
            print("You Fail");
            losewinText.text = "You Fail";
        }
        testPanel.SetActive(false);
        loseWinPanel.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
