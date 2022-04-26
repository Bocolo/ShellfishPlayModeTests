using NUnit.Framework;
using System.Collections;
using TMPro;
using UI.Navigation;
using UI.Retrieve;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SearchSampleTests
{
    private GameObject manager;
    private SearchSampleUI searchSampleUI;
    private GameObject searchInputGO;
    private GameObject searchLimitGO;
    private GameObject searchFieldGO;
    private TMP_InputField searchLimit;
    private TMP_InputField searchInput;
    private TMP_Dropdown searchFieldDropDown;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(2);
        yield return null;
        manager = GameObject.Find("Core/RetrieveManager");

        yield return null;
        searchSampleUI = manager.GetComponent<SearchSampleUI>();
        yield return null;
        searchInputGO = GameObject.Find("Retrieval_Canvas/Panel/Container/User_Inputs/Name");
        searchInput = searchInputGO.GetComponent<TMP_InputField>();
        searchLimitGO = GameObject.Find("Retrieval_Canvas/Panel/Container/User_Inputs/Limit");
        searchLimit = searchLimitGO.GetComponent<TMP_InputField>();
        searchFieldGO = GameObject.Find("Retrieval_Canvas/Panel/Container/User_Inputs/FieldSelection");
        searchFieldDropDown = searchFieldGO.GetComponent<TMP_Dropdown>();
    }
    [Test]
    public void SetSearchValues_Default_Test()
    {
        searchSampleUI.SetSearchValues();
        Assert.AreEqual("", searchSampleUI.SearchNameSelection);
        Assert.AreEqual(100, searchSampleUI.SearchLimitSelection);
        Assert.AreEqual("", searchSampleUI.SearchFieldSelection);
    }
 
    [Test]
    public void SetNameValue_Test()
    {
        searchInput.text = "Name Text";
        searchSampleUI.SetSearchValues();
        Assert.AreEqual("Name Text", searchSampleUI.SearchNameSelection);

    }
    [Test]
    public void SetLimitValue_Test()
    {

        searchLimit.text = "1";
        searchSampleUI.SetSearchValues();
        Assert.AreEqual(1, searchSampleUI.SearchLimitSelection);

    }
    [Test]
    public void SetSearchField_Test_0()
    {

        searchFieldDropDown.value = 0;
        searchSampleUI.SetSearchValues();
        Assert.AreEqual("", searchSampleUI.SearchFieldSelection);

    }
    [Test]
    public void SetSearchField_Test_1()
    {

        searchFieldDropDown.value = 1;
        searchSampleUI.SetSearchValues();
        Assert.AreEqual("Name", searchSampleUI.SearchFieldSelection);

    }
    [Test]
    public void SetSearchField_Test_2()
    {
        searchFieldDropDown.value = 2;
        searchSampleUI.SetSearchValues();
        Assert.AreEqual("Company", searchSampleUI.SearchFieldSelection);

    }
    [Test]
    public void SetSearchField_Test_3()
    {
        searchFieldDropDown.value = 3;
        searchSampleUI.SetSearchValues();
        Assert.AreEqual("Species", searchSampleUI.SearchFieldSelection);

    }
    [Test]
    public void SetSearchField_Test_4()
    {

        searchFieldDropDown.value = 4;
        searchSampleUI.SetSearchValues();
        Assert.AreEqual("ProductionWeekNo", searchSampleUI.SearchFieldSelection);

    }
    [Test]
    public void SetSearchField_Test_5()
    {

        searchFieldDropDown.value = 5;
        searchSampleUI.SetSearchValues();
        Assert.AreEqual("Date", searchSampleUI.SearchFieldSelection);

    }
}
