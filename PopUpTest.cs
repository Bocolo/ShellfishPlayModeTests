using App.UI;
using NUnit.Framework;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PopUpTest
{
    private GameObject _manager;
    private PopUp _popup;
    /// <summary>
    /// sets the required scene and game objects for tesing
    /// </summary>
    /// <returns></returns>
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null;
        _manager = GameObject.Find("Managers/MenuManager");
        GameObject popUpGO = GameObject.Find("Canvas_Menu/Panel/Container/Pop_UP_Object");
        _popup = popUpGO.GetComponent<PopUp>();
    }
    /// <summary>
    /// test that PopUpAcknowleged deactivates its attached gameobject 
    /// </summary>
    [Test]
    public void Acknowledge_Popup_Test()
    {
        _popup.gameObject.SetActive(true);
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);
        _popup.PopUpAcknowleged();
        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
    }
    /// <summary>
    /// tests SetPopUpText sets the text as expected
    /// </summary>
    [Test]
    public void SetText_Popup_Test()
    {
        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.SetPopUpText("Pop Up Text");
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);
        TMP_Text text = _popup.GetComponentInChildren<TMP_Text>();
        Assert.IsNotNull(text);
        Assert.AreEqual("\n\nPop Up Text", text.text); 
        Assert.AreNotEqual("\n\nPop Up Pop Text", text.text);

    }
    /// <summary>
    /// test that SuccessfulLogin activates its attached gameobject 
    /// </summary>
    [Test]
    public void SuccessfulLogin_Popup_Test()
    {
      
        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.SuccessfulLogin();
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);

    }
    /// <summary>
    /// test that UnSuccessfulLogin activates its attached gameobject 
    /// </summary>
    [Test]
    public void UnsuccessfulLogin_Popup_Test()
    {

        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.UnSuccessfulLogin();
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);

    }
    /// <summary>
    /// test that UnSuccessfulSignUp activates its attached gameobject 
    /// </summary>
    [Test]
    public void UnSuccessfulSignUp_Popup_Test()
    {

        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.UnSuccessfulSignUp();
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);

    }
    /// <summary>
    /// test that SuccessfulSignUp activates its attached gameobject 
    /// </summary>
    [Test]
    public void SuccessfulSignUp_Popup_Test()
    {

        Assert.IsFalse(_popup.gameObject.activeInHierarchy);
        _popup.SuccessfulSignUp();
        Assert.IsTrue(_popup.gameObject.activeInHierarchy);

    }

  
}
