using NUnit.Framework;/*
using Submit.UI;*/
using Save.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
public class SaveTests
{
    [OneTimeSetUp]
    public void SetUpScene()
    {
        SceneManager.LoadScene(0);

    }
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        yield return null;
    }
    [TearDown]
    public void TearDown()
    {
        SaveData.Instance.DeleteSubmittedSamplesFromDevice();
        SaveData.Instance.UpdateSubmittedStoredSamples();
    }
    [Test]
    public void SaveUserProfileTest()
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
        Assert.AreEqual(savedUser, loadedUser);
    }
    [Test]
    public void AddAndSaveToSubmittedListTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        SaveData.Instance.AddAndSaveSubmittedSample(sample);
        List<Sample> afterLoad = SaveData.Instance.LoadAndGetSubmittedSamples();
        Assert.AreEqual(sample, afterLoad[0]);
        Assert.AreNotEqual(new Sample(), afterLoad[0]);
    }
    [Test]
    public void AddAndSaveToStoredListTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        SaveData.Instance.AddAndSaveStoredSample(sample);
        List<Sample> afterLoad = SaveData.Instance.LoadAndGetStoredSamples();
        Assert.AreEqual(sample, afterLoad[0]);
        Assert.AreNotEqual(new Sample(), afterLoad[0]);
    }
    [Test]
    public void AddToSubmittedListTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        SaveData.Instance.AddToSubmittedSamples(sample);
        List<Sample> submittedSamples = SaveData.Instance.UsersSubmittedSamples;
        Assert.AreEqual(sample, submittedSamples[0]);
        Assert.AreEqual(sample.Name, submittedSamples[0].Name);
        Assert.AreNotEqual(new Sample(), submittedSamples[0]);
    }
    [Test]
    public void AddToStoredListTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        SaveData.Instance.AddToStoredSamples(sample);
        List<Sample> storedSamples = SaveData.Instance.UsersStoredSamples;
        Assert.AreEqual(sample, storedSamples[0]);
        Assert.AreEqual(sample.Name, storedSamples[0].Name);
        Assert.AreNotEqual(new Sample(), storedSamples[0]);
    }

    [Test]
    public void UpdateSubmittedStoredSamplesTestSimple()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        SaveData.Instance.AddToStoredSamples(sample);
        SaveData.Instance.UpdateSubmittedStoredSamples();
        List<Sample> storedSamples = SaveData.Instance.UsersStoredSamples;
        Assert.IsEmpty( storedSamples);
        List<Sample> loadedStoredSamples = SaveData.Instance.LoadAndGetStoredSamples();
        Assert.IsEmpty(loadedStoredSamples);

    }
    [Test]
    public void UpdateSubmittedStoredSamplesTestExtended()
    {
        Sample sampleA = new Sample
        {
            Name = "UpdateSubmitted_StoredSamples Test"
        };
        Sample sampleB = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        int beforeAddStoredCount = SaveData.Instance.LoadAndGetStoredSamples().Count;
        SaveData.Instance.AddAndSaveStoredSample(sampleA);
        int afterAddStoredCount = SaveData.Instance.LoadAndGetStoredSamples().Count;

        Assert.AreEqual(beforeAddStoredCount + 1, afterAddStoredCount);

        int beforeUpdateSubmittedCount = SaveData.Instance.LoadAndGetSubmittedSamples().Count;
        SaveData.Instance.AddToSubmittedSamples(SaveData.Instance.LoadAndGetStoredSamples()[0]);
        SaveData.Instance.UpdateSubmittedStoredSamples();
        int afterUpdateStoredCount = SaveData.Instance.LoadAndGetStoredSamples().Count;
        int afterUpdateSubmittedCount = SaveData.Instance.LoadAndGetSubmittedSamples().Count;// SaveData.Instance.LoadAndGetSubmittedSamples().Count;

        Assert.AreEqual(beforeUpdateSubmittedCount + 1, afterUpdateSubmittedCount);//new add
        Assert.AreEqual(afterUpdateStoredCount, 0);
        Assert.AreNotEqual(afterAddStoredCount, afterUpdateStoredCount);

    }
    [Test]
    public void LoadAndGetSubmittedSamplesTest()
    {
        List<Sample> afterLoad = SaveData.Instance.LoadAndGetSubmittedSamples();
        Assert.IsNotNull(afterLoad);
    }
    [Test]
    public void LoadAndGetStoredSamplesTest()
    {
        List<Sample> afterLoad = SaveData.Instance.LoadAndGetStoredSamples();
        Assert.IsNotNull(afterLoad);
    }
    [Test]
    public void ClearSubmittedTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToSubmittedList Test"
        };
        SaveData.Instance.AddToSubmittedSamples(sample);
        List<Sample> submittedSamples = SaveData.Instance.UsersSubmittedSamples;
        Assert.IsNotEmpty(submittedSamples);
        SaveData.Instance.ClearSubmittedSamplesList();
        Assert.IsEmpty(submittedSamples);
    }
    [Test]
    public void ClearStoredTest()
    {
        Sample sample = new Sample
        {
            Name = "AddToStoredList Test"
        };
        SaveData.Instance.AddToStoredSamples(sample);
        List<Sample> storedSamples = SaveData.Instance.UsersStoredSamples;
        Assert.IsNotEmpty(storedSamples);
        SaveData.Instance.ClearStoredSamplesList();
        Assert.IsEmpty(storedSamples);

        
    }
}