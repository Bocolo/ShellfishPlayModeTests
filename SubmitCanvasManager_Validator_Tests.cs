using App.Navigation;
using App.Samples.UI;
using App.Samples.Validation;
using App.SaveSystem.Manager;
using NUnit.Framework;
using Samples.Data;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Users.Data;
/// <summary>
/// this script test the Submit Canvas Manager and 
/// SAmple Validator sctips in Play Mode
/// </summary>
public class SubmitCanvasManager_Validator_Tests
{
    private Menu _menu;
    private GameObject _manager;
    private GameObject _submitManager;
    private GameObject _smallCanvas;
    private GameObject _largeCanvas;
    private SubmitCanvasManager _submitCanvasManager;
    private SampleValidator _sampleValidator;
    /// <summary>
    /// Setting up the scene and the Game Object references
    /// </summary>
    /// <returns></returns>
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null;

        _manager = GameObject.Find("Managers/MenuManager");

        yield return null;
        _menu = _manager.GetComponent<Menu>();
        yield return null;

        _menu.SubmitPage();
        yield return null;
        _submitManager = GameObject.Find("Core/SubmitManager");
        yield return null;

        _submitCanvasManager = _submitManager.GetComponent<SubmitCanvasManager>();
        _sampleValidator = _submitManager.GetComponent<SampleValidator>();

        yield return null;
        _smallCanvas = _submitCanvasManager.GetSmallCanvas();
        _largeCanvas = _submitCanvasManager.GetLargeCanvas();
    }
   
