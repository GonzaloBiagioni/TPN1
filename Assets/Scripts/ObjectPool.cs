using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instancia;

    public GameObject[] objectPrefabs; 
    public int cantidadInicial = 3;

    private List<GameObject>[] pools;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }

        pools = new List<GameObject>[objectPrefabs.Length];
        for (int i = 0; i < objectPrefabs.Length; i++)
        {
            pools[i] = new List<GameObject>();
            for (int j = 0; j < cantidadInicial; j++)
            {
                GameObject obj = Instantiate(objectPrefabs[i]);
                obj.SetActive(false);
                pools[i].Add(obj);
            }
        }
    }

    public GameObject GetObject(int tipo)
    {
        foreach (GameObject obj in pools[tipo])
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject nuevoObj = Instantiate(objectPrefabs[tipo]);
        nuevoObj.SetActive(true);
        pools[tipo].Add(nuevoObj);
        return nuevoObj;
    }
}