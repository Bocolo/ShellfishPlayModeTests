using App.Samples.UI;
using NUnit.Framework;
using Samples.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
/// <summary>
/// Tests te sample UI script
/// </summary>
public class SamplePanelGeneratorTests
{
    private SamplePanelGenerator _samplePanelGenerator;
    private GameObject _manager;
    private GameObject _contentParent;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(3);
        yield return null;
        yield return null;
        _manager = GameObject.Find("Core/RetrieveManager");

        yield return null;
        _samplePanelGenerator = _manager.GetComponent<SamplePanelGenerator>();
        yield return null;
      _contentParent=  GameObject.Find("Canvas_UserSamples/Panel_Scroll/Scroll_View/Viewport/Content");
    }
    /// <summary>
    /// tests that AddTextAndPrefab adds a child to the content parent
    /// when passed a single sample
    /// </summary>
    [Test]
    public void SingleSample_TextAndPrefab_PrefabTest()
    {
        Assert.AreEqual(0,_contentParent.transform.childCount);
        _samplePanelGenerator.AddTextAndPrefab(new Sample());
        Assert.AreEqual(1, _contentParent.transform.childCount);
    }
    /// <summary>
    /// tests that AddTextAndPrefab adds the correct number of children to the content parent
    /// when passed a sample list
    /// </summary>
    [Test]
    public void ListSamples_TextAndPrefab_PrefabTest()
    {
        List<Sample> samples = new List<Sample>();
        samples.Add(new Sample());
        samples.Add(new Sample());
        samples.Add(new Sample());
        Assert.AreEqual(0, _contentParent.transform.childCount);
        _samplePanelGenerator.AddTextAndPrefab(samples);
        Assert.AreEqual(3, _contentParent.transform.childCount);
    }
    /// <summary>
    /// tests that AddTextAndPrefab destroys previously loaded children attached
    /// to the content parent
    /// </summary>
    /// <returns></returns>
    [UnityTest]
    public IEnumerator ListSamples_TextAndPrefab_DestroyChildrenTest()
    {
        List<Sample> samples = new List<Sample>();
        samples.Add(new Sample());
        samples.Add(new Sample());
        samples.Add(new Sample());
        Assert.AreEqual(0, _contentParent.transform.childCount);

        //Adding the 3 above Samples / Children to the "contentParent"
        _samplePanelGenerator.AddTextAndPrefab(samples);
        Assert.AreEqual(3, _contentParent.transform.childCount);

        List<Sample> samples2 = new List<Sample>();
        samples2.Add(new Sample());
        samples2.Add(new Sample());
        //adding the 2 samples from samples2 to the "contentParent"
        //AddTextAndPrefab should destroy the previous 3 children
        _samplePanelGenerator.AddTextAndPrefab(samples2);
        yield return null;//wait for next frame

        Assert.AreEqual(2, _contentParent.transform.childCount);
    }
  
}
