using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;
    public float cmass = -0.9f;
    public Rigidbody rb;
    public float rspeed;

    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform rearLeftWheelTransform;
    public Transform rearRightWheelTransform;

    public Text infoText;

    public float maxSteeringAngle = 30f;
    public float motorForce = 300f;
    public float brakeForce = 20f;
    public float max_speed = 100f;

    //Windzone
    public bool inWindZone = false;
    public GameObject windZone;


    //POWERUPS
    string[] powerups = {"fast", "slow", "bigger", "smaller", "maxHealth", "stealth"};
    public bool powerup = false;
    public bool slow = false;
    private float timestar = 5;
    public bool bigger = false;
    public bool smaller = false;
    
    Vector3 original_size;
    BoxCollider car_collider;
    
    private float car_mass;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public bool gethit = false;
    public Transform respawnpoint;
    public bool stealth = false;
    
    Material m_Material;
    
    private AudioSource audios;
    public AudioClip music_drive;
    public AudioClip music_powerup;
    public AudioClip music_powerdown;
    public AudioClip music_big;
    public AudioClip music_small;
    
    void Awake()
    {
        audios = GetComponent<AudioSource>();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb.centerOfMass = new Vector3(0f, cmass, 0f);        
        car_mass = rb.mass;
        car_collider = GetComponent<BoxCollider>();
        original_size = car_collider.size;        
        m_Material = GetComponent<Renderer>().material;
    }
    
    private void FixedUpdate()
    {
        
        //Respawm if car fall from edge
        if(transform.position.y < -50){
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
            transform.position = respawnpoint.transform.position;
            Physics.SyncTransforms();
        }

        Hit();
        Check_Death();

        // car in wind area
        if(inWindZone){
            rb.AddForce(windZone.GetComponent<windArea>().windDirection * windZone.GetComponent<windArea>().windStrength, ForceMode.VelocityChange);
        }


        if(currentHealth > 0)
        {
            Stealth_Mode();
            Become_Faster();
            Become_slower();
            Big_mode();
            Small_mode();
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheels();
        }


    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            if (rb.velocity.x >= 0 && rb.velocity.magnitude >= max_speed)
            {
            }
            else
            {
                verticalInput = 1;
                audios.clip = music_drive;
                audios.PlayOneShot(audios.clip, 1);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalInput = -1;

        }
        else
        {
            if(rb.velocity.magnitude > 0.5)
            {
                verticalInput = -verticalInput * 0.5f;
            }
            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalInput = 1;
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalInput = -1;
        }
        else
        {
            horizontalInput = 0;
        }

        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleSteering()
    {
        steerAngle = maxSteeringAngle * horizontalInput/10;
        frontLeftWheelCollider.steerAngle = steerAngle;
        frontRightWheelCollider.steerAngle = steerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;

        brakeForce = isBreaking ? 3000f : 0f;
        frontLeftWheelCollider.brakeTorque = brakeForce;
        frontRightWheelCollider.brakeTorque = brakeForce;
        rearLeftWheelCollider.brakeTorque = brakeForce;
        rearRightWheelCollider.brakeTorque = brakeForce;
    }

    private void UpdateWheels()
    {
        UpdateWheelPos(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateWheelPos(frontRightWheelCollider, frontRightWheelTransform);
        UpdateWheelPos(rearLeftWheelCollider, rearLeftWheelTransform);
        UpdateWheelPos(rearRightWheelCollider, rearRightWheelTransform);
    }

    private void UpdateWheelPos(WheelCollider wheelCollider, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        trans.rotation = rot;
        trans.position = pos;
        rspeed = rb.velocity.magnitude;
    }



    //POWERUPS
    public void Become_Faster()
    {
        if (powerup == true)
        {
            audios.clip = music_powerup;
            audios.PlayOneShot(audios.clip, 1);
            if (timestar > 0)
            {
                motorForce = 100f;
                timestar -= Time.deltaTime;
            }
            else
            {
                powerup = false;
                timestar = 20;
                motorForce = 50f;
                infoText.text = "";
            }
        }
    }

    public void Become_slower()
    {
        if (slow == true)
        {
            audios.clip = music_powerdown;
            audios.PlayOneShot(audios.clip, 1);
            if (timestar > 0)
            {
                motorForce = 25f;
                timestar -= Time.deltaTime;
            }
            else
            {
                powerup = false;
                timestar = 20;
                motorForce = 50f;
                infoText.text = "";
            }
        }
    }

    public void Big_mode()
    {
        if (bigger == true)
        {
            audios.clip = music_big;
            audios.PlayOneShot(audios.clip, 1);
            if (timestar > 0)
            {
                
                transform.localScale = new Vector3(2, 2, 2);
                car_collider.size = new Vector3(original_size.x * 2, original_size.y, original_size.z * 2);
                rb.mass = car_mass * 1.5f;
                timestar -= Time.deltaTime;
            }
            else
            {
                bigger = false;
                timestar = 20;
                transform.localScale = new Vector3(1, 1, 1);
                car_collider.size = original_size;
                rb.mass = car_mass;
                infoText.text = "";
            }
        }
    }

    public void Small_mode()
    {
        if (smaller == true)
        {
            audios.clip = music_small;
            audios.PlayOneShot(audios.clip, 1);
            if (timestar > 0)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                car_collider.size =  new Vector3(original_size.x/2, original_size.y, original_size.z / 2);
                rb.mass = car_mass / 1.5f;
                timestar -= Time.deltaTime;
            }
            else
            {
                smaller = false;
                timestar = 20;
                transform.localScale = new Vector3(1, 1, 1);
                car_collider.size = original_size;
                rb.mass = car_mass;
                infoText.text = "";
            }
        }
    }




    public void Hit()
    {
        if (gethit == true)
        {
            TakeDamage(20);
            if(currentHealth <= 0)
            {
                new WaitForSeconds(2);
                currentHealth = maxHealth;
                transform.position = respawnpoint.transform.position;
                healthBar.SetHealth(currentHealth);
                gethit = false;
            }
        }

        void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            gethit = false;
        }
    }

    public void Check_Death()
    {
        if (currentHealth == 0)
        {
            System.Threading.Thread.Sleep(1000);
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
            transform.position = respawnpoint.transform.position;
            Physics.SyncTransforms();
        }
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);

    }

    public void Stealth_Mode()
    {
        if (stealth == true)
        {
            if (timestar > 0)
            {
                ChangeAlpha(m_Material, 0.0f);
                timestar -= Time.deltaTime;
                car_collider.enabled = false;

            }
            else
            {
                stealth = false;
                ChangeAlpha(m_Material, 1f);
                car_collider.enabled = true;
                timestar = 5;
                infoText.text = "";
            }
        }
    }
    





    //COLLIDERS
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        {
            GameObject child = other.transform.GetChild(0).gameObject;
            respawnpoint.transform.position = child.transform.position;
        }


        if(other.CompareTag("mysterybox"))
        {
            //powerups = {"fast", "slow", "bigger", "smaller", "maxHealth", "stealth"};
            int randomPowerUp = UnityEngine.Random.Range(0,5);
            string randomPowerup = powerups[randomPowerUp];


            switch (randomPowerup){
                case "fast":
                    powerup = true;
                    infoText.text = "Powerup: " + randomPowerup;
                    break;

                case "slow":
                    slow = true;
                    infoText.text = "Powerup: " + randomPowerup;
                    break;

                case "bigger":
                    bigger = true;
                    infoText.text = "Powerup: " + randomPowerup;
                    break;

                case "smaller":
                    smaller = true;
                    infoText.text = "Powerup: " + randomPowerup;
                    break;

                case "maxHealth":
                    currentHealth = maxHealth;
                    healthBar.SetHealth(currentHealth);
                    break;

                case "stealth":
                    stealth = true;
                    infoText.text = "Powerup: " + randomPowerup;
                    break;

                default:
                    break;
            }

        }

        if(other.CompareTag("windArea"))
        {
            Debug.Log("Entered windy area");
            infoText.text = "Windy area";
            windZone = other.gameObject;
            inWindZone = true;
        }        

    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("windArea"))
        {
            Debug.Log("Exiting windy area");
            infoText.text = "";
            windZone = other.gameObject;
            inWindZone = false;
        }  
    }

}
