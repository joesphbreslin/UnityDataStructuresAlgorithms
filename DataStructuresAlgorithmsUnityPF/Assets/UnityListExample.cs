using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityListExample : MonoBehaviour {

    public InputField itemField, addField, removeField, removeAtField;
    public Text outputText;
    List<GameObject> unityList = new List<GameObject>();

    void Update()
    {

    }

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
        int index = int.Parse(addField.text);    
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
        //GameObject newObj = Instantiate(Resources.Load(shape), transform,false) as GameObject;      
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
        unityList.RemoveAt(index);
    }

    public void Reverse()
    {
        unityList.Reverse();
    }

    public void RemoveAt()
    {
        int index = int.Parse(removeAtField.text);
        Destroy(unityList[index].gameObject);  
        unityList.RemoveAt(index);
    }
    #endregion

}
