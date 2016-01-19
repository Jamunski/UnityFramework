/*********************************************HEADER*********************************************\
 * Created By: Jordan Vassilev
 * Last Updated on: 13/12/15
 * Function: 
\*********************************************HEADER*********************************************/
/*********************************************NOTES**********************************************\
 * 
\*********************************************NOTES**********************************************/
using UnityEngine;
using System.Collections;

//Attributes are modifiers for values which will be used in calculations such as damage given and taken, etc...
//Attributes are modifiable and visible to the player...
public struct PlayerAttributes
{
	public int Strength; // Blunt damage modifier, Effects Load
	public int Dexterity; // Sharp damage modifier, Effects something
	public int Intelligence; // Modifier for Magic effectiveness
	public int Physique; // Stamina drain modifier, Effects Burden
	public int Constitution; // Modifier for Health pool
	public int Spirit; // Modifier for Mana pool
	public int Endurance; // Modifier for Stamina pool
}

//I unno yet...
public struct PlayerStats
{
	public int Speed;
	public int HealthTotal;
	public int ManaTotal;
	public int StaminaTotal;
	public float LoadTotal; //Max Carry Weight
	public float BurdenTotal; //Max Equip Weight
}

//Player visible pools which values can fluctuate and need to be calculated... Calculated based on the Player Attributes...
public struct PlayerPools
{
	public float m_Health;
	public float m_Mana;
	public float m_Stamina;
	public float m_Load;
	public float m_Burden;
}

public class PlayerStatistics : MonoBehaviour
{
	//TEMPORARY ATTRIBUTE ACCESSORS!!!                     ///////// PLEASE DELETE ME!!
	public int StrengthAccessor;
	public int DexterityAccessor;
	public int SpiritAccessor;
	public int PhysiqueAccessor;
	public int ConstitutionAccessor;
	public int InteligenceAccessor;
	public int EnduranceAccessor;

	//REFERENCES
	private HUD m_HUD;

	//POOL STARTS
	private const float HEALTH_START = 120.5f;
	private const float MANA_START = 41.3f;
	private const float STAMINA_START = 73.7f;
	private const float LOAD_START = 40.7f;
	private const float BURDEN_START = 21.3f;

	//MODIFICATION CONSTANTS
	private const float SPRINT_MODIFIER = 1.5f;

	private const float HEALTH_MODIFIER = 24.25f; // Values will need balancing...
	private const float MANA_MODIFIER = 14.5f;
	private const float STAMINA_MODIFIER = 17.4f;
	private const float LOAD_MODIFIER = 5.2f;
	private const float BURDEN_MODIFIER = 2.7f;

	//NON CONSTANT MODIFIERS
	private float SpeedModifier; // Based off the Load and Burden effects...

	//MAIN ATTRIBUTES
	public PlayerAttributes Attributes = new PlayerAttributes();
	//POOLS
	public PlayerPools Pools = new PlayerPools();
	//STATISTICS
	public PlayerStats Stats = new PlayerStats();

	//Don't know really
	public bool m_IsSprinting;
	private float m_SprintSpeed;
	public float m_FinalSpeed { get; private set; }

	//Unity Callbacks
	void Start()
	{
		InitializeAttributes();
		InitializeStats();
		InitializePools();
		m_HUD = GameObject.FindObjectOfType<HUD>();
		if (m_HUD != null)
		{
			m_HUD.UpdateBars();
			m_HUD.UpdatePools();
		}
	}

	void Update()
	{
		//Temp//////
		InitializeAttributes();
		InitializeStats();
		if (m_HUD != null)
		{
			m_HUD.UpdateBars();
		}
		///////////
	}

	//private Methods
	private void InitializeAttributes()
	{
		Attributes.Strength = StrengthAccessor;
		Attributes.Dexterity = DexterityAccessor;
		Attributes.Intelligence = SpiritAccessor;
		Attributes.Physique = PhysiqueAccessor;
		Attributes.Constitution = ConstitutionAccessor;
		Attributes.Spirit = InteligenceAccessor;
		Attributes.Endurance = EnduranceAccessor;
	}

	private void InitializeStats()
	{
		Stats.Speed = 15;
		Stats.HealthTotal = (int)(Mathf.Floor(Attributes.Constitution * HEALTH_MODIFIER) + HEALTH_START);
		Stats.ManaTotal = (int)(Mathf.Floor(Attributes.Spirit * MANA_MODIFIER) + MANA_START);
		Stats.StaminaTotal = (int)(Mathf.Floor(Attributes.Endurance * STAMINA_MODIFIER) + STAMINA_START);
		Stats.LoadTotal = (int)Mathf.Floor(Attributes.Strength * LOAD_MODIFIER + LOAD_START);
		Stats.BurdenTotal = (int)Mathf.Floor(Attributes.Physique * BURDEN_MODIFIER + BURDEN_START);
	}

	private void InitializePools()
	{
		Pools.m_Health = Stats.HealthTotal;
		Pools.m_Stamina = Stats.StaminaTotal;
		Pools.m_Mana = Stats.ManaTotal;
		Pools.m_Load = Stats.LoadTotal;
		Pools.m_Burden = Stats.BurdenTotal;
	}

	//public Methods
	//Statistic Calculation Functions
	public void CalculateLoad()
	{
		// Get collective weight of all inventory items and hinder player movement slightly based off these values...
		// Speed * 1.0 - 0.95 hinderence (50% load or under), Speed * 0.95 - 0.9 (50% - 80%), Speed * 0.9 - 0.8(80% - 100%)
		//REQUIRES INVENTORY SYSTEM!!! :O
	}

	public void CalculateBurden()
	{
		// Get collective weight of all equiped items and modify other stats... Speed, StaminaRegeneration, ManaRegeneration(if this will be a thing)...
		// Speed * 1.0 - 0.9 burden (50% load or under), Speed * 0.9 - 0.8 (50% - 80%), Speed * 0.8 - 0.6(80% - 100%)
		//REQUIRES EQUIPMENT SYSTEM!!! :O
	}

	public void CalculateSpeed()
	{
		//NOT SURE YET... Needs more work...
		m_SprintSpeed = Stats.Speed * SPRINT_MODIFIER;
		m_FinalSpeed = Stats.Speed;
		if (m_IsSprinting)
		{
			m_FinalSpeed = m_SprintSpeed;
		}
	}

	public void CalculateMana() //Called when mana is to be consumed, regeneration should be considered before implementing this class...
	{
		//Not sure how this will work yet, likely need spells to be implemented before this...
	}

	public void CalculateStamina()// pass the action delt and handle the stamina calculation using that value
	{
		//Not sure how this will work yet...
		//REQUIRES BURDEN IN ORDER TO BE FULLY IMPLEMENTED!!! :O
	}

	public void CalculateDamage(GameObject aDamager, float aDamageDealt, DamageType aDamageType = DamageType.normal) //GameObject dealing damage, Damage, DamageType
	{
		try
		{
			switch (aDamageType)
			{
				case DamageType.normal:
					if (Pools.m_Health > 0)
					{
						Pools.m_Health -= aDamageDealt;
					}
					else
					{
						Pools.m_Health = 0;
						m_HUD.DisplayGameOver();
					}
					break;
				case DamageType.other:
					if (Pools.m_Health > 0)
					{
						Pools.m_Health -= aDamageDealt;
					}
					else
					{
						Pools.m_Health = 0;
						m_HUD.DisplayGameOver();
					}
					break;
			}
			m_HUD.UpdatePools();
		}
		catch
		{
			Debug.Log("HUD is NULL");
		}
	}
}
