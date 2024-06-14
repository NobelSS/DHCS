using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public bool isMoving = false;
    public float sprintSpeed = 9f;
    public float moveSpeed = 4.5f;
    public float currentSpeed;
  

    [Header ("Sprint")]
    public bool isSprinting = false;
    public float currentStamina = 100f;
    public float maxStamina = 100f;
    public float staminaDrainRate = 66f;
    public float staminaRegenRate = 30f;
    public bool isStaminaDepleted;

    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("ello from playermeovstaet");
        player.staminaBar.SetMaxStamina(maxStamina);
        AudioManager.Instance.PlayLoop("walk");
        
    }

    public override void ExitState(PlayerStateManager player)
    {
        AudioManager.Instance.loopSource.Stop();
        Debug.Log(currentSpeed);
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //player.staminaBar.SetStamina(currentStamina);
        
        float moveInput = Input.GetAxis("Horizontal");

        float absSpeed = Mathf.Abs(moveInput);
        player.animator.SetFloat("Speed", absSpeed);
        
        
        if (moveInput != 0)
        {
            

            if (moveInput > 0)
            {
                player.rb.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            else if (moveInput < 0)
            {
                player.rb.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            

            if(Input.GetButton("Fire3") && currentStamina > 0f && !isStaminaDepleted)
            {
                isSprinting = true;
                currentStamina -= staminaDrainRate * Time.deltaTime;
                
                currentSpeed = sprintSpeed;
                Debug.Log("Pressed");
            }else 
            {
                isSprinting = false;
                Regen();
                
                currentSpeed = moveSpeed;
            }
                
            
           
            player.rb.velocity = new Vector2(moveInput * currentSpeed, player.rb.velocity.y);

            player.animator.SetFloat("Speed", absSpeed*currentSpeed);

            if (Input.GetButton("Jump") && !isStaminaDepleted)
            {
                player.changeState(player.jumpState);
                player.animator.SetFloat("Speed", 0);
            }
        }
        else
        { 
            player.changeState(player.idleState);    
        }

        checkStamina();
      
    }

    public void Regen()
    {
        if(currentStamina <= maxStamina && !isSprinting)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            if (currentStamina >= maxStamina)
            {
                currentStamina = maxStamina;
                isStaminaDepleted = false;
            }
        }
    }

    public void checkStamina()
    {
        if(currentStamina <= 0)
        {
            isStaminaDepleted = true;
            currentStamina = 0;
        }else if (currentStamina >= maxStamina)
        {
            isStaminaDepleted = false;
        }
    }
}