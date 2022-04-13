using Data.Submit;
using NUnit.Framework;/*
using Submit.UI;*/
using Save.Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SubmitSampleManagerTest
{
    //test upload store syubmit&savce
    private SubmitSampleManager submitSampleManager;
    private GameObject manager;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(3);
        yield return null;
        yield return null;
        manager = GameObject.Find("Core/RetrieveManager");

        yield return null;
        submitSampleManager = manager.GetComponent<SubmitSampleManager>();
        yield return null;

    }

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
        submitSampleManager.SubmitAndSaveStoredSamples();

        int storedSampleCountAfter = SaveData.Instance.UsersStoredSamples.Count;
        int submittedSampleCountAfter = SaveData.Instance.UsersSubmittedSamples.Count;
        Debug.LogFormat("Stored count {0} and ~Submit count {1}", storedSampleCountAfter, submittedSampleCountAfter);
        Assert.AreNotEqual(storedSampleCount, storedSampleCountAfter);
        Assert.AreEqual(0, storedSampleCountAfter);
        Assert.AreNotEqual(submittedSampleCount, submittedSampleCountAfter);
        Assert.AreEqual(submittedSampleCount+1, submittedSampleCountAfter);
    }
}
