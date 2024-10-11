using System.Collections;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite deadSprite;

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        UpdateSPrite();
        DisablePhysic();
        StartCoroutine(Animate());
    }

    private void UpdateSPrite()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder = 10;
        
        if (deadSprite != null )
        {
            spriteRenderer.sprite = deadSprite;
        }

    }

    private void DisablePhysic()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        foreach(Collider2D collider in colliders)
        {
            collider.enabled = false;
        }

        GetComponent<Rigidbody2D>().isKinematic = true;

        player player = GetComponent<player>();
        EnemyAI enemyAI = GetComponent<EnemyAI>();

        if(player  != null)
            player.enabled = false;
        if(enemyAI != null)
            enemyAI.enabled = false;
            

    }

    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duration = 3f;

        float jumpVelocity = 10f;
        float gravity = -36f;

        Vector3 velocity = Vector3.up * jumpVelocity;

        while(elapsed < duration)
        {
            transform.position += velocity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
