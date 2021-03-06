using System;
using PCC;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChangeMaterials : MonoBehaviour
{
    private readonly string characterManagerStr = "CharacterManager";
    private readonly string moraleManagerStr = "Moral";
    private readonly string foodManagerStr = "Food";
    private readonly string woodManagerStr = "Wood";
    private readonly string wineManagerStr = "Wine";
    private readonly string goldManagerStr = "Gold";
    private readonly string timeManagerStr = "Time";
    private readonly string FightManagerStr = "FightMat";
    private readonly string sldValue = "FightSlider";
    private readonly string FinishButton = "FinishButton";
    
    private GameObject x;


    public void _EnableFinish(){

	    x = GameObject.FindGameObjectWithTag(FinishButton);
	    x.GetComponent<Button>().interactable = true;
    }

    public void _ChangeGold(float gold)
    {
        x = GameObject.FindGameObjectWithTag(goldManagerStr);
        x.GetComponent<MaterialBase>().Add(gold);
    }
    
    public void _FightMaterial(float y)
    {
        x = GameObject.FindGameObjectWithTag(FightManagerStr);
        x.GetComponent<MaterialBase>().Add(y);
    }
    
    public void _FightMat2()
    {
        x = GameObject.FindGameObjectWithTag(FightManagerStr);
        print(x);
        var b = GameObject.FindGameObjectWithTag(sldValue);
        print(b);
        print(-b.GetComponent<Slider>().value);
        x.GetComponent<MaterialBase>().Add(-b.GetComponent<Slider>().value);
    }
    
    public void _ChangeTime(float time)
    {
        x = GameObject.FindGameObjectWithTag(timeManagerStr);
        x.GetComponent<MaterialBase>().Add(time);
    }    
    public void __ChangeFoodModifier(float y)
    {
        x = GameObject.FindGameObjectWithTag(foodManagerStr);
        var gameObject = GameObject.FindGameObjectWithTag(characterManagerStr);
        var characterManager = gameObject.GetComponent<CharacterManager>();

        foreach (var character in characterManager.Crew)
        {
            if (character.ClassId == ClassIdEnum.Chef)
            {
                x.GetComponent<MaterialBase>().Modifier += y;
            }
        }

    }
    public void _ChangeIsHurt(bool test)
    {
        x = GameObject.FindGameObjectWithTag(characterManagerStr);
        var characterManager = x.GetComponent<CharacterManager>();

        var RandClass = Random.Range(0, characterManager.Crew.Count);
        characterManager.Crew[RandClass].IsAbleToWork = false;
    }
    
    public void _ChangeFood(float y)
    {
        x = GameObject.FindGameObjectWithTag(foodManagerStr);
        x.GetComponent<MaterialBase>().Add(y);
    }
    
    public void _ChangeWine(float y)
    {
        x = GameObject.FindGameObjectWithTag(wineManagerStr);
        x.GetComponent<MaterialBase>().Add(y);

    }
    public void _ChangeWood(float y)
    {
        x = GameObject.FindGameObjectWithTag(woodManagerStr);
        x.GetComponent<MaterialBase>().Add(y);

    }
    public void _ChangeMoral(float y)
    {
        x = GameObject.FindGameObjectWithTag(moraleManagerStr);
        x.GetComponent<MaterialBase>().Add(y);
    }
    public void _ChangeFoodConsumption(float y)
    {
        x = GameObject.FindGameObjectWithTag(characterManagerStr);
        var CharacterManager = x.GetComponent<CharacterManager>();

        foreach (var character in CharacterManager.Crew)
        {
            character.FoodConsumption += y;
        }
    }

    private void OnGUI()
    {
                if (GUI.Button(new Rect(10, 10, 150, 100), "I am a button"))
                {
                    _FightMat2();
                }
    }
}