/// <summary>
/// testing the NewSample method form the Sample validator scripts
/// new sample should always return a sample from the inputs
/// regardless of whethere the sample inputs are validated
/// </summary>
    [Test]
    public void SampleValidator_New_Sample()
    {
 
        _submitCanvasManager.Name.text = "Test Small Name";
        _submitCanvasManager.Company.text = "Test Small Company";
        _submitCanvasManager.Comments.text = "Test A Small Comment";
        _submitCanvasManager.ProductionWk.value = 1;
        _submitCanvasManager.Species.value = 2;
        _submitCanvasManager.DayDrop.value = 1;
        _submitCanvasManager.MonthDrop.value = 1;
        _submitCanvasManager.YearDrop.value = 1;
        _submitCanvasManager.IceRectangle.value = 6;
        _submitCanvasManager.SampleLocationName.value = 7;
   
        Assert.IsFalse(_sampleValidator.ValidateValues());
        Sample sample = _sampleValidator.NewSample();
        Assert.AreEqual("Test Small Name", sample.Name);
        Assert.AreEqual("Test Small Company", sample.Company);
        Assert.AreEqual("Test A Small Comment", sample.Comment);
        Assert.AreEqual("2022-1-1", sample.Date);
        Assert.AreEqual(1, sample.ProductionWeekNo);
        Assert.AreEqual("Mermaid Shoal Ground (39-E4)",sample.IcesRectangleNo);
        Assert.AreEqual("Carpet Shell",sample.Species);
    }
    [Test]
    public void SampleValidator_Value_Validator_True()
    {
        _submitCanvasManager.Name.text = "Test Small Name";
        _submitCanvasManager.Company.text = "Test Small Company";
        _submitCanvasManager.Comments.text = "Test A Small Comment";
        _submitCanvasManager.ProductionWk.value = 1;
        _submitCanvasManager.Species.value = 2;
        _submitCanvasManager.DayDrop.value = 1;
        _submitCanvasManager.MonthDrop.value = 1;
        _submitCanvasManager.YearDrop.value = 1;
        _submitCanvasManager.IceRectangle.value = 6;
        _submitCanvasManager.SampleLocationName.value = 0;
        Assert.IsTrue(_sampleValidator.ValidateValues());
    }
    [Test]
    public void SampleValidator_Value_Validator_Incorrect_Location_False()
    {
   
        _submitCanvasManager.Name.text = "Test Small Name";
        _submitCanvasManager.Company.text = "Test Small Company";
        _submitCanvasManager.Comments.text = "Test A Small Comment";
        _submitCanvasManager.ProductionWk.value = 1;
        _submitCanvasManager.Species.value = 2;
        _submitCanvasManager.DayDrop.value = 1;
        _submitCanvasManager.MonthDrop.value = 1;
        _submitCanvasManager.YearDrop.value = 1;
        //Validation will fail if one of the below values is not set to zero
        //Both the ices rectangle and sample location can not be set simultaneously
        _submitCanvasManager.IceRectangle.value = 6;
        _submitCanvasManager.SampleLocationName.value = 7;
        Assert.IsFalse(_sampleValidator.ValidateValues());

    }
    [Test]
    public void SampleValidator_Value_Validator_Invalid_Date_False()
    {

        _submitCanvasManager.Name.text = "Test Small Name";
        _submitCanvasManager.Company.text = "Test Small Company";
        _submitCanvasManager.Comments.text = "Test A Small Comment";
        _submitCanvasManager.ProductionWk.value = 1;
        _submitCanvasManager.Species.value = 2;
        //Validation will fail if the date is not set correctly
        //This includes the day,month and year drops
        _submitCanvasManager.DayDrop.value = 0;
        _submitCanvasManager.MonthDrop.value = 0;
        _submitCanvasManager.YearDrop.value = 0;
 
        _submitCanvasManager.IceRectangle.value = 6;
        _submitCanvasManager.SampleLocationName.value = 0;
        Assert.IsFalse(_sampleValidator.ValidateValues());

    }
    [Test]
    public void SubmitCanvasManager_SwitchCanvas()
    {
        if (_smallCanvas.activeInHierarchy)
        {
            Assert.IsTrue(_smallCanvas.activeInHierarchy);
            Assert.IsFalse(_largeCanvas.activeInHierarchy);
            _submitCanvasManager.SwitchCanvas();
            Assert.IsFalse(_smallCanvas.activeInHierarchy);
            Assert.IsTrue(_largeCanvas.activeInHierarchy);
        }
        else
        {
            Assert.IsTrue(_largeCanvas.activeInHierarchy);
            Assert.IsFalse(_smallCanvas.activeInHierarchy);
            _submitCanvasManager.SwitchCanvas();
            Assert.IsFalse(_largeCanvas.activeInHierarchy);
            Assert.IsTrue(_smallCanvas.activeInHierarchy);
        }
    }
  
    [Test]
    public void SubmitCanvasManager_TestInput_Generic()
    {
        _submitCanvasManager.Name.text = "Generic Name";
        _submitCanvasManager.Company.text = "Generic Company";
        _submitCanvasManager.Comments.text = "Generic Comments";
        _submitCanvasManager.Species.value = 2;
        _submitCanvasManager.IceRectangle.value = 3;
        _submitCanvasManager.ProductionWk.value = 4;
        _submitCanvasManager.DayDrop.value = 5;
        _submitCanvasManager.MonthDrop.value = 6;
        _submitCanvasManager.YearDrop.value = 7;
        _submitCanvasManager.SampleLocationName.value = 1;
        Assert.AreEqual("Generic Name", _submitCanvasManager.Name.text);
        Assert.AreEqual("Generic Company", _submitCanvasManager.Company.text);
        Assert.AreEqual("Generic Comments", _submitCanvasManager.Comments.text);
        Assert.AreEqual(2, _submitCanvasManager.Species.value);
        Assert.AreEqual(3, _submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(1, _submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(4, _submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(5, _submitCanvasManager.DayDrop.value);
        Assert.AreEqual(6, _submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(7, _submitCanvasManager.YearDrop.value);

    }
    [Test]
    public void SubmitCanvasManager_TestInput_Generic_Clear_Submission()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name1",
            Company = "Test Company1"
        });
        _submitCanvasManager.Name.text = "Generic Name";
        _submitCanvasManager.Company.text = "Generic Company";
        _submitCanvasManager.Comments.text = "Generic Comments";
        _submitCanvasManager.Species.value = 2;
        _submitCanvasManager.IceRectangle.value = 3;
        _submitCanvasManager.ProductionWk.value = 4;
        _submitCanvasManager.DayDrop.value = 5;
        _submitCanvasManager.MonthDrop.value = 6;
        _submitCanvasManager.YearDrop.value = 7;
        _submitCanvasManager.SampleLocationName.value = 1;
        _submitCanvasManager.CompleteSubmission();

        Assert.AreEqual("Test Name1", _submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company1", _submitCanvasManager.Company.text);
        Assert.AreEqual("", _submitCanvasManager.Comments.text);
        Assert.AreEqual(0, _submitCanvasManager.Species.value);
        Assert.AreEqual(0, _submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, _submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, _submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, _submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, _submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, _submitCanvasManager.YearDrop.value);
        Assert.IsTrue(_submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);

    }
    [Test]
    public void SubmitCanvasManager_TestInput_Generic_Clear_Store()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name2",
            Company = "Test Company2"
        });
        _submitCanvasManager.Name.text = "Generic Name";
        _submitCanvasManager.Company.text = "Generic Company";
        _submitCanvasManager.Comments.text = "Generic Comments";
        _submitCanvasManager.Species.value = 2;
        _submitCanvasManager.IceRectangle.value = 3;
        _submitCanvasManager.ProductionWk.value = 4;
        _submitCanvasManager.DayDrop.value = 5;
        _submitCanvasManager.MonthDrop.value = 6;
        _submitCanvasManager.YearDrop.value = 7;
        _submitCanvasManager.SampleLocationName.value = 1;
        _submitCanvasManager.CompleteStore();

        Assert.AreEqual("Test Name2", _submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company2", _submitCanvasManager.Company.text);
        Assert.AreEqual("", _submitCanvasManager.Comments.text);
        Assert.AreEqual(0, _submitCanvasManager.Species.value);
        Assert.AreEqual(0, _submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, _submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, _submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, _submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, _submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, _submitCanvasManager.YearDrop.value);
        Assert.IsTrue(_submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);
    }
    [Test]
    public void SubmitCanvasManager_CompleteSubmission()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name",
            Company = "Test Company"
        });
        _submitCanvasManager.CompleteSubmission();

        Assert.AreEqual("Test Name", _submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company", _submitCanvasManager.Company.text);
        Assert.AreEqual("", _submitCanvasManager.Comments.text);
        Assert.AreEqual(0, _submitCanvasManager.Species.value);
        Assert.AreEqual(0, _submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, _submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, _submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, _submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, _submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, _submitCanvasManager.YearDrop.value);
        Assert.IsTrue(_submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);
    }
    [Test]
    public void SubmitCanvasManager_CompleteStore()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name",
            Company = "Test Company"
        });
        _submitCanvasManager.CompleteStore();
        Assert.AreEqual("Test Name", _submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company", _submitCanvasManager.Company.text);
        Assert.AreEqual("", _submitCanvasManager.Comments.text);
        Assert.AreEqual(0, _submitCanvasManager.Species.value);
        Assert.AreEqual(0, _submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, _submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, _submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, _submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, _submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, _submitCanvasManager.YearDrop.value);
        Assert.IsTrue(_submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);
    }
   
}
/*     if (!smallCanvas.activeInHierarchy)
      {
          *//*  smallCanvas.SetActive(true);*//*
          submitCanvasManager.SwitchCanvas();
      }*/
