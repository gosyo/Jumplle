using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    float currentYPos = 0f;
    public float cameraHeight = 5.5f;

    public Transform platformPool;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlatformPool();

        while (currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();
        }
    }

    void SpawnPlatformPool()
    {
        int basicPlatformAmount = 28;
        int weakPlatformAmount = 8;
        int strongPlatformAmount = 5;
        int poisonPlatformAmount = 2;
        int blindPlatformAmount = 2;
        
            

        for (int i = 0; i < basicPlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[0], platformPool);
            platform.SetActive(false);
        }

        for (int i = 0; i < weakPlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[1], platformPool);
            platform.SetActive(false);
        }

        for (int i = 0; i < strongPlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[2], platformPool);
            platform.SetActive(false);
        }

        for (int i = 0; i < poisonPlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[3], platformPool);
            platform.SetActive(false);
        }

        for (int i = 0; i < blindPlatformAmount; i++)
        {
            GameObject platform = Instantiate(platformPrefabs[4], platformPool);
            platform.SetActive(false);
        }
    }

    void PickNewPlatform()
    {
        currentYPos += Random.Range(0.5f, 1.1f);
        float xPos = Random.Range(-3.8f, 3.8f);

        int r = 0;
        do
        {
            r = Random.Range(0, platformPool.childCount);
        } while (platformPool.GetChild(r).gameObject.activeInHierarchy);

        platformPool.GetChild(r).position = new Vector2(xPos, currentYPos);
        platformPool.GetChild(r).gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (currentYPos < Camera.main.transform.position.y + cameraHeight)
        {
            PickNewPlatform();
        }
    }
}
