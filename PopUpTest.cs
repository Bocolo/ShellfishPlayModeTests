using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UI.Popup;
using UnityEngine.SceneManagement;
using UI.Navigation;
using TMPro;

public class PopUpTest
{
    private Menu menu;
    private GameObject manager;
    private PopUp popup;
  // private GameObject popUp;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null;
        manager = GameObject.Find("Managers/MenuManager");

        yield return null;
        menu = manager.GetComponent<Menu>();
        yield return null;
        GameObject popUpGO = GameObject.Find("Canvas_Menu/Panel/Container/Pop_UP_Object");
        popup = popUpGO.GetComponent<PopUp>();

    }
    [Test]
    public void Acknowledge_Popup_Test()
    {
        popup.gameObject.SetActive(true);
        Assert.IsTrue(popup.gameObject.activeInHierarchy);
        popup.PopUpAcknowleged();

        Assert.IsFalse(popup.gameObject.activeInHierarchy);
    }
    [Test]
    public void SetText_Popup_Test()
    {

        Assert.IsFalse(popup.gameObject.activeInHierarchy);
        popup.SetPopUpText("Pop Up Text");
        Assert.IsTrue(popup.gameObject.activeInHierarchy);
        TMP_Text text = popup.GetComponentInChildren<TMP_Text>();
        Assert.IsNotNull(text);
        Assert.AreEqual("\n\nPop Up Text", text.text); 
        Assert.AreNotEqual("\n\nPop Up Pop Text", text.text);

    }
    [Test]
    public void SuccessfulLogin_Popup_Test()
    {
      
        Assert.IsFalse(popup.gameObject.activeInHierarchy);
        popup.SuccessfulLogin();
        Assert.IsTrue(popup.gameObject.activeInHierarchy);

    }
    [Test]
    public void UnsuccessfulLogin_Popup_Test()
    {

        Assert.IsFalse(popup.gameObject.activeInHierarchy);
        popup.UnSuccessfulLogin();
        Assert.IsTrue(popup.gameObject.activeInHierarchy);

    }
    [Test]
    public void UnSuccessfulSignUp_Popup_Test()
    {

        Assert.IsFalse(popup.gameObject.activeInHierarchy);
        popup.UnSuccessfulSignUp();
        Assert.IsTrue(popup.gameObject.activeInHierarchy);

    }
    [Test]
    public void SuccessfulSignUp_Popup_Test()
    {

        Assert.IsFalse(popup.gameObject.activeInHierarchy);
        popup.SuccessfulSignUp();
        Assert.IsTrue(popup.gameObject.activeInHierarchy);

    }

  
}
