using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private GameObject hitMarket;
    [SerializeField] private GameObject weapon;
    [SerializeField] private AudioSource shootSound;
    private CharacterController characterController;

    [SerializeField] private int maxAmmuntion = 50;
    private int currentAmmunition;
    private bool isReloading = false;

    private UIManager uiManager;

    public bool hasCoin = false;
    // Start is called before the first frame update
    void Start()
    {
        this.currentAmmunition = maxAmmuntion;
        this.uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        this.characterController = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        this.ManageUIBulletManager(this.currentAmmunition);
    }

    // Update is called once per frame
    void Update()
    {
        this.MovementKeyboard();
        this.ShootRayCasting();
        this.RechargeAmmonition();
        this.EscapeKey();
    }

    private void MovementKeyboard()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        float y = 0;
        Vector3 move = new Vector3(x, y, z);
        move.y -= this.gravity;
        move = this.transform.transform.TransformDirection(move);
        this.characterController.Move(move * Time.deltaTime * this.speed);
    }

    private void EscapeKey ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void RechargeAmmonition()
    {
        if (Input.GetKeyDown(KeyCode.R) && !this.isReloading)
        {
            StartCoroutine(this.RechargeAmmonitionRoutine(1.5f));
        }
    }

    private IEnumerator RechargeAmmonitionRoutine(float time)
    {
        this.isReloading = true;
        yield return new WaitForSeconds(time);
        this.currentAmmunition = this.maxAmmuntion;
        this.ManageUIBulletManager(this.currentAmmunition);
        this.isReloading = false;
    }

    private void ShootRayCasting()
    {
        if (Input.GetMouseButton(0) && this.currentAmmunition > 0)
        {
            currentAmmunition--;
            this.ManageUIBulletManager(this.currentAmmunition);
            if (!this.shootSound.isPlaying)
            {
                this.shootSound.Play();
                this.shootSound.priority = 1;
            }
            this.muzzleFlash.SetActive(true);
            Ray origin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit raycastHit;
            if (Physics.Raycast(origin, out raycastHit))
            {
                Debug.Log("Raycast hit something: " + raycastHit.transform.name);
                Instantiate(this.hitMarket, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));

                WoodenCrateDestructable crate = raycastHit.transform.GetComponent<WoodenCrateDestructable>();
                if(crate)
                {
                    crate.UpdateCrate();
                }
            }
        } else
        {
            this.shootSound.Stop();
            this.muzzleFlash.SetActive(false);
        }
    }

    private void ManageUIBulletManager(int bullets)
    {
        if(this.uiManager)
        {
            this.uiManager.UpdateAmmonition(bullets);
        }
    }

    public void CollectCoin()
    {
        this.hasCoin = true;
        this.uiManager.CollectedCoin();
    }

    public void RemoveCoin()
    {
        this.hasCoin = false;
        this.uiManager.RemoveCoin();
    }

    public void EnableWeapon()
    {
        this.weapon.SetActive(true);
    }
}
