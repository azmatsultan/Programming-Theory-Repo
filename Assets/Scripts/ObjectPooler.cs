using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool2;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Loop through list of pooled objects,deactivating them and adding them to the list 
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            if (Random.Range(1.0f, 2.0f) >= 1.5f)
            {
                GameObject obj = (GameObject)Instantiate(objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                obj.transform.SetParent(this.transform); // set as children of Spawn Manager }

            }
            else
            {
                GameObject obj = (GameObject)Instantiate(objectToPool2);
                obj.SetActive(false);
                pooledObjects.Add(obj);
                obj.transform.SetParent(this.transform); // set as children of Spawn Manager }
            }
        }
    }

    public GameObject GetPooledObject()
    {
        // For as many objects as are in the pooledObjects list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // if the pooled objects is NOT active, return that object 
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        // otherwise, return null   
        return null;
    }

}
