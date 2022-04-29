using App.SaveSystem.Manager;
using NUnit.Framework;
using Samples.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Users.Data;
/// <summary>
/// tests the SAve Data Singleton
/// </summary>
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
    /// <summary>
    /// deletes and updates sample save files
    /// </summary>
    [TearDown]
    public void TearDown()
    {
        SaveData.Instance.DeleteSubmittedSamplesFromDevice();
        SaveData.Instance.UpdateSubmittedStoredSamples();
    }
    /// <summary>
    /// tets the save (and load) user profile function
    /// checking the returned user equals the saved user
    /// </summary>
    [Test]
    public void SaveUserProfile_Test()
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
    /// <summary>
    /// test saving and loading a sample
    /// using AddAndSaveSubmittedSample function
    /// </summary>
    [Test]
    public void AddAndSaveToSubmittedList_Test()
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
    /// <summary>
    /// test saving and loading a sample
    /// using AddAndSaveStoredSample function
    /// </summary>
    [Test]
    public void AddAndSaveToStoredList_Test()
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
    /// <summary>
    /// Test the save data singleton successfully adds a sample
    /// to the submitted samples list
    /// </summary>
    [Test]
    public void AddToSubmittedList_Test()
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
    /// <summary>
    /// Test the save data singleton successfully adds a sample
    /// to the stored samples list
    /// </summary>
    [Test]
    public void AddToStoredList_Test()
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
    /// <summary>
    /// tests UpdateSubmittedStoredSamples clears the stored
    /// sample list and save file, using a single sample
    /// </summary>
    [Test]
    public void UpdateSubmittedStoredSamples_Test_Simple()
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
    /// <summary>
    /// tests UpdateSubmittedStoredSamples clears the stored
    /// sample list and save file, using 2 samples
    /// compares list counts to test samples are being added and cleared
    /// </summary>
    [Test]
    public void UpdateSubmittedStoredSamples_Test_Extended()
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
        int afterUpdateSubmittedCount = SaveData.Instance.LoadAndGetSubmittedSamples().Count;

        Assert.AreEqual(beforeUpdateSubmittedCount + 1, afterUpdateSubmittedCount);
        Assert.AreEqual(afterUpdateStoredCount, 0);
        Assert.AreNotEqual(afterAddStoredCount, afterUpdateStoredCount);

    }
    /// <summary>
    /// test LoadAndGetSubmittedSamples returns a list
    /// </summary>
    [Test]
    public void LoadAndGetSubmittedSamplesTest()
    {
        List<Sample> afterLoad = SaveData.Instance.LoadAndGetSubmittedSamples();
        Assert.IsNotNull(afterLoad);
    }
    /// <summary>
    /// test LoadAndGetStoredSamples returns a list
    /// </summary>
    [Test]
    public void LoadAndGetStoredSamplesTest()
    {
        List<Sample> afterLoad = SaveData.Instance.LoadAndGetStoredSamples();
        Assert.IsNotNull(afterLoad);
    }
    /// <summary>
    /// tests ClearSubmittedSamplesList empties the submmitted samples list
    /// </summary>
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
    /// <summary>
    /// tests ClearStoredSamplesList empties the stored samples list
    /// </summary>
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