/*
    private TMP_InputField _name_sml;
    private TMP_InputField _company_sml;
    private TMP_Dropdown _productionWk_sml;
    private TMP_Dropdown _species_sml;
    private TMP_Dropdown DayDrop_sml;
    private TMP_Dropdown MonthDrop_sml;
    private TMP_Dropdown YearDrop_sml;
    private TMP_Dropdown _iceRectangle_sml;
    private TMP_Dropdown _sampleLocationName_sml;
    private TMP_InputField _comments_sml;
    //LARGE CANVAS
    private TMP_InputField _name_lrg;
    private TMP_InputField _company_lrg;
    private TMP_Dropdown _productionWk_lrg;
    private TMP_Dropdown _species_lrg;
    private TMP_Dropdown DayDrop_lrg;
    private TMP_Dropdown MonthDrop_lrg;
    private TMP_Dropdown YearDrop_lrg;
    private TMP_Dropdown _iceRectangle_lrg;
    private TMP_Dropdown _sampleLocationName_lrg;
    private TMP_InputField _comments_lrg;
*/
/*  [Test]
    public void SubmitCanvasManager_TestInput_Large()
    {
        if (!smallCanvas.activeInHierarchy)
        {
            *//*  smallCanvas.SetActive(true);*//*
            submitCanvasManager.SwitchCanvas();
        }
        _name_sml.text = "Test Small Name";
        _company_sml.text = "Test Small Company";
        _comments_sml.text = "Test A Small Comment";
        _productionWk_sml.value = 1;
        _species_sml.value = 2;
        DayDrop_sml.value = 3;
        MonthDrop_sml.value = 4;
        YearDrop_sml.value = 5;
        _iceRectangle_sml.value = 6;
        _sampleLocationName_sml.value = 7;



        Assert.AreEqual("Test Small Name", submitCanvasManager.Name.text);
        Assert.AreEqual("Test Small Company", submitCanvasManager.Company.text);
        Assert.AreEqual("Test A Small Comment", submitCanvasManager.Comments.text);
        Assert.AreEqual(2, submitCanvasManager.Species.value);
        Assert.AreEqual(6, submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(7, submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(1, submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(3, submitCanvasManager.DayDrop.value);
        Assert.AreEqual(4, submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(5, submitCanvasManager.YearDrop.value);
        //    yield return null;

        //  Assert.IsTrue(submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);
    }
    [Test]
    public void SubmitCanvasManager_TestInput_Small()
    {
        if (!largeCanvas.activeInHierarchy)
        {
            *//*  smallCanvas.SetActive(true);*//*
            submitCanvasManager.SwitchCanvas();
        }
        _name_lrg.text = "Test Name";
        _company_lrg.text = "Test Company";
        _comments_lrg.text = "Test A Comment";
        _productionWk_lrg.value = 1;
        _species_lrg.value = 2;
        DayDrop_lrg.value = 3;
        MonthDrop_lrg.value = 4;
        YearDrop_lrg.value = 5;
        _iceRectangle_lrg.value = 6;
        _sampleLocationName_lrg.value = 7;
        Assert.AreEqual("Test Name", submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company", submitCanvasManager.Company.text);
        Assert.AreEqual("Test A Comment", submitCanvasManager.Comments.text);
        Assert.AreEqual(2, submitCanvasManager.Species.value);
        Assert.AreEqual(6, submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(7, submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(1, submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(3, submitCanvasManager.DayDrop.value);
        Assert.AreEqual(4, submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(5, submitCanvasManager.YearDrop.value);
    }*/
