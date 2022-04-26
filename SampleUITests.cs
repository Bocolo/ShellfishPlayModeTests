using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UI.SampleDisplay;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class SampleUITests
{
    private SampleUI sampleUI;
    private GameObject manager;
    private GameObject contentParent;
    private Transform contentParentTransform;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(3);
        yield return null;
        yield return null;
        manager = GameObject.Find("Core/RetrieveManager");

        yield return null;
        sampleUI = manager.GetComponent<SampleUI>();
        yield return null;
      contentParent=  GameObject.Find("Canvas_UserSamples/Panel_Scroll/Scroll_View/Viewport/Content");
    }
    [Test]
    public void SingleSample_TextAndPrefab_PrefabTest()
    {
        Assert.AreEqual(0,contentParent.transform.childCount);
        sampleUI.AddTextAndPrefab(new Sample());
        Assert.AreEqual(1, contentParent.transform.childCount);
    }
    [Test]
    public void ListSamples_TextAndPrefab_PrefabTest()
    {
        List<Sample> samples = new List<Sample>();
        samples.Add(new Sample());
        samples.Add(new Sample());
        samples.Add(new Sample());
        Assert.AreEqual(0, contentParent.transform.childCount);
        sampleUI.AddTextAndPrefab(samples);
        Assert.AreEqual(3, contentParent.transform.childCount);
    }
    [UnityTest]
    public IEnumerator ListSamples_TextAndPrefab_DestroyChildrenTest()
    {
        List<Sample> samples = new List<Sample>();
        samples.Add(new Sample());
        samples.Add(new Sample());
        samples.Add(new Sample());
        Assert.AreEqual(0, contentParent.transform.childCount);

        //Adding the 3 above Samples / Children to the "contentParent"
        sampleUI.AddTextAndPrefab(samples);
        Assert.AreEqual(3, contentParent.transform.childCount);

        List<Sample> samples2 = new List<Sample>();
        samples2.Add(new Sample());
        samples2.Add(new Sample());
        //adding the 2 samples from samples2 to the "contentParent"
        //AddTextAndPrefab should destroy the previous 3 children
        sampleUI.AddTextAndPrefab(samples2);
        yield return null;//wait for next frame

        Assert.AreEqual(2, contentParent.transform.childCount);
    }
    [Test]
    public void ListSamples_TextAndPrefab_TextTest()
    {
        List<Sample> samples = new List<Sample>();
        Sample sampleA = new Sample
        {
            Name = "Test Sample",
            Company = "Test Company",
            Species = "Test Species",
            ProductionWeekNo = 99,
            IcesRectangleNo = "Test Rectangle",
            Date = "Test Date",
            Comment = "Test Comment"

        };
        Sample sampleB = new Sample
        {
            Name = "Test Sample",
            Company = "Test Company",
            Species = "Test Species",
            ProductionWeekNo = 99,
            SampleLocationName = "Test Location",
            Date = "Test Date",
            Comment = "Test Comment"

        };
        samples.Add(sampleA);
        samples.Add(sampleB);
     
        sampleUI.AddTextAndPrefab(samples);


        Text childA = sampleUI.GetContentParent().GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        string expectedStringA = "Name: " + sampleA.Name + "\nCompany: " + sampleA.Company + "\nSpecies: " + sampleA.Species
               + $"\nICEs Rectangle: {sampleA.IcesRectangleNo}"
               + "\nWeek: " + sampleA.ProductionWeekNo + "\nDate: " + sampleA.Date + "\nComment: " + sampleA.Comment;

        Assert.AreEqual(expectedStringA, childA.text);


        Text childB = sampleUI.GetContentParent().GetChild(1).GetChild(0).gameObject.GetComponent<Text>();
        string expectedStringB = ("Name: " + sampleB.Name + "\nCompany: " + sampleB.Company + "\nSpecies: " + sampleB.Species
                + "\nLocation: " + sampleB.SampleLocationName + "\nWeek: " + sampleB.ProductionWeekNo + "\nDate: " + sampleB.Date
                + "\nComment: " + sampleB.Comment);

        Assert.AreEqual(expectedStringB, childB.text);
    }
    [Test]
    public void SingleSample_PrefabTest_Ices()
    {
        Sample sample = new Sample
        {
            Name = "Test Sample",
            Company = "Test Company",
            Species = "Test Species",
            ProductionWeekNo = 99,
            IcesRectangleNo = "Test Rectangle",
            Date = "Test Date",
            Comment = "Test Comment"

        };
        sampleUI.AddTextAndPrefab(sample);
        int childPrefabCount = sampleUI.GetContentParent().transform.childCount;
        Assert.AreEqual(1, childPrefabCount);
        Text child = sampleUI.GetContentParent().GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        string expectedString = "Name: " + sample.Name + "\nCompany: " + sample.Company + "\nSpecies: " + sample.Species
               + $"\nICEs Rectangle: {sample.IcesRectangleNo}"
               + "\nWeek: " + sample.ProductionWeekNo + "\nDate: " + sample.Date + "\nComment: " + sample.Comment;
        Assert.AreEqual(expectedString, child.text);
    }
    [Test]
    public void SingleSample_PrefabTest_Location()
    {
        Sample sample = new Sample
        {
            Name = "Test Sample",
            Company = "Test Company",
            Species = "Test Species",
            ProductionWeekNo = 99,
            SampleLocationName = "Test Location",
            Date = "Test Date",
            Comment = "Test Comment"

        };
        sampleUI.AddTextAndPrefab(sample);
        int childPrefabCount = sampleUI.GetContentParent().transform.childCount;

        Assert.AreEqual(1, childPrefabCount);

        Text child = sampleUI.GetContentParent().GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
        string expectedString = ("Name: " + sample.Name + "\nCompany: " + sample.Company + "\nSpecies: " + sample.Species
                + "\nLocation: " + sample.SampleLocationName + "\nWeek: " + sample.ProductionWeekNo + "\nDate: " + sample.Date
                + "\nComment: " + sample.Comment);
        Assert.AreEqual(expectedString, child.text);
    }
}
