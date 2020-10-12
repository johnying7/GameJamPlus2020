using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUi : MonoBehaviour
{
    public GameObject uiObject;
    public GameObject defaultButton;
    // Start is called before the first frame update
    void Start()
    {
        defaultButton.GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            toggleGamePause(!uiObject.activeSelf);
        }
    }

    public void resumeGame()
    {
        Debug.Log("Resuming Game!");
        toggleGamePause(false);
    }

    public void quitGame()
    {
        Debug.Log("Quitting Game!");
        Application.Quit();
    }

    public void toggleGamePause(bool pause)
    {
        if (pause)
        {
            uiObject.SetActive(pause);
            Time.timeScale = 0;
        }
        else
        {
            uiObject.SetActive(pause);
            Time.timeScale = 1.0f;
        }
    }
}
