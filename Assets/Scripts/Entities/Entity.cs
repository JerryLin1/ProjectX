using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected float maxHP;
    protected float currentHP;
    protected float movementSpeed;
    protected Rigidbody2D rb;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected Vector2 movement;
    protected float cooldownFactor = 1f;
    protected float lastVelocity = 0;
    public bool isBeingAttacked;
    protected Shader shaderGUItext;
    protected Shader shaderSpritesDefault;
    public AudioManager audioManager;
    float flashTimer = 0;
    public List<StatusEffect> statuses = new List<StatusEffect>();

    protected virtual void Start()
    {
        customStart();
        currentHP = maxHP;
        animator = transform.Find("Sprites/Body").GetComponent<Animator>();
        spriteRenderer = transform.Find("Sprites/Body").GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        shaderGUItext = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = transform.Find("Sprites/Body").GetComponent<SpriteRenderer>().material.shader;
        audioManager = transform.Find("Audio").GetComponent<AudioManager>();
    }
    protected virtual void Update()
    {
        if (flashTimer > 0)
        {
            flashTimer -= Time.deltaTime;
            if (flashTimer <= 0) spriteRenderer.material.shader = shaderSpritesDefault;
        }
        customUpdate();
    }
    protected virtual void customStart() { }
    protected virtual void customUpdate() { }
    public virtual void knockback(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public virtual void takeDamage(float damage, Entity source)
    {
        audioManager.Play("Hit");
        currentHP -= damage;
        if (currentHP <= 0)
        {
            source.triggerOnKillEffects();
            Destroy(gameObject);
            return;
        }
        spriteRenderer.material.shader = shaderGUItext;
        flashTimer = 0.1f;
        source.triggerOnHitEffects(this);
        triggerOnDamagedEffects(source);
    }
    public virtual void heal(float heal)
    {
        currentHP += heal;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        triggerOnHealEffects();
    }
    public virtual void triggerPassiveEffects() { }
    public virtual void triggerOnDamagedEffects(Entity source) { }
    public virtual void triggerOnHealEffects() { }
    public virtual void triggerOnHitEffects(Entity enemy) { }
    public virtual void triggerOnKillEffects() { }
    public virtual float GetMovementSpeed() { return movementSpeed; }
    public virtual void SetMovementSpeed(float newMovementSpeed) { movementSpeed = newMovementSpeed; }
    public virtual float GetCooldownFactor() { return cooldownFactor; }
    public virtual void SetCooldownFactor(float newCooldownFactor) { cooldownFactor = newCooldownFactor; }
}
