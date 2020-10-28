using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{

    public GameObject bullet;
    public int MAX_BULLETS = 10;

    //TODO: create a structure to contain a collection of bullets
    private Queue<GameObject> BulletQueue = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool

        BuildBulletPool();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BuildBulletPool()
    {
        for (int i = 0; i < MAX_BULLETS; i++)
        {
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            BulletQueue.Enqueue(tempBullet);
        }
    }

    private int GetPoolSize()
    {
        return BulletQueue.Count;
    }

    private bool IsPoolEmpty()
    {
        if(BulletQueue.Count > 0)
        {
            print(BulletQueue.Count);
            return false;
        }
        else
        {
            print(BulletQueue.Count);
            return true;
        }
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(Vector3 spawn, Quaternion q)
    {
        GameObject temp;

        if (!IsPoolEmpty())
        {
            temp = BulletQueue.Dequeue();
            temp.transform.position = spawn;
            temp.transform.rotation = q;
        }
        else
        {
            temp = Instantiate(bullet);
       
        }
        temp.SetActive(true);

        temp.transform.position = spawn;
        temp.transform.rotation = q;

        
        return temp;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.transform.position = new Vector3(0, -10, 0);
        bullet.SetActive(false);
        BulletQueue.Enqueue(bullet);
        
    }
}
