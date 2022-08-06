using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = new Inventory(21);
    }

    public void DropItem(Collectable item)
    {
        Vector3 spawnLocation = transform.position;

        float randX = Random.Range(-1f, 1f);
        float randY = Random.Range(-1f, 1f);

        Vector3 spawnOffset = new Vector3(randX, randY, 0f).normalized;

        Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3Int position = new Vector3Int((int)transform.position.x,
                (int)transform.position.y, 0);

            if(GameManager.instance.tileManager.IsInteractable(position))
            {
                Debug.Log("Tile is interactable");
            }
        }
    }
}
