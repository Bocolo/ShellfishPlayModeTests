using NUnit.Framework;/*
using Submit.UI;*/
using Save.Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SaveTests
{
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null;
       

    }
    [Test]
    public void SaveDataUserProfile()
    {
   
        User savedUser = new User()
        {
            Name = "Test User",
            Company = "Test Company",
            Email = "Test Email",
            SubmittedSamplesCount = 10
        };
        SaveData.Instance.SaveUserProfile(savedUser);
        User loadedUser = SaveData.Instance.LoadUserProfile();
        Assert.AreEqual(savedUser,loadedUser);
    }
}