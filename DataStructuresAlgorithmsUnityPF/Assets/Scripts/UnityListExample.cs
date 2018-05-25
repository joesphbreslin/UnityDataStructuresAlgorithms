using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityListExample : MonoBehaviour {

    public InputField itemField, removeField, removeAtField, insertField;
    public Dropdown addDropDown, insertDropDown;
    public Text outputText;
    List<GameObject> unityList = new List<GameObject>();

    #region Button Functions
    public void Count()
    {
        outputText.text = "Current count of list: " + unityList.Count.ToString();
    }

    public void GetItemName()
    {
       
        int index = int.Parse(itemField.text);
        if (index < unityList.Count)
            outputText.text = "Item[" + index.ToString() + "] + name: " + unityList[index].name;
        else
            outputText.text = "Try a lower Integer";
    }

    public void Add()
    {
        int index = addDropDown.value;   
        string shape;
        switch (index)
        {
            case 0:
                shape = "Cube";
                break;
            case 1:
                shape = "Sphere";
                break;
            default:
                shape = "Pyramid";
                break;
        }
        unityList.Add(Instantiate(Resources.Load(shape), transform, false) as GameObject);
        outputText.text = unityList[unityList.Count -1].name + " Added";
    }

    public void Clear()
    {
        foreach(GameObject g in unityList)
        {
            Destroy(g);
        }
        unityList.Clear();
        outputText.text = "Items cleared";
    }

    public void Remove()
    {       
        int index = int.Parse(removeField.text);
        if (index < unityList.Count)
        {
            Destroy(unityList[index].gameObject);
            unityList.Remove(unityList[index]);
            outputText.text = "Item " + index + " is removed.";
        }
        else
            outputText.text = "Try a lower Integer";
    }

    public void Reverse()
    {
        unityList.Reverse();
        outputText.text = "Item list reversed";
    }

    public void Insert()
    {
        int index = int.Parse(insertField.text);
        int shapeIndex = insertDropDown.value;
        string shape;
        switch (shapeIndex)
        {
            case 0:
                shape = "Cube";
                break;
            case 1:
                shape = "Sphere";
                break;
            default:
                shape = "Pyramid";
                break;
        }
      
        Destroy(unityList[index]);
        unityList.Insert(index,Instantiate(Resources.Load(shape), transform, false) as GameObject);
        outputText.text = unityList[index].name + " Inserted  at " + index + " position";

    }

    public void RemoveAt()
    {
        int index = int.Parse(removeAtField.text);
        if (index < unityList.Count)
        {
            Destroy(unityList[index].gameObject);
            unityList.RemoveAt(index);
            outputText.text = "Item " + index + " is removed.";
        }
        else
        {
            outputText.text = "Try a lower Integer";
        }
    }
    #endregion

}
