using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // references
    public GameObject storyButton;
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject quitButton;

    public GameObject settingsBackButton;

    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject storyPanel;


    private void Start()
    {
        CloseMenus();
        mainMenuPanel.SetActive(true);


        storyButton.GetComponent<Button>().onClick.AddListener(StoryButtonPressed);
        playButton.GetComponent<Button>().onClick.AddListener(PlayButtonPressed);
        settingsButton.GetComponent<Button>().onClick.AddListener(SettingsButtonPressed);
        settingsBackButton.GetComponent<Button>().onClick.AddListener(BackButtonPressed);
        
    }

    private void CloseMenus()
    {
        settingsPanel.SetActive(false);
        storyPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
    }

    private void StoryButtonPressed()
    {
        Debug.Log("Storybutton pressed");
    }

    private void PlayButtonPressed()
    {
        Debug.Log("Will go to the game scene or the story scene.");
    }

    private void SettingsButtonPressed()
    {
        CloseMenus();
        settingsPanel.SetActive(true);
    }

    private void QuitButtonPressed()
    {
        Application.Quit();
    }

    private void BackButtonPressed()
    {
        CloseMenus();
        mainMenuPanel.SetActive(true);
    }

    // settings buttons

}
