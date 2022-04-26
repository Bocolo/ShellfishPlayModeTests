using NUnit.Framework;
using System.Collections;
using TMPro;
using UI.Authentication;
using UI.Navigation;
using UI.Profile;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class LoginUITests
{
    private LoginUIManager logInOutButtonManager;
    private Menu menu;
    private GameObject manager;
    private GameObject loginGO;
    private GameObject logoutGO;
    private Button loginButton;
    private Button logoutButton;

    private AppManager appManager;

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
        loginGO = GameObject.Find("Canvas_Menu/Panel/Container/Button_Login");
        logoutGO = GameObject.Find("Canvas_Menu/Panel/Container/Button_Logout");

        appManager = new AppManager();
        yield return null;
        loginButton = loginGO.GetComponent<Button>();
        logoutButton = logoutGO.GetComponent<Button>();
        logInOutButtonManager = manager.GetComponent<LoginUIManager>();
        menu = manager.GetComponent<Menu>();
    }
    /// <summary>
    /// Retieves bool of firebase auth login and tests button interactability
    /// </summary>
    [Test]
    public void General()
    {

        SceneManager.LoadScene(0);
        if (appManager.IsLoggedInDB())
        {


            Assert.IsFalse(loginButton.interactable);
            Assert.IsTrue(logoutButton.interactable);

        }
        else
        {
            Assert.IsTrue(loginButton.interactable);
            Assert.IsFalse(logoutButton.interactable);
        }
    }


}

/*   [Test]
   public void LoggedOut_Test()
   {
       logInOutButtonManager.IsLoggedIn = false;
       SceneManager.LoadScene(0);
       Assert.IsTrue(loginButton.interactable);
       Assert.IsFalse(logoutButton.interactable);
   }
   [Test]
   public void LoggedIn_Test()
   {
       logInOutButtonManager.IsLoggedIn = true;
       SceneManager.LoadScene(0);

       Assert.IsFalse(loginButton.interactable);
       Assert.IsTrue(logoutButton.interactable);
   }
   [UnityTest]
   public IEnumerator aLoggedOut_Test()
   {
       logInOutButtonManager.IsLoggedIn = false;
       SceneManager.LoadScene(0);
       yield return null;
       Assert.IsTrue(loginButton.interactable);
       Assert.IsFalse(logoutButton.interactable);
   }
   [UnityTest]
   public IEnumerator aLoggedIn_Test()
   {
       logInOutButtonManager.IsLoggedIn = true;
       yield return null;
       SceneManager.LoadScene(0);
       yield return null;
       Assert.IsTrue(logoutButton.interactable);
       Assert.IsFalse(loginButton.interactable);

   }*/