using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirusScript : MonoBehaviour
{

    private Image image;
    private Animator anim;

    private int health;

    private ToolHandler toolHandler;
    private DeathScript deathHandler;

    private VirusSpawner virusSpawner;
    [SerializeField] private VirusTypes virusType;

    [SerializeField] private float timeRemaining = 15f;
    [SerializeField] private float timeLeftFirstWarning = 10f;
    [SerializeField] private float timeLeftFinalWarning = 5f;

    private bool triggeredFirstWarning = false;
    private bool triggeredFinalWarning = false;



    private void Awake()
    {
        image = GetComponent<Image>();
        anim = GetComponent<Animator>();
        health = 3;
    }

    private void Start()
    {
        virusSpawner = transform.parent.GetComponent<VirusSpawner>();
        TriggerRandomAnimation();
    }
    
    private void TriggerRandomAnimation()
    {
        int choice = Random.Range(0, 4);
        
        switch (choice)
        {
            case 0: anim.SetTrigger("centipedeTrigger"); break;
            case 1: anim.SetTrigger("childTrigger"); break;
            case 2: anim.SetTrigger("skullTrigger"); break;
            case 3: anim.SetTrigger("spiderTrigger"); break;
            default: break;
        }
    }



    private void Update()
    {
        Countdown();
    }

    private void Countdown()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining < timeLeftFirstWarning && !triggeredFirstWarning)
        {
            image.color = new Color(255, 255, 0);
            AudioManager.instance.Play("VirusWarning");
            triggeredFirstWarning = true;
        }
        else if (timeRemaining < timeLeftFinalWarning && !triggeredFinalWarning)
        {
            image.color = new Color(255, 0, 0);
            AudioManager.instance.Play("VirusWarning");
            triggeredFinalWarning = true;
        }
        else if (timeRemaining < 0)
        {
            deathHandler.DoDeath();
        }
    }



    public void SetToolHandler(ToolHandler newToolHandler)
    {
        toolHandler = newToolHandler;
    }

    public void SetDeathHandler(DeathScript newDeathHandler)
    {
        deathHandler = newDeathHandler;
    }

    public void Attack()
    {
        if (toolHandler.GetTool() == Tools.holyAntiVirus)
        {
            AudioManager.instance.Play("VirusHit");
            health -= 1;

            if (health <= 0)
                Kill();
        }
        else
        {
            AudioManager.instance.Play("WrongCursor");
        }
    }

    private void Kill()
    {
        virusSpawner.DeactivateVirus((int)virusType);
        Destroy(gameObject);
    }

}
