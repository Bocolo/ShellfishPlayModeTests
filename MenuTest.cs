using App.Navigation;
using App.SaveSystem.Manager;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
/// <summary>
/// Tests the Menu Class and BackToMenu class
/// </summary>
public class MenuTest
{
    private Menu _menu;
    private BackToMenu _backToMenu;
    private GameObject _manager;
    /// <summary>
    /// Setting up the unity scene and accessing the relevant Game Objects and components
    /// </summary>
    /// <returns></returns>

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null;
        _manager = GameObject.Find("Managers/MenuManager");
        yield return null;
        _menu = _manager.GetComponent<Menu>();
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
        _backToMenu = go.AddComponent<BackToMenu>();
        _menu.SubmitPage();
        yield return null;
        Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);
        _backToMenu.ReturnToMenu();
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
        _menu.LogOut();
        Assert.AreEqual(null, SaveData.Instance.LoadUserProfile().Name);

    }
    /// <summary>
    /// tests SubmitPage method
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator LoadedSceneIs_SubmitPage()
    {
        _menu.SubmitPage();
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
        _menu.UserSamplesPage();
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
        _menu.ProfilePage();
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
        _menu.LoginPage();
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
        _menu.HelpPage();
        yield return null;
        Assert.AreEqual(6, SceneManager.GetActiveScene().buildIndex);
    }
}
