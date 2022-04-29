using App.Navigation;
using App.Profile.UI;
using App.SaveSystem.Manager;
using NUnit.Framework;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
/// <summary>
/// tests the profile manager script
/// </summary>
public class ProfileManagerTests
{
    private ProfileManager _profileManager;
    private Menu _menu;
    private GameObject _manager;
    private GameObject _profile;
    private GameObject _name;
    private GameObject _company;
    private GameObject _saveButton;
    private GameObject _updateButton;
    private TMP_InputField _userNameInput;
    private TMP_InputField _companyInput;

    /// <summary>
    /// setting the game objects and scene
    /// </summary>
    /// <returns></returns>
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null; 
        SceneManager.LoadScene(4);
        yield return null;
        _manager = GameObject.Find("Core/ProfileManager");

        yield return null;
        _profileManager = _manager.GetComponent<ProfileManager>();
     
        yield return null;
        ///Inelegant method of retrieval of gameObjects but useable for play mode tests
        _profile = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Inputs/ProfileDetails/Profile_Text");
        _name = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Inputs/Name_input");
        _company = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Inputs/Company_input");
        _saveButton = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Buttons/Save_Profile");
        _updateButton = GameObject.Find("Canvas_Profile/Panel_Main/Scroll_View/Viewport/Content/Panel/Buttons/UpdateButton/Update_Profile");
   
    }
    /// <summary>
    /// tests SaveProfile successfully save the profile passed to input the input fields
    /// </summary>
    [Test]
    public void SaveProfile_User_Test()
    {
        _menu = _manager.AddComponent<Menu>();
        _menu.LogOut();
        _userNameInput = _name.GetComponent<TMP_InputField>();
        _companyInput = _company.GetComponent<TMP_InputField>();
        string nameText = "SaveProfile Test Name"; ;
        string companyText = "SaveProfile Test Company";
        _userNameInput.text = nameText;
        _companyInput.text = companyText;
        _profileManager.SaveProfile();
        Assert.AreEqual(nameText, SaveData.Instance.LoadUserProfile().Name);
        Assert.AreEqual(companyText, SaveData.Instance.LoadUserProfile().Company);

    }
    /// <summary>
    /// tests SaveProfile activates the excpected game objects
    /// </summary>
    [Test]
    public void SaveProfile_View_Test()
    {
        _profileManager.SaveProfile();

        Assert.IsTrue(_profile.activeInHierarchy);
        Assert.IsTrue(_updateButton.activeInHierarchy);
        Assert.IsFalse(_name.activeInHierarchy);
        Assert.IsFalse(_company.activeInHierarchy);
        Assert.IsFalse(_saveButton.activeInHierarchy);
    }
    /// <summary>
    /// tests GoToUpdateProfile activates the excpected game objects
    /// </summary>
    [Test]
    public void UpdateProfile_View_Test()
    {
        _profileManager.GoToUpdateProfile();
        Assert.IsFalse(_profile.activeInHierarchy);
        Assert.IsFalse(_updateButton.activeInHierarchy);
        Assert.IsTrue(_name.activeInHierarchy);
        Assert.IsTrue(_company.activeInHierarchy);
        Assert.IsTrue(_saveButton.activeInHierarchy);
      
    }
}
