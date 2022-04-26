using System;
using System.Collections;
using NUnit.Framework;
using Save.Manager;
using TMPro;
using UI.Navigation;
using UI.Submit;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class SubmitCanvasManager_Validator_Tests
{
    private Menu menu;
    private GameObject manager;
    private GameObject submitManager;
    private GameObject smallCanvas;
    private GameObject largeCanvas;
    private SubmitCanvasManager submitCanvasManager;

    private SampleValidator sampleValidator;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene(0);
        yield return null;

        manager = GameObject.Find("Managers/MenuManager");

        yield return null;
        menu = manager.GetComponent<Menu>();
        yield return null;

        menu.SubmitPage();
        yield return null;
        submitManager = GameObject.Find("Core/SubmitManager");
        yield return null;

        submitCanvasManager = submitManager.GetComponent<SubmitCanvasManager>();
        sampleValidator = submitManager.GetComponent<SampleValidator>();

        yield return null;
        smallCanvas = submitCanvasManager.GetSmallCanvas();
        largeCanvas = submitCanvasManager.GetLargeCanvas();
    }
   

    /// <summary>
    /// could i just dow 
    /// </summary>
    [Test]
    public void SampleValidator_New_Sample()
    {
 
        submitCanvasManager.Name.text = "Test Small Name";
        submitCanvasManager.Company.text = "Test Small Company";
        submitCanvasManager.Comments.text = "Test A Small Comment";
        submitCanvasManager.ProductionWk.value = 1;
        submitCanvasManager.Species.value = 2;
        submitCanvasManager.DayDrop.value = 1;
        submitCanvasManager.MonthDrop.value = 1;
        submitCanvasManager.YearDrop.value = 1;
        submitCanvasManager.IceRectangle.value = 6;
        submitCanvasManager.SampleLocationName.value = 7;
   
        sampleValidator.ValidateValues();
        Sample sample = sampleValidator.NewSample();
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
        submitCanvasManager.Name.text = "Test Small Name";
        submitCanvasManager.Company.text = "Test Small Company";
        submitCanvasManager.Comments.text = "Test A Small Comment";
        submitCanvasManager.ProductionWk.value = 1;
        submitCanvasManager.Species.value = 2;
        submitCanvasManager.DayDrop.value = 1;
        submitCanvasManager.MonthDrop.value = 1;
        submitCanvasManager.YearDrop.value = 1;
        submitCanvasManager.IceRectangle.value = 6;
        submitCanvasManager.SampleLocationName.value = 0;
        Assert.IsTrue(sampleValidator.ValidateValues());
    }
    [Test]
    public void SampleValidator_Value_Validator_Incorrect_Location_False()
    {
   
        submitCanvasManager.Name.text = "Test Small Name";
        submitCanvasManager.Company.text = "Test Small Company";
        submitCanvasManager.Comments.text = "Test A Small Comment";
        submitCanvasManager.ProductionWk.value = 1;
        submitCanvasManager.Species.value = 2;
        submitCanvasManager.DayDrop.value = 1;
        submitCanvasManager.MonthDrop.value = 1;
        submitCanvasManager.YearDrop.value = 1;
        //Validation will fail if one of the below values is not set to zero
        //Both the ices rectangle and sample location can not be set simultaneously
        submitCanvasManager.IceRectangle.value = 6;
        submitCanvasManager.SampleLocationName.value = 7;
        Assert.IsFalse(sampleValidator.ValidateValues());

    }
    [Test]
    public void SampleValidator_Value_Validator_Invalid_Date_False()
    {

        submitCanvasManager.Name.text = "Test Small Name";
        submitCanvasManager.Company.text = "Test Small Company";
        submitCanvasManager.Comments.text = "Test A Small Comment";
        submitCanvasManager.ProductionWk.value = 1;
        submitCanvasManager.Species.value = 2;
        //Validation will fail if the date is not set correctly
        //This includes the day,month and year drops
        submitCanvasManager.DayDrop.value = 0;
        submitCanvasManager.MonthDrop.value = 0;
        submitCanvasManager.YearDrop.value = 0;
 
        submitCanvasManager.IceRectangle.value = 6;
        submitCanvasManager.SampleLocationName.value = 0;
        Assert.IsFalse(sampleValidator.ValidateValues());

    }
    [Test]
    public void SubmitCanvasManager_SwitchCanvas()
    {
        if (smallCanvas.activeInHierarchy)
        {
            Assert.IsTrue(smallCanvas.activeInHierarchy);
            Assert.IsFalse(largeCanvas.activeInHierarchy);
            submitCanvasManager.SwitchCanvas();
            Assert.IsFalse(smallCanvas.activeInHierarchy);
            Assert.IsTrue(largeCanvas.activeInHierarchy);
        }
        else
        {
            Assert.IsTrue(largeCanvas.activeInHierarchy);
            Assert.IsFalse(smallCanvas.activeInHierarchy);
            submitCanvasManager.SwitchCanvas();
            Assert.IsFalse(largeCanvas.activeInHierarchy);
            Assert.IsTrue(smallCanvas.activeInHierarchy);
        }
    }
  
    [Test]
    public void SubmitCanvasManager_TestInput_Generic()
    {
        submitCanvasManager.Name.text = "Generic Name";
        submitCanvasManager.Company.text = "Generic Company";
        submitCanvasManager.Comments.text = "Generic Comments";
        submitCanvasManager.Species.value = 2;
        submitCanvasManager.IceRectangle.value = 3;
        submitCanvasManager.ProductionWk.value = 4;
        submitCanvasManager.DayDrop.value = 5;
        submitCanvasManager.MonthDrop.value = 6;
        submitCanvasManager.YearDrop.value = 7;
        submitCanvasManager.SampleLocationName.value = 1;
        Assert.AreEqual("Generic Name", submitCanvasManager.Name.text);
        Assert.AreEqual("Generic Company", submitCanvasManager.Company.text);
        Assert.AreEqual("Generic Comments", submitCanvasManager.Comments.text);
        Assert.AreEqual(2, submitCanvasManager.Species.value);
        Assert.AreEqual(3, submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(1, submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(4, submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(5, submitCanvasManager.DayDrop.value);
        Assert.AreEqual(6, submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(7, submitCanvasManager.YearDrop.value);

    }
    [Test]
    public void SubmitCanvasManager_TestInput_Generic_Clear_Submission()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name1",
            Company = "Test Company1"
        });
        submitCanvasManager.Name.text = "Generic Name";
        submitCanvasManager.Company.text = "Generic Company";
        submitCanvasManager.Comments.text = "Generic Comments";
        submitCanvasManager.Species.value = 2;
        submitCanvasManager.IceRectangle.value = 3;
        submitCanvasManager.ProductionWk.value = 4;
        submitCanvasManager.DayDrop.value = 5;
        submitCanvasManager.MonthDrop.value = 6;
        submitCanvasManager.YearDrop.value = 7;
        submitCanvasManager.SampleLocationName.value = 1;
        submitCanvasManager.CompleteSubmission();

        Assert.AreEqual("Test Name1", submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company1", submitCanvasManager.Company.text);
        Assert.AreEqual("", submitCanvasManager.Comments.text);
        Assert.AreEqual(0, submitCanvasManager.Species.value);
        Assert.AreEqual(0, submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, submitCanvasManager.YearDrop.value);
        Assert.IsTrue(submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);

    }
    [Test]
    public void SubmitCanvasManager_TestInput_Generic_Clear_Store()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name2",
            Company = "Test Company2"
        });
        submitCanvasManager.Name.text = "Generic Name";
        submitCanvasManager.Company.text = "Generic Company";
        submitCanvasManager.Comments.text = "Generic Comments";
        submitCanvasManager.Species.value = 2;
        submitCanvasManager.IceRectangle.value = 3;
        submitCanvasManager.ProductionWk.value = 4;
        submitCanvasManager.DayDrop.value = 5;
        submitCanvasManager.MonthDrop.value = 6;
        submitCanvasManager.YearDrop.value = 7;
        submitCanvasManager.SampleLocationName.value = 1;
        submitCanvasManager.CompleteStore();

        Assert.AreEqual("Test Name2", submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company2", submitCanvasManager.Company.text);
        Assert.AreEqual("", submitCanvasManager.Comments.text);
        Assert.AreEqual(0, submitCanvasManager.Species.value);
        Assert.AreEqual(0, submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, submitCanvasManager.YearDrop.value);
        Assert.IsTrue(submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);
    }
    [Test]
    public void SubmitCanvasManager_CompleteSubmission()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name",
            Company = "Test Company"
        });
        submitCanvasManager.CompleteSubmission();

        Assert.AreEqual("Test Name", submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company", submitCanvasManager.Company.text);
        Assert.AreEqual("", submitCanvasManager.Comments.text);
        Assert.AreEqual(0, submitCanvasManager.Species.value);
        Assert.AreEqual(0, submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, submitCanvasManager.YearDrop.value);
        Assert.IsTrue(submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);
    }
    [Test]
    public void SubmitCanvasManager_CompleteStore()
    {
        SaveData.Instance.SaveUserProfile(new User
        {
            Name = "Test Name",
            Company = "Test Company"
        });
        submitCanvasManager.CompleteStore();
        Assert.AreEqual("Test Name", submitCanvasManager.Name.text);
        Assert.AreEqual("Test Company", submitCanvasManager.Company.text);
        Assert.AreEqual("", submitCanvasManager.Comments.text);
        Assert.AreEqual(0, submitCanvasManager.Species.value);
        Assert.AreEqual(0, submitCanvasManager.IceRectangle.value);
        Assert.AreEqual(0, submitCanvasManager.SampleLocationName.value);
        Assert.AreEqual(0, submitCanvasManager.ProductionWk.value);
        Assert.AreEqual(0, submitCanvasManager.DayDrop.value);
        Assert.AreEqual(0, submitCanvasManager.MonthDrop.value);
        Assert.AreEqual(0, submitCanvasManager.YearDrop.value);
        Assert.IsTrue(submitCanvasManager.SubmissionPopUp.isActiveAndEnabled);
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