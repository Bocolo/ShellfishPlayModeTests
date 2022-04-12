using System;
using System.Collections;
using NUnit.Framework;
using Save.Manager;
using UI.Navigation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class MenuTest
{
    private Menu menu;
    private BackToMenu backToMenu;
    private GameObject manager;
    /// <summary>
    /// There is a problem with playmode tests and the IEnum setUp
    /// Each test run individually passes but run in a batch, all but one
    /// will fail.
    /// Suspect due to the way the SetUp works.  Look into this
    /// KNOWN ISSUE : https://forum.unity.com/threads/running-tests-consecutively.781847/
    /// 
    /// issue arrises from dont destroy on load child obejct calling the firebase init
    /// </summary>
    /// <returns></returns>

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null;
        manager = GameObject.Find("Managers/MenuManager");
      
        yield return null;
        menu = manager.GetComponent<Menu>();
        yield return null;

    }
    [TearDown]
    public void Teardown()
    {
 /*       GameObject.Destroy(menu);
        GameObject.Destroy(manager);*/
    }
    [UnityTest]
    public IEnumerator BackToMenuTest()
    {
        GameObject go = new GameObject();
        backToMenu = go.AddComponent<BackToMenu>();
        menu.SubmitPage();
        yield return null;
        Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);
        backToMenu.ReturnToMenu();
        yield return null;
        Assert.AreEqual(0, SceneManager.GetActiveScene().buildIndex);
    }
    [UnityTest]
    public IEnumerator LoadedSceneIsZero()
    {

        yield return null;

        Assert.AreEqual(0, SceneManager.GetActiveScene().buildIndex);

    }
    [UnityTest]
    public IEnumerator Logout()
    {

        yield return null;
        menu.LogOut();
        Assert.AreEqual(null, SaveData.Instance.LoadUserProfile().Name);

    }
    [UnityTest]
    public IEnumerator LoadedSceneIs_SubmitPage()
    {

        menu.SubmitPage();
        yield return null;
        Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);
    }
    [UnityTest]
    public IEnumerator LoadedSceneIs_UserSamplesPage()
    {
        menu.UserSamplesPage();
        yield return null;
        Assert.AreEqual(3, SceneManager.GetActiveScene().buildIndex);
    }
    [UnityTest]
    public IEnumerator LoadedSceneIs_ProfilePage()
    {
        menu.ProfilePage();
        yield return null;
        Assert.AreEqual(4, SceneManager.GetActiveScene().buildIndex);
    }
    [UnityTest]
    public IEnumerator LoadedSceneIs_LoginPage()
    {
        menu.LoginPage();
        yield return null;
        Assert.AreEqual(5, SceneManager.GetActiveScene().buildIndex);
    }
    [UnityTest]
    public IEnumerator LoadedSceneIs_HelpPage()
    {
        menu.HelpPage();
        yield return null;
        Assert.AreEqual(6, SceneManager.GetActiveScene().buildIndex);
    }
   /* [UnityTest]
    public IEnumerator ReturnToMenu_SceneZero()
    {
        menu.SubmitPage();
        yield return null;
        Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);

        backToMenu.ReturnToMenu();
        yield return null;
        Assert.AreEqual(0, SceneManager.GetActiveScene().buildIndex);

    }*/
      /* [UnityTest]
        public IEnumerator LoadedSceneIs_RetrievalPage()
        {
        //temp test, works while logged in
            menu.RetrievalPage();
            yield return null;
            Assert.AreEqual(2, SceneManager.GetActiveScene().buildIndex);
        }*/
}

/*
[UnitySetUp]
public IEnumerator SetUp()
{
    SceneManager.LoadScene(0);
    yield return null;
    *//* try
     {*//*
    manager = GameObject.Find("Managers/MenuManager");
    //  Assert.That(manager, Is.Not.Null);
    *//*  }
      catch (Exception e)
      {*//*
    //   Debug.Log("Exception caught in menu test- manager retrieval: " + e.Message);
    // }
    yield return null;
    *//*  try
      {*//*
    menu = manager.GetComponent<Menu>();
    //  }
    // catch (Exception e)
    //  {
    //    Debug.Log("Exception caught in menu test-menu retrieval: " + e.Message);
    //    }
    yield return null;

}*/