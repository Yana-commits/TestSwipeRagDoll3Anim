using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button startBt;
    [SerializeField] private TextMeshProUGUI winLoseTxt;

    public Button restartBt;
    public Action OnStart; 

    private void Start()
    {
        startBt.onClick.AddListener(StartActions);
    }

    private void SetWinText(string infoText)
    {
        winLoseTxt.text = infoText;
    }
    public void StartActions()
    {
        panel.SetActive(false);
        startBt.gameObject.SetActive(false);
        OnStart?.Invoke();
    }
    public void GameOverPanel(string infoTxt)
    {
        panel.SetActive(true);
        restartBt.gameObject.SetActive(true);
        winLoseTxt.gameObject.SetActive(true);
        SetWinText(infoTxt);
    }
    private void OnDisable()
    {
        startBt.onClick.RemoveListener(StartActions);
        restartBt.onClick.RemoveAllListeners();
    }
}
