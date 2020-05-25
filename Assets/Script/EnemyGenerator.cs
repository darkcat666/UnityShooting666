using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject boss1;
    private Camera _mainCamera;
    private int leftTop;
    private int rightTop;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateEnemy", 0.5f, 1);
        // カメラオブジェクトを取得します
        GameObject obj = GameObject.Find("Main Camera");
        _mainCamera = obj.GetComponent<Camera>();
        // 画面の左上を取得
        Vector3 topLeft = _mainCamera.ScreenToWorldPoint(Vector3.zero);
        leftTop = Mathf.FloorToInt(topLeft.x);
        // 画面の右下を取得
        // 画面の右下を取得
        Vector3 bottomRight = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0.0f));
        rightTop = Mathf.FloorToInt(bottomRight.x);
    }

    void GenerateEnemy()
    {
        Instantiate(boss1, new Vector3(leftTop + (rightTop - leftTop) * Random.value, 7, 0), Quaternion.identity);
    }
}
