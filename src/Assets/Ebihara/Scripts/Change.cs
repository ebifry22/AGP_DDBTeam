using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Change : MonoBehaviour
{
    //GameObject changeObj;

    PlayerMove PlayerMove;
    CharacterStatus characterStatus;


    [SerializeField] GameObject camera;
    PlayerRay playerRay;

    // Start is called before the first frame update
    void Start()
    {
        playerRay = camera.GetComponent<PlayerRay>();
        PlayerMove = this.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeEnemy(GameObject changeObj)
    {
        //仮
        //changeObj = playerRay.GetObj();
        characterStatus = changeObj.GetComponent<CharacterStatus>();

        //乗り移り処理
        if (characterStatus.IsDead == true)
        {
            Debug.Log("乗り移る敵:" + changeObj.name);

            Debug.Log("Change");

            //親をEnemyに
            transform.parent.gameObject.tag = "Enemy";

            //親の付け替え
            this.gameObject.transform.parent = changeObj.transform;
            PlayerMove.SetplayerParent(this.transform.parent.gameObject);

            //親をPlayerに
            this.transform.parent.gameObject.tag = "Player";

            //Playerの位置調整
            this.transform.position = changeObj.transform.position;
            Vector3 correction = new Vector3(0f, 1.5f, 0f);
            this.transform.position += correction;

            changeObj = null;
        }
    }
}
