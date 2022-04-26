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
    private GameObject _manager;
    private PopUp _popup;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null;
        _manager = GameObject.Find("Managers/MenuManager");
        GameObject popUpGO = GameObject.Find("Canvas_Menu/Panel/Container/Pop_UP_Object");
        _popup = popUpGO.GetComponent<PopUp>();
    }
    [Test]
    public void Acknowledge_Popup_Test()
    {
        _popup.gameObject.SetActive(true);
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);
        _popup.PopUpAcknowleged();
        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
    }
    [Test]
    public void SetText_Popup_Test()
    {
        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.SetPopUpText("Pop Up Text");
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);
        TMP_Text text = _popup.GetComponentInChildren<TMP_Text>();
        Assert.IsNotNull(text);
        Assert.AreEqual("\n\nPop Up Text", text.text); 
        Assert.AreNotEqual("\n\nPop Up Pop Text", text.text);//review this test in edit modse

    }
    [Test]
    public void SuccessfulLogin_Popup_Test()
    {
      
        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.SuccessfulLogin();
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);

    }
    [Test]
    public void UnsuccessfulLogin_Popup_Test()
    {

        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.UnSuccessfulLogin();
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);

    }
    [Test]
    public void UnSuccessfulSignUp_Popup_Test()
    {

        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.UnSuccessfulSignUp();
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);

    }
    [Test]
    public void SuccessfulSignUp_Popup_Test()
    {

        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.SuccessfulSignUp();
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);

    }

  
}
