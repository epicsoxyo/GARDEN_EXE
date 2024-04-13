using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VirusTypes {bust, galaxy, rose, monstera};

public class VirusSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] virusObjects = new GameObject[4];
    [SerializeField] private ToolHandler toolHandler;
    [SerializeField] private DeathScript deathHandler;

    private bool[] activeViruses = {false, false, false, false};
    private int numOfActiveViruses = 0;

    [SerializeField] private float timeToFirstVirus;
    [SerializeField] private float minTimeToNextVirus;
    [SerializeField] private float startingMaxTimeToNextVirus;
    private float maxTimeToNextVirus;
    [SerializeField] private float lerpTime;
    private float elapsedTime = 0f;

    private bool isCountingDown;
    private float timer;



    private void Awake()
    {
        isCountingDown = true;
        timer = timeToFirstVirus;
        maxTimeToNextVirus = startingMaxTimeToNextVirus;
    }



    private void Update()
    {
        if (!isCountingDown)
        {
            ChooseVirusToSpawn();
            timer = Random.Range(minTimeToNextVirus, maxTimeToNextVirus);
            isCountingDown = true;
        }
        else
        {
            DecrementTime();
            if (timer <= 0) isCountingDown = false;
        }
        DecrementTimeToNextVirus();
    }

    private void ChooseVirusToSpawn()
    {
        int choice = Random.Range(0, 4 - numOfActiveViruses);

        for(int i = 0; i < 4; i++)
        {
            if (!activeViruses[i])
            {
                if (choice == 0)
                {
                    CreateVirus(i);
                    break;
                }
                else 
                    choice -= 1;
            }
        }
    }

    private void CreateVirus(int virusType)
    {
        AudioManager.instance.Play("VirusPopup");

        GameObject newVirus = Instantiate(virusObjects[virusType], this.transform);
        newVirus.GetComponent<VirusScript>().SetToolHandler(toolHandler);
        newVirus.GetComponent<VirusScript>().SetDeathHandler(deathHandler);

        activeViruses[virusType] = true;
        numOfActiveViruses += 1;
    }

    private void DecrementTime()
    {
        timer -= Time.deltaTime;
    }

    private void DecrementTimeToNextVirus()
    {
        maxTimeToNextVirus = Mathf.Lerp(startingMaxTimeToNextVirus, minTimeToNextVirus, elapsedTime/lerpTime);
        elapsedTime += Time.deltaTime;
    }



    public void DeactivateVirus(int virusType)
    {
        if (activeViruses[virusType])
        {
            activeViruses[virusType] = false;
            numOfActiveViruses -= 1;
        }
    }

}