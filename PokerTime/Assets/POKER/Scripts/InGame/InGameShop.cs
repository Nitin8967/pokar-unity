﻿using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameShop : MonoBehaviour
{
    public GameObject itemScreen, diamondScreen, pointScreen;

    public Text pointText, diamondText, coinsText;

    [SerializeField]
    private PlayerGameDetails playerData;

    public Text playerGold;

    public Button[] menuBtn;

    public void OnEnable()
    {
        playerData = PlayerManager.instance.GetPlayerGameData();

        UpdateAlltext(playerData);

        OnClickOnButton("item");
        /*playerGold.text= "" + (int)playerData.balance;*/

        //pointText.text = Utility.GetTrimmedAmount("" + PlayerManager.instance.GetPlayerGameData().points);
        //diamondText.text = Utility.GetTrimmedAmount("" + PlayerManager.instance.GetPlayerGameData().diamonds);
        //coinsText.text = Utility.GetTrimmedAmount("" + PlayerManager.instance.GetPlayerGameData().coins);

        string requestData = "{\"shopCategoryId\":\"\"}";
        WebServices.instance.SendRequest(RequestType.GetShopValues, requestData, true, OnServerResponseFound);
    }

    private void Start()
    {
        var colors = menuBtn[0].GetComponent<Button>().colors;
        colors.normalColor = new Color32(255, 255, 255, 255);
        menuBtn[0].GetComponent<Button>().colors = colors;
    }

    private void UpdateAlltext(PlayerGameDetails playerData)
    {
        coinsText.text = Utility.GetTrimmedAmount("" + playerData.coins);
        diamondText.text = Utility.GetTrimmedAmount("" + playerData.diamonds);
        pointText.text = Utility.GetTrimmedAmount("" + playerData.points);
    }

    public void OnClickOnButton(string eventName)
    {
        SoundManager.instance.PlaySound(SoundType.Click);

        switch (eventName)
        {
            case "back":
                {
                    if (InGameUiManager.instance != null) {
                        InGameUiManager.instance.DestroyScreen(InGameScreens.InGameShop);
                    } else {
                        MainMenuController.instance.DestroyScreen(MainMenuScreens.InGameShop);
                    }
                    
                }
                break;

            case "item":
                {
                    itemScreen.SetActive(true);
                    diamondScreen.SetActive(false);
                    pointScreen.SetActive(false);

                    int val = 0;
                    for (int i = 0; i < menuBtn.Length; i++)
                    {
                        var colors = menuBtn[i].GetComponent<Button>().colors;
                        if (i == val)
                        {
                            colors.normalColor = new Color32(255, 255, 255, 255);                            
                        }
                        else {
                            colors.normalColor = new Color32(255, 255, 255, 0);
                        }
                        menuBtn[i].GetComponent<Button>().colors = colors;
                    }
                    
                }
                break;

            case "point":
                {
                    itemScreen.SetActive(false);
                    diamondScreen.SetActive(false);
                    pointScreen.SetActive(true);

                    int val = 2;
                    for (int i = 0; i < menuBtn.Length; i++)
                    {
                        var colors = menuBtn[i].GetComponent<Button>().colors;
                        if (i == val)
                        {
                            colors.normalColor = new Color32(255, 255, 255, 255);
                        }
                        else
                        {
                            colors.normalColor = new Color32(255, 255, 255, 0);
                        }
                        menuBtn[i].GetComponent<Button>().colors = colors;
                    }
                }
                break;


            case "diamond":
                {
                    itemScreen.SetActive(false);
                    diamondScreen.SetActive(true);
                    pointScreen.SetActive(false);

                    int val = 1;
                    for (int i = 0; i < menuBtn.Length; i++)
                    {
                        var colors = menuBtn[i].GetComponent<Button>().colors;
                        if (i == val)
                        {
                            colors.normalColor = new Color32(255, 255, 255, 255);
                        }
                        else
                        {
                            colors.normalColor = new Color32(255, 255, 255, 0);                           
                        }
                        menuBtn[i].GetComponent<Button>().colors = colors;
                    }
                }
                break;

            default:
                {
                    Debug.LogError("Unhandled eventName found in RealTimeResultUiManager = " + eventName);
                }
                break;
        }
    }

    public void OnClickOnBuyButton(string eventName)
    {
        switch (eventName)
        {
            case "item_one":
                {
                    Debug.Log("Item One");
                    string requestData = "{\"userId\":\"" + playerData.userId + "\"," +
                                "\"shopId\":\"" + 10 + "\"," +
                                "\"itemType\":\"" + "ITEM" + "\"}";

                    WebServices.instance.SendRequest(RequestType.GetInGameShopValue, requestData, true, OnServerResponseFound);
                }
                break;
            case "item_two":
                {
                    Debug.Log("Item Two");
                    string requestData = "{\"userId\":\"" + playerData.userId + "\"," +
                                "\"shopId\":\"" + 16 + "\"," +
                                "\"itemType\":\"" + "ITEM" + "\"}";

                    WebServices.instance.SendRequest(RequestType.GetInGameShopValue, requestData, true, OnServerResponseFound);
                }
                break;
            case "item_three":
                {
                    Debug.Log("Item Three");
                    string requestData = "{\"userId\":\"" + playerData.userId + "\"," +
                                "\"shopId\":\"" + 13 + "\"," +
                                "\"itemType\":\"" + "ITEM" + "\"}";

                    WebServices.instance.SendRequest(RequestType.GetInGameShopValue, requestData, true, OnServerResponseFound);
                }
                break;
            case "diamond_one":
                {
                    Debug.Log("Diamond One");
                    string requestData = "{\"userId\":\"" + playerData.userId + "\"," +
                                "\"shopId\":\"" + 23 + "\"," +
                                "\"itemType\":\"" + "DIAMOND" + "\"}";

                    WebServices.instance.SendRequest(RequestType.GetInGameShopValue, requestData, true, OnServerResponseFound);
                }
                break;
            case "diamond_two":
                {
                    Debug.Log("Diamond Two");
                    string requestData = "{\"userId\":\"" + playerData.userId + "\"," +
                                "\"shopId\":\"" + 24 + "\"," +
                                "\"itemType\":\"" + "DIAMOND" + "\"}";

                    WebServices.instance.SendRequest(RequestType.GetInGameShopValue, requestData, true, OnServerResponseFound);
                }
                break;
            case "diamond_three":
                {
                    Debug.Log("Diamond Three");
                    string requestData = "{\"userId\":\"" + playerData.userId + "\"," +
                                "\"shopId\":\"" + 23 + "\"," +
                                "\"itemType\":\"" + "DIAMOND" + "\"}";

                    WebServices.instance.SendRequest(RequestType.GetInGameShopValue, requestData, true, OnServerResponseFound);
                }
                break;
            case "point_one":
                {
                    Debug.Log("Point One");
                    string requestData = "{\"userId\":\"" + playerData.userId + "\"," +
                                "\"shopId\":\"" + 29 + "\"," +
                                "\"itemType\":\"" + "POINT" + "\"}";

                    WebServices.instance.SendRequest(RequestType.GetInGameShopValue, requestData, true, OnServerResponseFound);
                }
                break;
            case "point_two":
                {
                    Debug.Log("Point Two");
                    string requestData = "{\"userId\":\"" + playerData.userId + "\"," +
                                "\"shopId\":\"" + 30 + "\"," +
                                "\"itemType\":\"" + "POINT" + "\"}";

                    WebServices.instance.SendRequest(RequestType.GetInGameShopValue, requestData, true, OnServerResponseFound);
                }
                break;
            case "point_three":
                {
                    Debug.Log("Point Three");
                    string requestData = "{\"userId\":\"" + playerData.userId + "\"," +
                                "\"shopId\":\"" + 32 + "\"," +
                                "\"itemType\":\"" + "POINT" + "\"}";

                    WebServices.instance.SendRequest(RequestType.GetInGameShopValue, requestData, true, OnServerResponseFound);
                }
                break;
        }
    }

    public void OnServerResponseFound(RequestType requestType, string serverResponse, bool isShowErrorMessage, string errorMessage)
    {
        if (errorMessage.Length > 0)
        {
            if (isShowErrorMessage)
            {
                if (InGameUiManager.instance != null)
                {
                    InGameUiManager.instance.ShowMessage(errorMessage);
                }
                else
                {
                    MainMenuController.instance.ShowMessage(errorMessage);
                }
            }
            return;
        }
        if (requestType == RequestType.GetShopValues)
        {
            Debug.Log("Response => GetShopValues(InGame): " + serverResponse);
            JsonData data = JsonMapper.ToObject(serverResponse);            
        }

        if (requestType == RequestType.GetUserDetails)
        {
            Debug.Log("Response => GetUserDetails(InGame): " + serverResponse);
            JsonData data = JsonMapper.ToObject(serverResponse);

            if (data["success"].ToString() == "1")
            {
                for (int i = 0; i < data["getData"].Count; i++)
                {
                    playerData.coins = float.Parse(data["getData"][i]["coins"].ToString());
                    playerData.diamonds = float.Parse(data["getData"][i]["diamond"].ToString());
                    playerData.points = float.Parse(data["getData"][i]["points"].ToString());

                    UpdateAlltext(playerData);

                    if (MenuHandller.instance != null)
                    {
                        MenuHandller.instance.UpdateAllText();
                    }
                    //LobbyUiManager.instance.coinsText.text = Utility.GetTrimmedAmount("" + PlayerManager.instance.GetPlayerGameData().coins);                
                }
            }
        }

        if (requestType == RequestType.GetInGameShopValue)
        {
            Debug.Log("Response => GetInGameShopValues: " + serverResponse);
            JsonData data = JsonMapper.ToObject(serverResponse);

            if (data["status"].Equals(true))
            {
                Debug.Log("Purchase Successfull !!!");
                WebServices.instance.SendRequest(RequestType.GetUserDetails, "{\"userId\":\"" +
                    PlayerManager.instance.GetPlayerGameData().userId+ "\"}", true, OnServerResponseFound);

                if (null== InGameUiManager.instance)
                {
                    MainMenuController.instance.ShowMessage(data["response"].ToString());
                    if (MenuHandller.instance != null)
                    {
                        MenuHandller.instance.UpdateAllText();
                    }
                    //LobbyUiManager.instance.coinsText.text = Utility.GetTrimmedAmount("" + PlayerManager.instance.GetPlayerGameData().coins);
                }
                else
                {
                    InGameUiManager.instance.ShowMessage(data["response"].ToString());
                }
            }
            else
            {
                Debug.Log("You don't have sufficient fund to purchase");
                if (null == InGameUiManager.instance)
                {
                    MainMenuController.instance.ShowMessage(data["response"].ToString());
                    if (MenuHandller.instance != null)
                    {
                        MenuHandller.instance.UpdateAllText();
                    }
                    //LobbyUiManager.instance.coinsText.text = Utility.GetTrimmedAmount("" + PlayerManager.instance.GetPlayerGameData().coins);
                }
                else
                {
                    InGameUiManager.instance.ShowMessage(data["response"].ToString());
                }
            }
        }
    }
}