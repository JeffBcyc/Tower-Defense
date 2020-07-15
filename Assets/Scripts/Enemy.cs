using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    List<Waypoint> travel = new List<Waypoint>();

    [SerializeField] GameObject damageText = null;

    [SerializeField] int EnemyHP = 50;
    [SerializeField] ParticleSystem dmgParticle;
    [SerializeField] ParticleSystem deathFX;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        travel = pathfinder.GetPath();
        StartCoroutine(EnemyPatrolPath());
        // the execution will revist there after the code meets yield return new ...
        // it comes back here to execute next line
        // when the rest execution continues for 0.5 seconds it goes back to EnemyPatrolPath Method.
    }

    IEnumerator EnemyPatrolPath()
    {
        foreach (Waypoint waypoint in travel)
        {
            transform.position = waypoint.transform.position + new Vector3(0,10,0);
            yield return new WaitForSeconds(0.5f);
            // mode will stop executing after the first round here
            // then it goes back to the start method to execute whats left
            // after 0.5 seconds it comes back here after 0.5seconds to continue
        } 

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnParticleCollision(GameObject other)
    {
        int damageTaken = UnityEngine.Random.Range(0, 10);
        dmgParticle.Play();
        createDamageText(damageTaken);
        EnemyHP -= damageTaken;
        if (EnemyHP < 0) 
        {
            ParticleSystem vfx = Instantiate(deathFX, transform.position, Quaternion.identity);
            vfx.Play();
            Destroy(gameObject);
        }

    }

    private void createDamageText(int damage)
    {
        GameObject _damageText = Instantiate(damageText, transform.position + new Vector3(0,10f,0), Quaternion.identity);
        _damageText.name = Time.time.ToString();
        Rigidbody textRigid = _damageText.GetComponent<Rigidbody>();
        Vector3 initialSpeed = new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(0, 20), UnityEngine.Random.Range(-10, 10));
        textRigid.velocity =  initialSpeed;
        _damageText.transform.parent = gameObject.transform;
        TextMesh damageTextMesh = _damageText.GetComponent<TextMesh>();

        if (damage == 0) 
        {
            damageTextMesh.text = "Missed!";
        } 
        else
        {
            damageTextMesh.text = damage.ToString();
        }
        Destroy(_damageText, 1.0f);

    }


}
