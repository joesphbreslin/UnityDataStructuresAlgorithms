using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

// RemoveAt(), Remove(Key), Clear(), Count(), ContainsKey(), Item[Key], Add(Key,Value)
public class UnitySortedList : MonoBehaviour {

    public Text outputText;
    public InputField addKeyField, removeAtIndexField, removeKeyField, itemKeyField;
    SortedList<string, GameObject> unitySortedList = new SortedList<string, GameObject>();

    public void AddKeyValue()
    {
        string key = addKeyField.text;
        unitySortedList.Add(key, Instantiate(Resources.Load("SortedListCube"), transform, false) as GameObject);
        Text [] texts = unitySortedList[key].gameObject.GetComponentsInChildren<Text>();
        foreach(Text t in texts)
        {
            t.text = key;
        }
        outputText.text = key + " gameobject added";
    }

    public void RemoveAt()
    {
        int index = int.Parse(removeAtIndexField.text);
        if (index < unitySortedList.Count)
        {
            string s = unitySortedList.Keys[index];
            Destroy(unitySortedList.Values[index].gameObject);
            unitySortedList.RemoveAt(index);
            outputText.text = "Item " + s + " is removed.";
        }
        else
        {
            outputText.text = "Try a lower Integer";
        }
    }

    public void RemoveByKey()
    {
        string key = removeKeyField.text;
        if (unitySortedList.ContainsKey(key))
        {
            Destroy(unitySortedList[key].gameObject);
            unitySortedList.Remove(key);
            outputText.text = key + " is removed";
        }
        else
        {
            outputText.text = "Try a different Key..";
        } 
    }

    public void Clear()
    {
        foreach(string key in unitySortedList.Keys)
        {
            Destroy(unitySortedList[key]);
        }
        unitySortedList.Clear();
        outputText.text = "Items cleared";

    }

    public void Count()
    {
        int count = unitySortedList.Count;
        outputText.text = count + " Items";
    }

    public void ItemKey()
    {
        string key = itemKeyField.text;
        if (unitySortedList.ContainsKey(key))
        {
           outputText.text =  key + ", " + unitySortedList[key].name;
        }
        else
        {
            outputText.text = "Try different Key";
        }
    }
}
