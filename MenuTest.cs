using System;
using System.Collections;
using NUnit.Framework;
using Save.Manager;
using UI.Navigation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
/// <summary>
/// Tests the Menu Class and BackToMenu class
/// </summary>
public class MenuTest
{
    private Menu menu;
    private BackToMenu backToMenu;
    private GameObject manager;
    /// <summary>
    /// Setting up the unity scene and accessing the relevant Game Objects and components
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
    /// <summary>
    /// Tests back to menu functionality
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// tests loaded scene
    /// </summary>
    /// <returns></returns>
    [Test]
    public void LoadedSceneIsZero()
    {
        Assert.AreEqual(0, SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// tests logout method
    /// </summary>
    /// <returns></returns>
    [Test]
    public void Logout()
    {

   //     yield return null;
        menu.LogOut();
        Assert.AreEqual(null, SaveData.Instance.LoadUserProfile().Name);

    }
    /// <summary>
    /// tests SubmitPage method
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator LoadedSceneIs_SubmitPage()
    {
        menu.SubmitPage();
        yield return null;
        Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// tests UserSamplesPage method
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator LoadedSceneIs_UserSamplesPage()
    {
        menu.UserSamplesPage();
        yield return null;
        Assert.AreEqual(3, SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// tests  menu.ProfilePage method
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator LoadedSceneIs_ProfilePage()
    {
        menu.ProfilePage();
        yield return null;
        Assert.AreEqual(4, SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// tests menu.LoginPage method
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator LoadedSceneIs_LoginPage()
    {
        menu.LoginPage();
        yield return null;
        Assert.AreEqual(5, SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// tests  menu.HelpPage method
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator LoadedSceneIs_HelpPage()
    {
        menu.HelpPage();
        yield return null;
        Assert.AreEqual(6, SceneManager.GetActiveScene().buildIndex);
    }
//retrieval page test required
}
