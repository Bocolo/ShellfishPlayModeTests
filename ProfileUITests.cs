using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Save.Manager;
using TMPro;
using UI.Navigation;
using UI.Profile;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
public class ProfileUITests
{
    private ProfileUI profileUI;
    private Menu menu;
    private GameObject manager;
    private GameObject profile;
    private GameObject name;
    private GameObject company;
    private GameObject saveButton;
    private GameObject updateButton;
    private TMP_InputField _userNameInput;
    private TMP_InputField _companyInput;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null; 
        SceneManager.LoadScene(4);
        yield return null;
        manager = GameObject.Find("Core/ProfileManager");

        yield return null;
        profileUI = manager.GetComponent<ProfileUI>();
     
        yield return null;
        ///Inelegant method of retrieval of gameObjects but useable for play mode tests
        profile = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Inputs/ProfileDetails/Profile_Text");
        name = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Inputs/Name_input");
        company = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Inputs/Company_input");
        saveButton = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Buttons/Save_Profile");
        updateButton = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Buttons/UpdateButton/Update_Profile");
   
    }
    [Test]
    public void SaveProfile_User_Test()
    {
        menu = manager.AddComponent<Menu>();
        menu.LogOut();
        _userNameInput = name.GetComponent<TMP_InputField>();
        _companyInput = company.GetComponent<TMP_InputField>();
        string nameText = "SaveProfile Test Name"; ;
        string companyText = "SaveProfile Test Company";
        _userNameInput.text = nameText;
        _companyInput.text = companyText;
        profileUI.SaveProfile();
        Assert.AreEqual(nameText, SaveData.Instance.LoadUserProfile().Name);
        Assert.AreEqual(companyText, SaveData.Instance.LoadUserProfile().Company);

    }
    [Test]
    public void SaveProfile_View_Test()
    {
        menu = manager.AddComponent<Menu>();
        menu.LogOut();
        profileUI.SaveProfile();

        Assert.IsTrue(profile.activeInHierarchy);
        Assert.IsTrue(updateButton.activeInHierarchy);
        Assert.IsFalse(name.activeInHierarchy);
        Assert.IsFalse(company.activeInHierarchy);
        Assert.IsFalse(saveButton.activeInHierarchy);

    }
    [Test]
    public void UpdateProfile_View_Test()
    {
        profileUI.GoToUpdateProfile();
        Assert.IsFalse(profile.activeInHierarchy);
        Assert.IsFalse(updateButton.activeInHierarchy);
        Assert.IsTrue(name.activeInHierarchy);
        Assert.IsTrue(company.activeInHierarchy);
        Assert.IsTrue(saveButton.activeInHierarchy);
      
    }
}
