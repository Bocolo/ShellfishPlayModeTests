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
    /// <summary>
    /// do somthing to get all the inputs and set them
    /// </summary>
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
        //do all the get component and check those values

    }
    [UnityTest]
    public IEnumerator SubmitCanvasManager_CompleteSubmission()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name",
            Company = "Test Company"
        });
        yield return null;
        submitCanvasManager.CompleteSubmission();
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
        Assert.IsTrue(submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);
    }
    [UnityTest]
    public IEnumerator SubmitCanvasManager_CompleteStore()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name",
            Company = "Test Company"
        });
        yield return null;
        submitCanvasManager.CompleteStore();
        yield return null;
        Assert.AreEqual("Test Name", submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company", submitCanvasManager.Company.text);
        Assert.AreEqual("", submitCanvasManager.Comments.text);
        Assert.AreEqual(0, submitCanvasManager.Species.value);
        Assert.AreEqual(0, submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, submitCanvasManager.YearDrop.value);
        Assert.IsTrue(submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);
    }
    [UnityTest]
    public IEnumerator SubmitCanvasManager_SwitchCanvas()
    {

        ///gotta do get for compoenets
        ///

       /* GameObject smallCanvas = submitCanvasManager.GetSmallCanvas();//GameObject.Find("/Canvas_SMALL");
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
      */
    }
   /* [Test]//any need for this when edit test cover it
    public void PopUp_Active()
    {
        submitCanvasManager.DisplayPopUP("Pop up text test");
     //   Assert.AreEqual("Pop up text test", submitCanvasManager.MissingValuesPopUp.text);
        Assert.True(submitCanvasManager.MissingValuesPopUp.isActiveAndEnabled);
        submitCanvasManager.HidePopUp();
        Assert.False(submitCanvasManager.MissingValuesPopUp.isActiveAndEnabled);
    }*/
}
