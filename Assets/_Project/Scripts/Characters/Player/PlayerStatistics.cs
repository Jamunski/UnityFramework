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
public struct General
{
	public string Name;
	public string Gender;
	public string Class;
	public int Wisdom;
}

public struct Attributes
{
	public int Constitution; // Modifier for Health pool
	public int Spirit; // Modifier for Mana pool
	public int Endurance; // Modifier for Stamina pool
	public int Physique; // Stamina drain modifier, Effects Burden
	public int Strength; // Blunt damage modifier, Effects Load
	public int Dexterity; // Sharp damage modifier, Effects something
	public int Intelligence; // Modifier for Magic effectiveness
	public int Faith;
	public int Memory;
	public int Willpower;
}

//I unno yet...
public struct Derived
{
	public int Speed;
	public float LoadTotal; //Max Carry Weight
	public float BurdenTotal; //Max Equip Weight
	public int HealthTotal;
	public int ManaTotal;
	public int StaminaTotal;
	public int Sanity;

	//Physical
	public int BluntResistance;
	public int SharpResistance;
	public int ThrustResistance;
	//Elemental
	public int FireResistance;
	public int FrostResistance;
	public int LightningResistance;
	public int WindResistance;
	//Fabricated
	public int CorruptionResistance;
	public int DivineResistance;
	public int ArcaneResistance;

	//Physical
	public int BluntOffense;
	public int SharpOffense;
	public int ThrustOffense;
	//Elemental
	public int FireOffense;
	public int FrostOffense;
	public int LightningOffense;
	public int WindOffense;
	//Fabricated
	public int CorruptionOffense;
	public int DivineOffense;
	public int ArcaneOffense;
}

//Player visible pools which values can fluctuate and need to be calculated... Calculated based on the Player Attributes...
public struct PlayerPools
{
	public float Health;
	public float Mana;
	public float Stamina;
	public float Load;
	public float Burden;
}

public class PlayerStatistics : MonoBehaviour
{
	//TEMPORARY ATTRIBUTE ACCESSORS!!!                     ///////// PLEASE DELETE ME!!
	public int m_ConstitutionAccessor;
	public int m_SpiritAccessor;
	public int m_EnduranceAccessor;
	public int m_PhysiqueAccessor;
	public int m_StrengthAccessor;
	public int m_DexterityAccessor;
	public int m_InteligenceAccessor;
	public int m_FaithAccessor;
	public int m_MemoryAccessor;
	public int m_WillpowerAccessor;

	//REFERENCES
	private Player m_Player;

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
	private float m_SpeedModifier; // Based off the Load and Burden effects...

	//MAIN ATTRIBUTES
	public Attributes m_Attributes = new Attributes();
	//POOLS
	public PlayerPools m_Pools = new PlayerPools();
	//STATISTICS
	public Derived m_Stats = new Derived();

	//Don't know really
	public bool m_IsSprinting;
	private float m_SprintSpeed;
	public float m_FinalSpeed { get; private set; }

	//Unity Callbacks
	void Start()
	{
		m_Player = gameObject.GetComponent<Player>();
		InitializeAttributes();
		InitializeStats();
		InitializePools();
		if (m_Player.m_HUD != null)
		{
			m_Player.m_HUD.UpdateBars();
			m_Player.m_HUD.UpdatePools();
		}
	}

	void Update()
	{
		//Temp//////
		InitializeAttributes();
		InitializeStats();
		if (m_Player.m_HUD != null)
		{
			m_Player.m_HUD.UpdateBars();
		}
		///////////
	}

	//private Methods
	private void InitializeAttributes()
	{
		m_Attributes.Constitution = m_ConstitutionAccessor;
		m_Attributes.Spirit = m_InteligenceAccessor;
		m_Attributes.Endurance = m_EnduranceAccessor;
		m_Attributes.Physique = m_PhysiqueAccessor;
		m_Attributes.Strength = m_StrengthAccessor;
		m_Attributes.Dexterity = m_DexterityAccessor;
		m_Attributes.Intelligence = m_SpiritAccessor;
		m_Attributes.Faith = m_FaithAccessor;
		m_Attributes.Memory = m_MemoryAccessor;
		m_Attributes.Willpower = m_WillpowerAccessor;
	}

	private void InitializeStats()
	{
		m_Stats.Speed = 15;
		m_Stats.HealthTotal = (int)(Mathf.Floor(m_Attributes.Constitution * HEALTH_MODIFIER) + HEALTH_START);
		m_Stats.ManaTotal = (int)(Mathf.Floor(m_Attributes.Spirit * MANA_MODIFIER) + MANA_START);
		m_Stats.StaminaTotal = (int)(Mathf.Floor(m_Attributes.Endurance * STAMINA_MODIFIER) + STAMINA_START);
		m_Stats.LoadTotal = (int)Mathf.Floor(m_Attributes.Strength * LOAD_MODIFIER + LOAD_START);
		m_Stats.BurdenTotal = (int)Mathf.Floor(m_Attributes.Physique * BURDEN_MODIFIER + BURDEN_START);
	}

	private void InitializePools()
	{
		m_Pools.Health = m_Stats.HealthTotal;
		m_Pools.Stamina = m_Stats.StaminaTotal;
		m_Pools.Mana = m_Stats.ManaTotal;
		m_Pools.Load = m_Stats.LoadTotal;
		m_Pools.Burden = m_Stats.BurdenTotal;
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
		m_SprintSpeed = m_Stats.Speed * SPRINT_MODIFIER;
		m_FinalSpeed = m_Stats.Speed;
		if (m_IsSprinting)
		{
			m_FinalSpeed = m_SprintSpeed;
		}
	}

	//Called when mana is to be consumed, regeneration should be considered before implementing this class...
	public void CalculateMana() 
	{
		//Not sure how this will work yet, likely need spells to be implemented before this...
	}

	// pass the action delt and handle the stamina calculation using that value. 
	// Action passed willl be an action object which inherits from an action interface, 
	// the interface will contain values such as stamina consumption, this way each action won't need a special case.
	public void CalculateStamina()
	{
		//Not sure how this will work yet...
		//REQUIRES BURDEN IN ORDER TO BE FULLY IMPLEMENTED!!! :O
	}

	//Should be changed to calculate life, this function would then be used for all cases in which health pools are changed
	public void CalculateDamage(GameObject aDamager, float aDamageDealt, DamageType aDamageType = DamageType.normal) //GameObject dealing damage, Damage, DamageType
	{
		try
		{
			switch (aDamageType)
			{
				case DamageType.normal:
					if (m_Pools.Health > 0)
					{
						m_Pools.Health -= aDamageDealt;
					}
					else
					{
						m_Pools.Health = 0;
						m_Player.m_HUD.DisplayGameOver();
					}
					break;
				case DamageType.other:
					if (m_Pools.Health > 0)
					{
						m_Pools.Health -= aDamageDealt;
					}
					else
					{
						m_Pools.Health = 0;
						m_Player.m_HUD.DisplayGameOver();
					}
					break;
			}
			m_Player.m_HUD.UpdatePools();
		}
		catch
		{
			Debug.Log("HUD is NULL");
		}
	}
}