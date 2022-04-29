using App.Samples.UI;
using NUnit.Framework;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
/// <summary>
/// This test script test the SearchSampleUI monobehaviour
/// script is performing as intended
/// </summary>
public class SearchSampleTests
{
    private GameObject _manager;
    private SearchSampleUI _searchSampleUI;
    private GameObject _searchInputGO;
    private GameObject _searchLimitGO;
    private GameObject _searchFieldGO;
    private TMP_InputField _searchLimit;
    private TMP_InputField _searchInput;
    private TMP_Dropdown _searchFieldDropDown;
    /// <summary>
    /// Setting the scene and gameobjects
    /// </summary>
    /// <returns></returns>
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(2);
        yield return null;
        _manager = GameObject.Find("Core/RetrieveManager");

        yield return null;
        _searchSampleUI = _manager.GetComponent<SearchSampleUI>();
        yield return null;
        _searchInputGO = GameObject.Find("Retrieval_Canvas/Panel/Container/User_Inputs/Name");
        _searchInput = _searchInputGO.GetComponent<TMP_InputField>();
        _searchLimitGO = GameObject.Find("Retrieval_Canvas/Panel/Container/User_Inputs/Limit");
        _searchLimit = _searchLimitGO.GetComponent<TMP_InputField>();
        _searchFieldGO = GameObject.Find("Retrieval_Canvas/Panel/Container/User_Inputs/FieldSelection");
        _searchFieldDropDown = _searchFieldGO.GetComponent<TMP_Dropdown>();
    }
    /// <summary>
    /// Testing SetSearchValues sets the correct default values
    /// when no inputs are provided
    /// </summary>
    [Test]
    public void SetSearchValues_Default_Test()
    {
        _searchSampleUI.SetSearchValues();
        Assert.AreEqual("", _searchSampleUI.SearchNameSelection);
        Assert.AreEqual(100, _searchSampleUI.SearchLimitSelection);
        Assert.AreEqual("", _searchSampleUI.SearchFieldSelection);
    }
    /// <summary>
    /// Testing SetSearchValues sets the correct name value
    /// when name inputs is provided
    /// </summary>
    [Test]
    public void SetNameValue_Test()
    {
        _searchInput.text = "Name Text";
        _searchSampleUI.SetSearchValues();
        Assert.AreEqual("Name Text", _searchSampleUI.SearchNameSelection);

    }
    /// <summary>
    /// Testing SetSearchValues sets the correct limit 
    /// when limit input string is provided
    /// </summary>
    [Test]
    public void SetLimitValue_Test()
    {

        _searchLimit.text = "1";
        _searchSampleUI.SetSearchValues();
        Assert.AreEqual(1, _searchSampleUI.SearchLimitSelection);

    }
    /// <summary>
    /// Testing SetSearchValues sets the correct field selection value
    /// when dropdown input is 0
    /// </summary>
    [Test]
    public void SetSearchField_Test_0()
    {

        _searchFieldDropDown.value = 0;
        _searchSampleUI.SetSearchValues();
        Assert.AreEqual("", _searchSampleUI.SearchFieldSelection);

    }
    /// <summary>
    /// Testing SetSearchValues sets the correct field selection value
    /// when dropdown input is 1
    /// </summary>
    [Test]
    public void SetSearchField_Test_1()
    {

        _searchFieldDropDown.value = 1;
        _searchSampleUI.SetSearchValues();
        Assert.AreEqual("Name", _searchSampleUI.SearchFieldSelection);

    }
    /// <summary>
    /// Testing SetSearchValues sets the correct field selection value
    /// when dropdown input is 2
    /// </summary>
    [Test]
    public void SetSearchField_Test_2()
    {
        _searchFieldDropDown.value = 2;
        _searchSampleUI.SetSearchValues();
        Assert.AreEqual("Company", _searchSampleUI.SearchFieldSelection);

    }
    /// <summary>
    /// Testing SetSearchValues sets the correct field selection value
    /// when dropdown input is 3
    /// </summary>
    [Test]
    public void SetSearchField_Test_3()
    {
        _searchFieldDropDown.value = 3;
        _searchSampleUI.SetSearchValues();
        Assert.AreEqual("Species", _searchSampleUI.SearchFieldSelection);

    }
    /// <summary>
    /// Testing SetSearchValues sets the correct field selection value
    /// when dropdown input is 4
    /// </summary>
    [Test]
    public void SetSearchField_Test_4()
    {

        _searchFieldDropDown.value = 4;
        _searchSampleUI.SetSearchValues();
        Assert.AreEqual("ProductionWeekNo", _searchSampleUI.SearchFieldSelection);

    }
    /// <summary>
    /// Testing SetSearchValues sets the correct field selection value
    /// when dropdown input is 5
    /// </summary>
    [Test]
    public void SetSearchField_Test_5()
    {

        _searchFieldDropDown.value = 5;
        _searchSampleUI.SetSearchValues();
        Assert.AreEqual("Date", _searchSampleUI.SearchFieldSelection);

    }
  
}
