using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObj : MonoBehaviour
{
    static PlayerObj instance;
    public static PlayerObj Instance=>instance;
    public int nowHp;
    public int maxHp;
    public int speed;
    public int roundSpeed;
    public bool dead;
    float hValue;
    float vValue;
    Quaternion targetQ;
    Vector3 nowPos;
    Vector3 frontPos;
    private void Awake() {
        instance=this;
    }
    void Update()
    {
        if (dead) return;
        hValue = Input.GetAxisRaw("Horizontal");
        vValue = Input.GetAxisRaw("Vertical");
        if(hValue==0) targetQ=Quaternion.identity;
        else targetQ=hValue<0?Quaternion.AngleAxis(20,Vector3.forward):Quaternion.AngleAxis(-20,Vector3.forward);
        transform.rotation=Quaternion.Slerp(transform.rotation,targetQ,roundSpeed*Time.deltaTime);
        frontPos=transform.position;
        transform.Translate(Vector3.forward*vValue*speed*Time.deltaTime);
        transform.Translate(Vector3.right*hValue*speed*Time.deltaTime,Space.World);
        nowPos=Camera.main.WorldToScreenPoint(transform.position);
        if(nowPos.x<=0||nowPos.x>Screen.width) transform.position=new Vector3(frontPos.x,transform.position.y,transform.position.z);
        if(nowPos.y<=0||nowPos.y>Screen.height) transform.position=new Vector3(transform.position.x,transform.position.y,frontPos.z);

        if(Input.GetMouseButtonDown(0)){
            RaycastHit hitinfo;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hitinfo,1<<LayerMask.NameToLayer("bullet"))){
                BulletObj bulletObj=hitinfo.transform.GetComponent<BulletObj>();
                bulletObj.Dead();
            }
        }    
    }

    public void Dead()
    {
        dead = true;
        Time.timeScale=0;
        EndPanel.Instance.Show();
    }
    public void Wound()
    {
        if (dead) return;
        nowHp--;
        GamePanel.Instance.ChangeHp(nowHp);
        if (nowHp == 0) Dead();
    }

}
