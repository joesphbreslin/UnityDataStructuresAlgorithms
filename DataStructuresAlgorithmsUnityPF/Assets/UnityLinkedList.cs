using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityLinkedList : MonoBehaviour {
    //Generic implementation is a doubly linked list
    LinkedList<GameObject> unityLinkedList = new LinkedList<GameObject>();
    public Text outputText;
    public Dropdown inputObject;
    string shape;
   
    public void Find(GameObject g)
    {
        unityLinkedList.Find(g).Value.transform.localScale *= 2;
        outputText.text = "Found " + unityLinkedList.Find(g).Value.name;
    }
    public void FindLast(GameObject g)
    {
        outputText.text = unityLinkedList.FindLast(g).Value.name.ToString();
    }
    public void Count()
    {
        outputText.text = unityLinkedList.Count.ToString();
    }
    public void Clear()
    {
        unityLinkedList.Clear();
        outputText.text = "Linked List Cleared";
    }
    public void Contains(GameObject g)
    {
        if (unityLinkedList.Contains(g))
            outputText.text = "LinkedList contains " + g.name;
        else
        {
            outputText.text = "LinkedList does not contain " + g.name;
        }
    }
    public void AddFirst()
    {
        GameObject newObj = Instantiate(Resources.Load(shape), transform, false) as GameObject;
        unityLinkedList.AddFirst(newObj);
        outputText.text = newObj.name + " Added to the front of LinkedList";

    }
    public void AddLast()
    {
        GameObject newObj = Instantiate(Resources.Load(shape), transform, false) as GameObject;
        unityLinkedList.AddLast(newObj);
        outputText.text = newObj.name + " Added to the end of LinkedList";
    }
    public void RemoveFirst()
    {
        Destroy(unityLinkedList.First.Value.gameObject);
        unityLinkedList.RemoveFirst();
        outputText.text = "Removed First OBJ in the list";
    }
    public void RemoveLast()
    {
        Destroy(unityLinkedList.Last.Value.gameObject);
        unityLinkedList.RemoveLast();       
        outputText.text = "Removed Last OBJ in the list";
    }
    public void Remove(GameObject newObj)
    {
        string objStr = newObj.name;
        GameObject curr = unityLinkedList.Find(newObj).Value.gameObject;
        unityLinkedList.Remove(newObj);
        Destroy(curr);
        outputText.text = objStr + " Removed";
    }

    private void FixedUpdate()
    {
        switch (inputObject.value)
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
    }
}
