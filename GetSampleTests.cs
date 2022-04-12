using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UI.SampleDisplay;
using UI.Retrieve;

public class GetSampleTests
{
    [UnityTest]
    public IEnumerator SetSearchFieldTest()
    {
        GameObject go = new GameObject();
        SearchSampleUI searchSampleUI = go.AddComponent<SearchSampleUI>();
        searchSampleUI.SetUpTestVariables();
        searchSampleUI.SetSeachFieldTest(0);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "");
        searchSampleUI.SetSeachFieldTest(1);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "Name");
        searchSampleUI.SetSeachFieldTest(2);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "Company");
        searchSampleUI.SetSeachFieldTest(3);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "Species");
        searchSampleUI.SetSeachFieldTest(4);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "ProductionWeekNo");
        searchSampleUI.SetSeachFieldTest(5);
        Assert.AreEqual(searchSampleUI.SearchFieldSelection, "Date");
        yield return null;
    }
 /*   [UnityTest]
    public IEnumerator PrefabTest()
    {
        GameObject go1 = new GameObject();
      //  GetSampleData getSampleData = go1.AddComponent<GetSampleData>();
        SampleUI sampleUI = go1.AddComponent<SampleUI>();
        List<Sample> samples = new List<Sample>();
        samples.Add(new Sample());
        samples.Add(new Sample());
        samples.Add(new Sample());
        sampleUI.SetUpTestVariables();
        sampleUI.TextAndPrefabTest(samples);
        yield return null;
        int childPrefabCount = sampleUI.GetContentParent().transform.childCount;
        Assert.AreEqual(childPrefabCount, samples.Count);
        samples.Add(new Sample());
        samples.Add(new Sample());
        samples.Add(new Sample());
        samples.Add(new Sample());
        sampleUI.TextAndPrefabTest(samples);
        //waits for end of frame
        //child objects are destroyed in text and prefab, but child count does not update
        //untill end of frame
        yield return null;
        int childPrefabCount2 = sampleUI.GetContentParent().transform.childCount;
        Assert.AreEqual(childPrefabCount2, samples.Count);
        yield return null;
    }*/
    /*[UnityTest]
    public IEnumerator StoredSamplePrefabTest()
    {
        GameObject go1 = new GameObject();
        go1.AddComponent<SaveData>();
        GetSampleData getSampleData = go1.AddComponent<GetSampleData>();
        yield return null;
        SaveData.Instance.AddToStoredSamples(new Sample());
        SaveData.Instance.SaveStoredSamples();
        getSampleData.SetUpTestVariables();
        getSampleData.ShowStoredSamples();
        yield return null;
        int childPrefabCount = getSampleData.GetContentParent().transform.childCount;
        Debug.Log(childPrefabCount + "----" + SaveData.Instance.GetUserSubmittedSamples().Count);
        Assert.AreEqual(childPrefabCount, SaveData.Instance.GetUserStoredSamples().Count);
        yield return null;
    }
    [UnityTest]
    public IEnumerator SubmittedSamplePrefabTest()
    {
        GameObject go1 = new GameObject();
        go1.AddComponent<SaveData>();
        GetSampleData getSampleData = go1.AddComponent<GetSampleData>();
        yield return null;
        SaveData.Instance.AddToSubmittedSamples(new Sample());
        SaveData.Instance.SaveSubmittedSamples();
        getSampleData.SetUpTestVariables();
        getSampleData.ShowAllDeviceSubmittedSamples();
        yield return null;
        int childPrefabCount = getSampleData.GetContentParent().transform.childCount;
        Debug.Log(childPrefabCount + "----" + SaveData.Instance.GetUserSubmittedSamples().Count);
        Assert.AreEqual(childPrefabCount, SaveData.Instance.GetUserSubmittedSamples().Count);
        yield return null;
    }*/
/*    [UnityTest]
    public IEnumerator RetrieveCollectionTest()
    {
        GameObject go1 = new GameObject();
        go1.AddComponent<SaveData>();
        GetSampleData getSampleData = go1.AddComponent<GetSampleData>();
        getSampleData.SetUpTestVariables();
        yield return null;
        getSampleData.SetSearchFieldSelection("Name");
        getSampleData.SetSearchNameSelection("Bronagh");
        getSampleData.SetSearchLimitSelection(3);
        yield return null;
        getSampleData.ShowSearchSamples();
        yield return null;
        int childPrefabCount = getSampleData.GetContentParent().transform.childCount;
        Debug.Log(childPrefabCount + "----" );
        Assert.AreEqual(childPrefabCount, 3);
        yield return null;
    }*/
}
