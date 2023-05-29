using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] protected uint initPoolSize;
    [SerializeField] protected BrickController objectToPool;
    [SerializeField] protected Transform parent;
    // store the pooled objects in a collection
    protected Stack<BrickController> stack;
    protected virtual void Start()
    {
        SetupPool();
    }


    // creates the pool (invoke when the lag is not noticeable)
    public BrickController GetPooledObject()
    {
        // if the pool is not large enough, instantiate a new PooledObjects
        if (stack == null) 
        { 
            SetupPool(); 
        }
        if (stack.Count == 0)
        {
            BrickController newInstance = Instantiate(objectToPool);
            newInstance.Pool = this;
            return newInstance;
        }
        // otherwise, just grab the next one from the list
        BrickController nextInstance = stack.Pop();
        nextInstance.gameObject.SetActive(true);
        return nextInstance;
    }

    public void ReturnToPool(BrickController pooledObject)
    {
        stack.Push(pooledObject);
        pooledObject.transform.SetParent(parent);
        pooledObject.gameObject.SetActive(false);
    }

    protected void SetupPool()
    {
        stack = new Stack<BrickController>();
        BrickController instance = null;
        for (int i = 0; i < initPoolSize; i++)
        {
            instance = Instantiate(objectToPool, parent);
            instance.Pool = this;
            instance.gameObject.SetActive(false);
            stack.Push(instance);
        }
    }

    public int Count => stack.Count;
}
