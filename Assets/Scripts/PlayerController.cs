
using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Header("设置角色装备栏背包")]
    public EquidBags playerEquid;

    [Header("设置Spine动画控件")]
    public SkeletonAnimation player;


    [Header("查看攻击状态")]
    public bool isAttacking = false;
    public bool canAttack = true;
    public bool isAttackMoving = false;
    public bool canMove = true;
    public bool isDefence = false;
    public bool isElude = false;

    Skeleton skeleton;
    SkeletonData skeletonData;



    string cloth, rWeaponSet, lWeaponSet, rWeaponBack1, lWeaponBack1;

    // Start is called before the first frame update
    void Start()
    {

        SetSkin();
        //skeleton = player.Skeleton;
        //skeletonData = skeleton.Data;
        //Skin playerMixSkin = new Skin("normal");
        //playerMixSkin.AddSkin(skeletonData.FindSkin("clothes/Normal"));
        //playerMixSkin.AddSkin(skeletonData.FindSkin("Rweapon-set/sword"));
        //skeleton.SetSkin(playerMixSkin);
        //skeleton.SetSlotsToSetupPose();

    }


    // Update is called once per frame
    void Update()
    {
        AttackState();

    }

    private void FixedUpdate()
    {
    }

    public void SetSkin()
    {
        skeleton = player.Skeleton;
        skeletonData = skeleton.Data;
        Skin playerMixSkin = new Skin("normal");
        if (playerEquid.Cloth != null)
        {
            cloth = "clothes/" + playerEquid.Cloth.itemSkinID;
            playerMixSkin.AddSkin(skeletonData.FindSkin(cloth));
        }

        if (playerEquid.Main_Weapon1 != null)
        {
            rWeaponSet = "Rweapon-set/" + playerEquid.Main_Weapon1.itemSkinID;
            playerMixSkin.AddSkin(skeletonData.FindSkin(rWeaponSet));
        }

        if (playerEquid.Main_Weapon2 != null)
        {
            rWeaponBack1 = "Rweapon-back1/" + playerEquid.Main_Weapon2.itemSkinID;
            playerMixSkin.AddSkin(skeletonData.FindSkin(rWeaponBack1));
        }

        if (playerEquid.Sub_Weapon1 != null)
        {
            lWeaponSet = "Lweapon-set/" + playerEquid.Sub_Weapon1.itemSkinID;
            playerMixSkin.AddSkin(skeletonData.FindSkin(lWeaponSet));
        }

        if (playerEquid.Sub_Weapon2 != null)
        {
            lWeaponBack1 = "Lweapon-back1/" + playerEquid.Sub_Weapon2.itemSkinID;
            playerMixSkin.AddSkin(skeletonData.FindSkin(lWeaponBack1));
        }

        skeleton.SetSkin(playerMixSkin);
        skeleton.SetSlotsToSetupPose();
    }

    void AttackState()
    {
        player.state.Event += AttackEvent;
    }

    private void AttackEvent(TrackEntry trackEntry, Spine.Event e)
    {
        /*
        if (e.Data.Name == "AttackState")
        {
            if (e.Int == 1)
            {
                isAttacking = true;
                canAttack = false;
            }
            if (e.Int == 2)
            {
                isAttacking = true;
                canAttack = true;
            }
            if (e.Int == 0)
            {
                isAttacking = false;
                canAttack = true;
            }
        }

        if (e.Data.Name == "AttackMoveState")
        {
            if (e.Int == 1)
            {
                isAttackMoving = true;
            }
            if (e.Int == 0)
            {
                isAttackMoving = false;
            }
        }
        if (e.Data.Name == "CanMove")
        {
            if (e.Int == 1)
            {
                canMove = false;
            }
            if (e.Int == 0)
            {
                canMove = true;
            }
        }
        */

        switch (e.Data.Name)
        {
            case "AttackState":

                if (e.Int == 1)
                {
                    isAttacking = true;
                    canAttack = false;
                }
                if (e.Int == 2)
                {
                    isAttacking = true;
                    canAttack = true;
                }
                if (e.Int == 0)
                {
                    isAttacking = false;
                    canAttack = true;
                }
                break;

            case "AttackMoveState":

                if (e.Int == 0)
                {
                    isAttackMoving = true;
                }
                if (e.Int == 1)
                {
                    isAttackMoving = false;
                }
                break;

            case "CanMove":
                if (e.Int == 1)
                {
                    canMove = false;
                }
                if (e.Int == 0)
                {
                    canMove = true;
                }
                break;

            case "IsElude":
                if (e.Int == 1)
                {
                    isElude = false;
                }
                break;

            default:
                break;
        }
    }


}
