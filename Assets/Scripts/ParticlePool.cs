using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : Singleton<ParticlePool>
{
    public Queue<GameObject> _ObjectPool;  
    public GameObject _ObjPrefab; 
    public int _poolSize;

    
    void Start()
    {
        InitPool(_poolSize);
    }
    
    public void InitPool(int poolSize)
    {
        _ObjectPool= new Queue<GameObject>();

        for(int i=0 ;i<poolSize;i++)
        {
            GameObject newGO =Instantiate(_ObjPrefab); 
            newGO.SetActive(false);
            //_ObjectPool.Enqueue(newGO); 
        }
    }
    

    void AddObjectsToPool()
    {
        GameObject instantiatedObj = Instantiate(_ObjPrefab);
        instantiatedObj.SetActive(false);
        //   _ObjectPool.Enqueue(instantiatedObj);
    }


    public GameObject GetObjFromPool(Vector3 center) 
    {
        if(_ObjectPool.Count <=0) 
        {
            AddObjectsToPool();
        }
        
        GameObject instantiatedGO = _ObjectPool.Dequeue();
        instantiatedGO.transform.position = center; 
        instantiatedGO.SetActive(true);

        return instantiatedGO;

    }
    
    

    public void ReturnObjToPool(GameObject go)  
    {
        go.SetActive(false);
        _ObjectPool.Enqueue(go);
    }
}
