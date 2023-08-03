using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObj : MonoBehaviour
{
    BulletInfo info;
    float time;
    public void InitInfo(BulletInfo info)
    {
        this.info = info;
    }

    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.forward * info.forwardSpeed * Time.deltaTime);
        switch (info.type)
        {
            case 1: break;
            case 2:
                transform.Translate(Vector3.right * Time.deltaTime * Mathf.Sin(time * info.roundSpeed) * info.ringhtSpeed);
                break;
            case 3:
                transform.rotation *= Quaternion.AngleAxis(info.roundSpeed * Time.deltaTime, Vector3.up);
                break;
            case 4:
                transform.rotation *= Quaternion.AngleAxis(-info.roundSpeed * Time.deltaTime, Vector3.up);
                break;
            case 5:
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(PlayerObj.Instance.transform.position - transform.position), info.roundSpeed * Time.deltaTime);
                break;
        }
        if(time>=info.lifeTime)Dead();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerObj player = other.GetComponent<PlayerObj>();
            player.Wound();
            Dead();
        }
    }
    public void Dead()
    {
        GameObject effObj = Instantiate(Resources.Load<GameObject>(info.deadEff));
        effObj.transform.position = transform.position;
        Destroy(effObj, 1);
        Destroy(gameObject);
    }
}
