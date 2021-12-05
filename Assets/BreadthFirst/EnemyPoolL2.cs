using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolL2 : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] [Range(0,20)] int size=5;
    [SerializeField] [Range(0.1f,20f)] float timer=1f;

    GameObject[] pool;

     void Awake()
    {
        FillPool();
        
        
    }    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    void FillPool()
    {
        pool =new GameObject[size];

        for(int i=0;i<pool.Length;i++)
        {
            pool[i]=Instantiate(enemy,transform);
            pool[i].SetActive(false);

        }
    }

    IEnumerator GenerateEnemy() // generating enemies from starting points
    {
        while(true)
        {
            ActivateEnemyInPool();
           // Instantiate(enemy,transform);
            yield return new WaitForSeconds(timer);
        }

    }
    void ActivateEnemyInPool() // enable enemy object in hierachy  automaticaly
    {
        for(int i=0; i<pool.Length;i++)
        {
            if(pool[i].activeInHierarchy ==false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

}
