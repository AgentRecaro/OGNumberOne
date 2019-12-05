using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using Facebook.Unity.Example;
using UnityEngine.UI;

public class FacebookManager : MonoBehaviour
{
    private bool LoginOn = false;
    [SerializeField] private GameObject ButtonLogout = null;
    [SerializeField] private GameObject ButtonLogin = null;
    [SerializeField] private GameObject TextUsrtName = null;
    [SerializeField] private GameObject ImageFaceBook = null;
    [SerializeField] private GameObject NextScenec = null;

    private void Start()
    {
        FB.API ("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
        FB.API ("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);
    }

    void Awake()
    {
        FB.Init (SetInit, OnHideUnity);
    }

    void SetInit()
    {

        if (FB.IsLoggedIn) {
            Debug.Log ("FB is logged in");
        } else {
            Debug.Log ("FB is not logged in");
        }

        DealWithFBMenus (FB.IsLoggedIn);
    }

    void OnHideUnity(bool isGameShown)
    {

        if (!isGameShown) {
            Time.timeScale = 0;
        } else {
            Time.timeScale = 1;
        }

    }

    public void ButtonFacebookLogin()
    {

        List<string> permissions = new List<string> ();
        permissions.Add ("public_profile");

        FB.LogInWithReadPermissions (permissions, AuthCallBack);
    }

    void AuthCallBack(IResult result)
    {

        if (result.Error != null) {
            Debug.Log (result.Error);
        } else {
            if (FB.IsLoggedIn) {
                Debug.Log ("FB is logged in");
            } else {
                Debug.Log ("FB is not logged in");
            }

            DealWithFBMenus (FB.IsLoggedIn);
        }

    }

    void DealWithFBMenus(bool isLoggedIn)
    {

        if (isLoggedIn) {
            ButtonLogout.SetActive (true);
            ButtonLogin.SetActive (false);
            LoginOn = true;

            FB.API ("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
            FB.API ("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);

        } else {
            ButtonLogout.SetActive (false);
            ButtonLogin.SetActive (true);
        }

    }

    void DisplayUsername(IResult result)
    {

        Text UserName = TextUsrtName.GetComponent<Text> ();

        if (result.Error == null) {

            UserName.text = "" + result.ResultDictionary ["first_name"];

        } else {
            Debug.Log (result.Error);
        }

    }

    void DisplayProfilePic(IGraphResult result)
    {

        if (result.Texture != null) {

            Image ProfilePic = ImageFaceBook.GetComponent<Image> ();

            ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
            if (LoginOn == true)
            {
                NextScenec.GetComponent<SceneStart>().enabled = true;
            }
            
        }

    }
    
    public void Share()
    {
        FB.FeedShare (
            string.Empty,
            new Uri("https://www.facebook.com/Dek-Game-113975636732360/"),
            "",
            "",
            "",
            new Uri("https://uppic.cc/v/5z9m"),
            string.Empty,
            ShareCallback
        );
    }

    void ShareCallback(IResult result)
    {
        if (result.Cancelled) {
            Debug.Log ("Share Cancelled");
        } else if (!string.IsNullOrEmpty (result.Error)) {
            Debug.Log ("Error on share!");
        } else if (!string.IsNullOrEmpty (result.RawResult)) {
            Debug.Log ("Success on share");
        }
    }
    
    public void Invite()
    {
        FB.AppRequest("มาเล่นเกมกันเถอะ", null,null,null,null,"Data","Title",this.InviteCallback);
    }

    void InviteCallback(IResult result)
    {
        if (result.Cancelled) {
            Debug.Log ("Invite Cancelled");
        } else if (!string.IsNullOrEmpty (result.Error)) {
            Debug.Log ("Error on invite!");
        } else if (!string.IsNullOrEmpty (result.RawResult)) {
            Debug.Log ("Success on Invite");
        }
    }


}
