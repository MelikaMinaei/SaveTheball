using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    Level level;
    [SerializeField] GameObject blockSparklesVFS;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprites;
    

    private void Start()
    {
        level = FindObjectOfType<Level>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        { 
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
       int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        
        int spriteInd = timesHit - 1;
        if (hitSprites[spriteInd] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteInd];
        }
        else
        {
            Debug.LogError("Sprite missing from array" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX()
    {
        FindObjectOfType<GameStatus>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.ShakeTrigger();
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFS, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
