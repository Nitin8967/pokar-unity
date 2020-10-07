﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using LitJson;

public class ExchangeChips : MonoBehaviour
{
    public TextMeshProUGUI ChipsCount;
    public TMP_InputField Diamonds;
    public TMP_InputField PPChips;

    public Button ConfirmButton;

    public static ExchangeChips instance;

    public Button PTChipsTabButton, DiamondTabButton;
    public GameObject DiamondPanel, PTPanel;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        GetChips();
        DiamondTabButton.onClick.RemoveAllListeners();
        PTChipsTabButton.onClick.RemoveAllListeners();
        PTChipsTabButton.onClick.AddListener(() => OpenScreen("PTChips"));
        DiamondTabButton.onClick.AddListener(() => OpenScreen("Diamond"));
    }

    private void OpenScreen(string screenName)
    {
        Color c = new Color(1, 1, 1, 1);
        Color c1 = new Color(1, 1, 1, 0);

        switch (screenName)
        {
            case "PTChips":
                PTChipsTabButton.GetComponent<Image>().color = c;
                DiamondTabButton.GetComponent<Image>().color = c1;

                PTPanel.SetActive(true);
                DiamondPanel.SetActive(false);
                break;
            case "Diamond":
                PTChipsTabButton.GetComponent<Image>().color = c1;
                DiamondTabButton.GetComponent<Image>().color = c;

                DiamondPanel.SetActive(true);
                PTPanel.SetActive(false);
                break;
            default:
                break;
        }
    }

    private void GetChips()
    {
        string request = "{\"userId\":\"" + MemberListUIManager.instance.GetClubOwnerObject().userId + "\"," +
                        "\"clubId\":\"" + ClubDetailsUIManager.instance.GetClubId() + "\"," +
                        "\"uniqueClubId\":\"" + ClubDetailsUIManager.instance.GetClubUniqueId() + "\"," +
                        "\"clubStatus\":\"" + "1" + "\"}";

        UnityEngine.Debug.Log("data :" + request);

        MainMenuController.instance.ShowScreen(MainMenuScreens.Loading);
        WebServices.instance.SendRequest(RequestType.CreateClub, request, true, OnServerResponseFound);
    }

    public void OnServerResponseFound(RequestType requestType, string serverResponse, bool isShowErrorMessage, string errorMessage)
    {
        Debug.Log(serverResponse);
        MainMenuController.instance.DestroyScreen(MainMenuScreens.Loading);

        if (errorMessage.Length > 0)
        {
            if (isShowErrorMessage)
            {
                MainMenuController.instance.ShowMessage(errorMessage);
            }

            return;
        }

        switch (requestType)
        {
            case RequestType.GetClubDetails:
                {
                    JsonData data = JsonMapper.ToObject(serverResponse);
                }
                break;
            default:
#if ERROR_LOG
			Debug.LogError("Unhandled requestType found in  MenuHandller = "+requestType);
#endif
                break;
        }
    }
}