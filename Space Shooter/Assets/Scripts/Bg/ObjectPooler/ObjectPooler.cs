﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public int size = 30;
        public string tag;
        public GameObject prefab;
    }

    #region Singleton
    //public static ObjectPooler instance;

    //void Awake()
    //{
        //instance = this;
    //}
    #endregion

    List<GameObject> objectToPool;
    public List<Pool> pool;
    Dictionary<string, List<GameObject>> poolDictionary;
    [SerializeField] GameObject parentGameObject;


    void Awake()
    {
        poolDictionary = new Dictionary<string, List<GameObject>>();

        foreach (Pool tempPool in pool)
        {
            objectToPool = new List<GameObject>();
            for (int i = 0; i < tempPool.size; i++)
            {
                GameObject gObj = Instantiate(tempPool.prefab, parentGameObject.transform);
                gObj.SetActive(false);
                objectToPool.Add(gObj);
            }
            //Debug.Log("in for : " + tempPool.tag);
            poolDictionary.Add(tempPool.tag, objectToPool);
        }
    }

    public GameObject GetObject(string tag)
    {
        //Debug.Log(tag);
        if (poolDictionary.ContainsKey(tag))
        {
            List<GameObject> tempObjectToPool = poolDictionary[tag];
            foreach (GameObject currentObject in tempObjectToPool)
            {
                if (currentObject.activeInHierarchy == false)
                {
                    return currentObject;
                }
            }

            foreach (Pool tempPool in pool)
            {
                GameObject gObj = Instantiate(tempPool.prefab);
                gObj.SetActive(false);
                //tempObjectToPool.Add(gObj);
                poolDictionary[tag].Add(gObj);
                //poolDictionary.Add(tag, tempObjectToPool);
                return gObj;
            }
        }
        return null;
        
    }

}
