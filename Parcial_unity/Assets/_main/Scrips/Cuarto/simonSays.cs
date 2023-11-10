using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System;

public class simonSays : MonoBehaviour
{
    public List<int> simonList, userList;
    public Animator[] anim;
    public TextMeshProUGUI roundText, loserText, retryButtonText;
    public Image retryButtonUI;
    public Button retryButton;

    private int i, randomNum, max = 1, interval = 1, count = 0, y;
    private bool SimonIsPlaying = true, checkValues = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("newRound"); //Starts the first round
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) //Green Color
        {
            userList.Add(0); //Adds the id color to the list
            action(0); //Executes the colors effect
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) //Red Color
        {
            userList.Add(1); //Adds the id color to the list
            action(1); //Executes the colors effect
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) //Blue Color
        {
            userList.Add(2); //Adds the id color to the list
            action(2); //Executes the colors effect
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) //Yellow Color
        {
            userList.Add(3); //Adds the id color to the list
            action(3); //Executes the colors effect
        }

        if (userList.Count == simonList.Count)
        { //If they have the same number of color triggered, continue

            StartCoroutine("checkLists"); //Waits 1 sec before checking the values
                                          //(if not, after the player ends, inmediately will start the new game)

            if (checkValues)
            {
                for (y = 0; y < simonList.Count; y++)
                {
                    if (userList[y] != simonList[y])
                    {
                        count++;
                    }
                    else if (userList[y] == simonList[y])
                    {
                        Debug.Log("Todas ok");
                    }
                }

                if (count == 0)
                {
                    Debug.Log("Proximo!");
                    roundText.text = max.ToString(); //Shows the current round
                    SimonIsPlaying = true;
                    StartCoroutine("newRound");
                }
                else if (count > 0)
                {
                    Debug.Log("Perdio!");
                    loserText.enabled = true;
                    retryButtonUI.enabled = true;
                    retryButtonText.enabled = true;
                    retryButton.enabled = true;
                }
            }
        }
    }

    IEnumerator changeBool(int x)
    {
        yield return new WaitForSeconds(1);
        anim[x].SetBool("KeyPress", false); //Changes the bool to stop the animation and keep it on idle state
    }

    IEnumerator newRound()
    {

        if (SimonIsPlaying)
        {

            //Reset the lists every new round!
            simonList = new List<int>();
            userList = new List<int>();

            for (i = 0; i < max; i++)
            {
                randomNum = UnityEngine.Random.Range(0, 4); //Makes a random Number between 0 - 3
                simonList.Add(randomNum); //Adds the number to a list
                action(randomNum); //Executes the effect for that color

                yield return new WaitForSeconds(interval); //1 Sec interval between each color cycle
            }

            max++; //Adds +1 color for the next round
            SimonIsPlaying = false;
        }
    }

    IEnumerator checkLists()
    {
        yield return new WaitForSeconds(1); //Wait 1 sec to compare the lists
        checkValues = true;
        yield return new WaitForSeconds(1); //Wait 1 sec to turn off the bool
        checkValues = false;
    }

    void action(int id) //Turn brighter the light of the specific color
    {
        anim[id].SetBool("KeyPress", true);
        StartCoroutine("changeBool", id);
    }

    /*public void restartGame()
    {
        SceneManager.LoadScene(0);
    }*/
}
