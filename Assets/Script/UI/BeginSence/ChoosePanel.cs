using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoosePanel : BasePanel<ChoosePanel>
{
    public Button btnLeft;
    public Button btnRight;
    public Button btnStart;
    public Button btnClose;
    public Transform heroPos;
    public List<GameObject> hpList;
    public List<GameObject> speedList;
    public List<GameObject> volumeList;

    GameObject airplaneObj;
    public override void Init()
    {
        btnLeft.onClick.AddListener(()=>{
            mGameData.Instance.nowHeroIndex--;
            if(mGameData.Instance.nowHeroIndex<0) mGameData.Instance.nowHeroIndex=mGameData.Instance.roleData.roleList.Count-1;
            ChangeHero();
        });
        btnRight.onClick.AddListener(()=>{
            mGameData.Instance.nowHeroIndex++;
            if(mGameData.Instance.nowHeroIndex>mGameData.Instance.roleData.roleList.Count-1) mGameData.Instance.nowHeroIndex=0;
            ChangeHero();
        });
        btnStart.onClick.AddListener(()=>{
            SceneManager.LoadScene("GameScene");
        });
        btnClose.onClick.AddListener(()=>{
            Hide();
            BeginPanel.Instance.Show();
        });
        Hide();
    }
    float time=0;
    public bool isSel;
    private void Update() {
        time+=Time.deltaTime;
        heroPos.Translate(Vector3.up*Mathf.Sin(time)*0.01f,Space.World);

        if(Input.GetMouseButtonDown(0)){
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),1000,1<<LayerMask.NameToLayer("UI"))){
                isSel=true;
            }
        }
        if(Input.GetMouseButtonUp(0)) isSel=false;
        if(Input.GetMouseButton(0) && isSel==true){
            heroPos.rotation*=Quaternion.AngleAxis(Input.GetAxis("Mouse X")*-15,Vector3.up);
        }
    }
    public override void Show()
    {
        base.Show();
        mGameData.Instance.nowHeroIndex=0;
        ChangeHero();
    }
    public override void Hide()
    {
        base.Hide();
        DestroyObj();
    }
    public void ChangeHero(){
        RoleInfo roleInfo=mGameData.Instance.GetNowHeroInfo();
        DestroyObj();
        airplaneObj=Instantiate(Resources.Load<GameObject>(roleInfo.resName));
        airplaneObj.transform.SetParent(heroPos,false);
        airplaneObj.transform.localPosition=Vector3.zero;
        airplaneObj.transform.localRotation=Quaternion.identity;
        airplaneObj.transform.localScale=Vector3.one*roleInfo.scale;
        airplaneObj.layer=LayerMask.NameToLayer("UI");
        for(int i=0;i<10;i++){
            hpList[i].SetActive(i<roleInfo.hp);
            speedList[i].SetActive(i<roleInfo.speed);
            volumeList[i].SetActive(i<roleInfo.volume);
        }
    }
    void DestroyObj(){
        if(airplaneObj!=null){
            Destroy(airplaneObj);
            airplaneObj=null;
        }

    }
}
