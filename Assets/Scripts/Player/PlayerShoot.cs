using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    //���̃X�N���v�g�̖���
    //�v���C���[�̎ˌ��L�[�̓��͌��m�A�ˌ��Ԋu�ݒ�

    [SerializeField]
    private float shootTimer, shootTimeDelay = 0.2f;

    [SerializeField]
    private Transform magicSpawnPos;
    private PlayerMagicSquareManager playerMagicSquareManager;

    public Health health;
    public int magicPoint;

    private void Awake()
    {
        playerMagicSquareManager = GetComponent<PlayerMagicSquareManager>();
    }

    

    void Shooting()
    {
        if(Input.GetMouseButtonDown(0) && magicPoint > 0)
        {
            if (Time.time > shootTimer)
            {
                shootTimer = Time.time + shootTimeDelay;

                playerMagicSquareManager.Shoot(magicSpawnPos.position);

                magicPoint -= 1;

                health.magicPoint = magicPoint;
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        magicPoint = health.magicPoint;
        Debug.Log(health.magicPoint);
    }

    // Update is called once per frame
     private void Update()
    {
        magicPoint = health.magicPoint;
        Shooting();
        
    }
}