using System;
using System.Collections;
using NUnit.Framework;
using Save.Manager;
using UI.Navigation;
using UI.Submit;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SubmitCanvasManagerTests
{
    private Menu menu;
    private GameObject manager;
    private GameObject submitManager;
    private SubmitCanvasManager submitCanvasManager;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null;
        manager = GameObject.Find("Managers/MenuManager");

        yield return null;
        menu = manager.GetComponent<Menu>();
        yield return null;

        menu.SubmitPage();
        yield return null;
        submitManager = GameObject.Find("Core/SubmitManager");
        yield return null;

        submitCanvasManager = submitManager.GetComponent<SubmitCanvasManager>();

    }
    [UnityTest]
    public IEnumerator SubmitCanvasManager_ResetFields()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name",
            Company = "Test Company"
        });
        yield return null;
        submitCanvasManager.OnSubmitResetFields();
        yield return null;
        Assert.AreEqual("Test Name",submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company", submitCanvasManager.Company.text);
        Assert.AreEqual("", submitCanvasManager.Comments.text );
        Assert.AreEqual(0,submitCanvasManager.Species.value);
        Assert.AreEqual(0, submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, submitCanvasManager.YearDrop.value);
    }
    [UnityTest]
    public IEnumerator SubmitCanvasManager_SwitchCanvas()
    {
        GameObject smallCanvas = submitCanvasManager.GetSmallCanvas();//GameObject.Find("/Canvas_SMALL");
        GameObject largeCanvas = submitCanvasManager.GetLargeCanvas();//GameObject.Find("/Canvas_LARGE");
        Assert.False(smallCanvas.activeInHierarchy);
        Assert.True(largeCanvas.activeInHierarchy);
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name",
            Company = "Test Company"
        });
        yield return null;
        submitCanvasManager.SwitchCanvas();
        yield return null;
        Assert.True(smallCanvas.activeInHierarchy);
        Assert.False(largeCanvas.activeInHierarchy);
        Assert.AreEqual("Test Name", submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company", submitCanvasManager.Company.text);
      
    }
    [Test]//any need for this when edit test cover it
    public void PopUp_Active()
    {
        submitCanvasManager.DisplayPopUP("Pop up text test");
        Assert.AreEqual("Pop up text test", submitCanvasManager.Pop_up.text);
        Assert.True(submitCanvasManager.Pop_up.isActiveAndEnabled);
        submitCanvasManager.HidePopUp();
        Assert.False(submitCanvasManager.Pop_up.isActiveAndEnabled);
    }
}
