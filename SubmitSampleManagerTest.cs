using App.Samples.Manager;
using App.SaveSystem.Manager;
using NUnit.Framework;
using Samples.Data;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
/// <summary>
/// Tests the submit sample manager script
/// </summary>
public class SubmitSampleManagerTest
{
    private SubmitSampleManager _submitSampleManager;
    private GameObject _manager;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(3);
        yield return null;
        _manager = GameObject.Find("Core/RetrieveManager");

        yield return null;
        _submitSampleManager = _manager.GetComponent<SubmitSampleManager>();
        yield return null;

    }
    /// <summary>
    /// This tests the SubmitAndSaveStoredSamples function
    /// cleared the stored samples list and increases the submitted samples list by 1
    /// </summary>
    [Test]
    public void Submit_And_Save_Sample_Test()
    {
        SaveData.Instance.AddToStoredSamples(new Sample
        {
            Name = "Test Name One",
            Species="Test Species One"
        });
        int storedSampleCount = SaveData.Instance.UsersStoredSamples.Count;
        int submittedSampleCount = SaveData.Instance.UsersSubmittedSamples.Count;
        Debug.LogFormat("Stored count {0} and ~Submit count {1}", storedSampleCount, submittedSampleCount);
        _submitSampleManager.SubmitAndSaveStoredSamples();

        int storedSampleCountAfter = SaveData.Instance.UsersStoredSamples.Count;
        int submittedSampleCountAfter = SaveData.Instance.UsersSubmittedSamples.Count;
        Debug.LogFormat("Stored count {0} and ~Submit count {1}", storedSampleCountAfter, submittedSampleCountAfter);
        Assert.AreNotEqual(storedSampleCount, storedSampleCountAfter);
        Assert.AreEqual(0, storedSampleCountAfter);
        Assert.AreNotEqual(submittedSampleCount, submittedSampleCountAfter);
        Assert.AreEqual(submittedSampleCount+1, submittedSampleCountAfter);
    }
}