/*
[UnitySetUp]
public IEnumerator SetUp_FindGOs()
{
    yield return null;
    try
    {
        Debug.Log("In the try");
        largeCanvas = GameObject.FindWithTag("LargeCanvas"); //will throw Unityexception if inactive
        *//*   _name_lrg = GameObject.FindWithTag("NameLarge").GetComponent<TMP_InputField>();
           _company_lrg = GameObject.FindWithTag("Company:Large").GetComponent<TMP_InputField>();
           _productionWk_lrg = GameObject.FindWithTag("ProWeekLarge").GetComponent<TMP_Dropdown>();
           _species_lrg = GameObject.FindWithTag("SpeciesLarge").GetComponent<TMP_Dropdown>();
           DayDrop_lrg = GameObject.FindWithTag("DayLarge").GetComponent<TMP_Dropdown>();
           MonthDrop_lrg = GameObject.FindWithTag("MonthLarge").GetComponent<TMP_Dropdown>();
           YearDrop_lrg = GameObject.FindWithTag("YearLarge").GetComponent<TMP_Dropdown>();
           _iceRectangle_lrg = GameObject.FindWithTag("IcesLarge").GetComponent<TMP_Dropdown>();
           _sampleLocationName_lrg = GameObject.FindWithTag("SampleLarge").GetComponent<TMP_Dropdown>();
           _comments_lrg = GameObject.FindWithTag("CommentLarge").GetComponent<TMP_InputField>();*//*
        //largeCanvas = GameObject.FindWithTag("LargeCanvas");
        submitCanvasManager.SwitchCanvas();
        smallCanvas = GameObject.FindWithTag("SmallCanvas");
        *//*   _name_sml = GameObject.FindWithTag("NameSmall").GetComponent<TMP_InputField>();
           _company_sml = GameObject.FindWithTag("CompanySmall").GetComponent<TMP_InputField>();
           _productionWk_sml = GameObject.FindWithTag("ProWeekSmall").GetComponent<TMP_Dropdown>();
           _species_sml = GameObject.FindWithTag("SpeciesSmall").GetComponent<TMP_Dropdown>();
           DayDrop_sml = GameObject.FindWithTag("DaySmall").GetComponent<TMP_Dropdown>();
           MonthDrop_sml = GameObject.FindWithTag("MonthSmall").GetComponent<TMP_Dropdown>();
           YearDrop_sml = GameObject.FindWithTag("YearSmall").GetComponent<TMP_Dropdown>();
           _iceRectangle_sml = GameObject.FindWithTag("IcesSmall").GetComponent<TMP_Dropdown>();
           _sampleLocationName_sml = GameObject.FindWithTag("SampleSmall").GetComponent<TMP_Dropdown>();
           _comments_sml = GameObject.FindWithTag("CommentSmall").GetComponent<TMP_InputField>();*//*
    }
    catch (Exception exception)
    {
        Debug.Log("Unity exception thrown, large canvas is deactivated: " + exception.Message);
        //large canvas not found -disabled
        smallCanvas = GameObject.FindWithTag("SmallCanvas");
        *//*  _name_sml = GameObject.FindWithTag("NameSmall").GetComponent<TMP_InputField>();
          _company_sml = GameObject.FindWithTag("CompanySmall").GetComponent<TMP_InputField>();
          _productionWk_sml = GameObject.FindWithTag("ProWeekSmall").GetComponent<TMP_Dropdown>();
          _species_sml = GameObject.FindWithTag("SpeciesSmall").GetComponent<TMP_Dropdown>();
          DayDrop_sml = GameObject.FindWithTag("DaySmall").GetComponent<TMP_Dropdown>();
          MonthDrop_sml = GameObject.FindWithTag("MonthSmall").GetComponent<TMP_Dropdown>();
          YearDrop_sml = GameObject.FindWithTag("YearSmall").GetComponent<TMP_Dropdown>();
          _iceRectangle_sml = GameObject.FindWithTag("IcesSmall").GetComponent<TMP_Dropdown>();
          _sampleLocationName_sml = GameObject.FindWithTag("SampleSmall").GetComponent<TMP_Dropdown>();
          _comments_sml = GameObject.FindWithTag("CommentSmall").GetComponent<TMP_InputField>();*//*
        submitCanvasManager.SwitchCanvas();
        *//*
                    _name_lrg = GameObject.FindWithTag("NameLarge").GetComponent<TMP_InputField>();
                    _company_lrg = GameObject.FindWithTag("Company:Large").GetComponent<TMP_InputField>();
                    _productionWk_lrg = GameObject.FindWithTag("ProWeekLarge").GetComponent<TMP_Dropdown>();
                    _species_lrg = GameObject.FindWithTag("SpeciesLarge").GetComponent<TMP_Dropdown>();
                    DayDrop_lrg = GameObject.FindWithTag("DayLarge").GetComponent<TMP_Dropdown>();
                    MonthDrop_lrg = GameObject.FindWithTag("MonthLarge").GetComponent<TMP_Dropdown>();
                    YearDrop_lrg = GameObject.FindWithTag("YearLarge").GetComponent<TMP_Dropdown>();
                    _iceRectangle_lrg = GameObject.FindWithTag("IcesLarge").GetComponent<TMP_Dropdown>();
                    _sampleLocationName_lrg = GameObject.FindWithTag("SampleLarge").GetComponent<TMP_Dropdown>();
                    _comments_lrg = GameObject.FindWithTag("CommentLarge").GetComponent<TMP_InputField>();*//*
        largeCanvas = GameObject.FindWithTag("LargeCanvas");
    }

}*/