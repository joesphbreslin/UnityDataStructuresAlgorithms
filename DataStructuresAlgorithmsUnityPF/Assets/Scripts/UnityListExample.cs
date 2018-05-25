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
        outputText.text = "Item[" + index.ToString() + "] + name: " + unityList[index].name;
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
    }

    public void Clear()
    {
        foreach(GameObject g in unityList)
        {
            Destroy(g);
        }
        unityList.Clear();
    }

    public void Remove()
    {
        int index = int.Parse(removeField.text);
        Destroy(unityList[index].gameObject);
        unityList.RemoveAt(index);
    }

    public void Reverse()
    {
        unityList.Reverse();
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
    }

    public void RemoveAt()
    {
        int index = int.Parse(removeAtField.text);
        Destroy(unityList[index].gameObject);  
        unityList.RemoveAt(index);
    }
    #endregion

}
