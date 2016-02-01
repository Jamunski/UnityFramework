using UnityEngine;
using System.Collections;

public class DataPerLife // Data per life
{
	#region // Data
	public float m_TimeSinceLifeStart = 0.0f;

	#region // Sym Damage Taken
	public int m_SymDamageTakenByBlasterface = 0;
	public int m_SymDamageTakenByLaserface = 0;
	public int m_SymDamageTakenByLeech = 0;
	public int m_SymDamageTakenByMacrophage = 0;
	public int m_SymDamageTakenByMinelayer = 0;
	public int m_SymDamageTakenByMonocyte = 0;
	public int m_SymDamageTakenByMortar = 0;
	public int m_SymDamageTakenByNeutrophil = 0;

	public int m_SymDamageTaken = 0;
	public int m_SymDamageAbsorbed = 0;
	public int m_SymLifeRestored = 0;
	#endregion

	#region // Bios Damage Taken
	public int m_BiosDamageTakenByBlasterface = 0;
	public int m_BiosDamageTakenByLaserface = 0;
	public int m_BiosDamageTakenByLeech = 0;
	public int m_BiosDamageTakenByMacrophage = 0;
	public int m_BiosDamageTakenByMinelayer = 0;
	public int m_BiosDamageTakenByMonocyte = 0;
	public int m_BiosDamageTakenByMortar = 0;
	public int m_BiosDamageTakenByNeutrophil = 0;

	public int m_BiosDamageTaken = 0;
	public int m_BiosDamageAbsorbed = 0;
	public int m_BiosLifeRestored = 0;
	#endregion

	#region // Sym Damage Dealt
	public int m_SymDamageDealtToBlasterface = 0;
	public int m_SymDamageDealtToLaserface = 0;
	public int m_SymDamageDealtToLeech = 0;
	public int m_SymDamageDealtToMacrophage = 0;
	public int m_SymDamageDealtToMinelayer = 0;
	public int m_SymDamageDealtToMonocyte = 0;
	public int m_SymDamageDealtToMortar = 0;
	public int m_SymDamageDealtToNeutrophil = 0;

	public int m_SymDamageDealtToDys = 0;
	public int m_SymDamageDealtToFunctional = 0;
	public int m_SymDamageDealtToParcell = 0;
	public int m_SymDamageDealtToBrainstorm = 0;

	public int m_SymDamageDealt = 0;
	#endregion

	#region // Bios Damage Dealt
	public int m_BiosDamageDealtToBlasterface = 0;
	public int m_BiosDamageDealtToLaserface = 0;
	public int m_BiosDamageDealtToLeech = 0;
	public int m_BiosDamageDealtToMacrophage = 0;
	public int m_BiosDamageDealtToMinelayer = 0;
	public int m_BiosDamageDealtToMonocyte = 0;
	public int m_BiosDamageDealtToMortar = 0;
	public int m_BiosDamageDealtToNeutrophil = 0;

	public int m_BiosDamageDealtToDys = 0;
	public int m_BiosDamageDealtToFunctional = 0;
	public int m_BiosDamageDealtToParcell = 0;
	public int m_BiosDamageDealtToBrainstorm = 0;

	public int m_BiosDamageDealt = 0;
	#endregion

	#region // Sym Kills
	public int m_SymKillsBlasterface = 0;
	public int m_SymKillsLaserface = 0;
	public int m_SymKillsLeech = 0;
	public int m_SymKillsMacrophage = 0;
	public int m_SymKillsMinelayer = 0;
	public int m_SymKillsMonocyte = 0;
	public int m_SymKillsMortar = 0;
	public int m_SymKillsNeutrophil = 0;

	public int m_SymEnemiesKilled = 0;
	#endregion

	#region // Bios Kills
	public int m_BiosKillsBlasterface = 0;
	public int m_BiosKillsLaserface = 0;
	public int m_BiosKillsLeech = 0;
	public int m_BiosKillsMacrophage = 0;
	public int m_BiosKillsMinelayer = 0;
	public int m_BiosKillsMonocyte = 0;
	public int m_BiosKillsMortar = 0;
	public int m_BiosKillsNeutrophil = 0;

	public int m_BiosEnemiesKilled = 0;
	#endregion

	#region // Module Uses
	public int m_SymCombatLeftUses = 0;
	public int m_SymCombatLeftDamage = 0;
	public int m_SymCombatLeftAccuracy = 0;

	public int m_SymCombatRightUses = 0;
	public int m_SymCombatRightDamage = 0;
	public int m_SymCombatRightAccuracy = 0;

	public int m_SymBodyUses = 0;
	public int m_SymCoreUses = 0;
	public int m_SymBoostUses = 0;

	public int m_BiosCombatLeftUses = 0;
	public int m_BiosCombatLeftDamage = 0;
	public int m_BiosCombatLeftAccuracy = 0;

	public int m_BiosCombatRightUses = 0;
	public int m_BiosCombatRightDamage = 0;
	public int m_BiosCombatRightAccuracy = 0;

	public int m_BiosBodyUses = 0;
	public int m_BiosCoreUses = 0;
	public int m_BiosBoostUses = 0;

	public int m_SynergyUses = 0;


	#endregion

	#region // Pickups Collected
	public int m_SymHealthPickupsCollected = 0;
	public int m_BiosHealthPickupsCollected = 0;
	public int m_TotalHealthPickupsCollected = 0;

	public int m_TotalPickupsCollected = 0;
	#endregion

	#endregion
	/// <summary>
	/// 
	/// </summary>
}

public class DataPerLevel // Data per level
{
	#region // Data
	public float m_LevelPlayTime = 0.0f;

	#region // Sym Damage Taken
	public int m_SymDamageTakenByBlasterface = 0;
	public int m_SymDamageTakenByLaserface = 0;
	public int m_SymDamageTakenByLeech = 0;
	public int m_SymDamageTakenByMacrophage = 0;
	public int m_SymDamageTakenByMinelayer = 0;
	public int m_SymDamageTakenByMonocyte = 0;
	public int m_SymDamageTakenByMortar = 0;
	public int m_SymDamageTakenByNeutrophil = 0;

	public int m_SymDamageTaken = 0;
	public int m_SymDamageAbsorbed = 0;
	public int m_SymLifeRestored = 0;
	#endregion

	#region // Bios Damage Taken
	public int m_BiosDamageTakenByBlasterface = 0;
	public int m_BiosDamageTakenByLaserface = 0;
	public int m_BiosDamageTakenByLeech = 0;
	public int m_BiosDamageTakenByMacrophage = 0;
	public int m_BiosDamageTakenByMinelayer = 0;
	public int m_BiosDamageTakenByMonocyte = 0;
	public int m_BiosDamageTakenByMortar = 0;
	public int m_BiosDamageTakenByNeutrophil = 0;

	public int m_BiosDamageTaken = 0;
	public int m_BiosDamageAbsorbed = 0;
	public int m_BiosLifeRestored = 0;
	#endregion

	#region // Sym Deaths
	public int m_SymDeathsByBlasterface = 0;
	public int m_SymDeathsByLaserface = 0;
	public int m_SymDeathsByLeech = 0;
	public int m_SymDeathsByMacrophage = 0;
	public int m_SymDeathsByMinelayer = 0;
	public int m_SymDeathsByMonocyte = 0;
	public int m_SymDeathsByMortar = 0;
	public int m_SymDeathsByNeutrophil = 0;

	public int m_SymDeaths = 0;
	public int m_SymRevives = 0;
	#endregion

	#region // Bios Deaths
	public int m_BiosDeathsByBlasterface = 0;
	public int m_BiosDeathsByLaserface = 0;
	public int m_BiosDeathsByLeech = 0;
	public int m_BiosDeathsByMacrophage = 0;
	public int m_BiosDeathsByMinelayer = 0;
	public int m_BiosDeathsByMonocyte = 0;
	public int m_BiosDeathsByMortar = 0;
	public int m_BiosDeathsByNeutrophil = 0;

	public int m_BiosDeaths = 0;
	public int m_BiosRevives = 0;
	#endregion

	#region // Sym Damage Dealt
	public int m_SymDamageDealtToBlasterface = 0;
	public int m_SymDamageDealtToLaserface = 0;
	public int m_SymDamageDealtToLeech = 0;
	public int m_SymDamageDealtToMacrophage = 0;
	public int m_SymDamageDealtToMinelayer = 0;
	public int m_SymDamageDealtToMonocyte = 0;
	public int m_SymDamageDealtToMortar = 0;
	public int m_SymDamageDealtToNeutrophil = 0;

	public int m_SymDamageDealtToDys = 0;
	public int m_SymDamageDealtToFunctional = 0;
	public int m_SymDamageDealtToParcell = 0;
	public int m_SymDamageDealtToBrainstorm = 0;

	public int m_SymDamageDealt = 0;
	#endregion

	#region // Bios Damage Dealt
	public int m_BiosDamageDealtToBlasterface = 0;
	public int m_BiosDamageDealtToLaserface = 0;
	public int m_BiosDamageDealtToLeech = 0;
	public int m_BiosDamageDealtToMacrophage = 0;
	public int m_BiosDamageDealtToMinelayer = 0;
	public int m_BiosDamageDealtToMonocyte = 0;
	public int m_BiosDamageDealtToMortar = 0;
	public int m_BiosDamageDealtToNeutrophil = 0;

	public int m_BiosDamageDealtToDys = 0;
	public int m_BiosDamageDealtToFunctional = 0;
	public int m_BiosDamageDealtToParcell = 0;
	public int m_BiosDamageDealtToBrainstorm = 0;

	public int m_BiosDamageDealt = 0;
	#endregion

	#region // Sym Kills
	public int m_SymKillsBlasterface = 0;
	public int m_SymKillsLaserface = 0;
	public int m_SymKillsLeech = 0;
	public int m_SymKillsMacrophage = 0;
	public int m_SymKillsMinelayer = 0;
	public int m_SymKillsMonocyte = 0;
	public int m_SymKillsMortar = 0;
	public int m_SymKillsNeutrophil = 0;

	public int m_SymKillsDys = 0;
	public int m_SymKillsFunctional = 0;
	public int m_SymKillsParcell = 0;
	public int m_SymKillsBrainstorm = 0;

	public int m_SymEnemiesKilled = 0;
	#endregion

	#region // Bios Kills
	public int m_BiosKillsBlasterface = 0;
	public int m_BiosKillsLaserface = 0;
	public int m_BiosKillsLeech = 0;
	public int m_BiosKillsMacrophage = 0;
	public int m_BiosKillsMinelayer = 0;
	public int m_BiosKillsMonocyte = 0;
	public int m_BiosKillsMortar = 0;
	public int m_BiosKillsNeutrophil = 0;

	public int m_BiosKillsDys = 0;
	public int m_BiosKillsFunctional = 0;
	public int m_BiosKillsParcell = 0;
	public int m_BiosKillsBrainstorm = 0;

	public int m_BiosEnemiesKilled = 0;
	#endregion

	#region // Module Uses
	public int m_SymCombatLeftUses = 0;
	public int m_SymCombatLeftDamage = 0;
	public int m_SymCombatLeftAccuracy = 0;

	public int m_SymCombatRightUses = 0;
	public int m_SymCombatRightDamage = 0;
	public int m_SymCombatRightAccuracy = 0;

	public int m_SymBodyUses = 0;
	public int m_SymCoreUses = 0;
	public int m_SymBoostUses = 0;

	public int m_BiosCombatLeftUses = 0;
	public int m_BiosCombatLeftDamage = 0;
	public int m_BiosCombatLeftAccuracy = 0;

	public int m_BiosCombatRightUses = 0;
	public int m_BiosCombatRightDamage = 0;
	public int m_BiosCombatRightAccuracy = 0;

	public int m_BiosBodyUses = 0;
	public int m_BiosCoreUses = 0;
	public int m_BiosBoostUses = 0;

	public int m_SynergyUses = 0;


	#endregion

	#region // Pickups Collected
	public int m_SymHealthPickupsCollected = 0;
	public int m_BiosHealthPickupsCollected = 0;
	public int m_TotalHealthPickupsCollected = 0;

	public int m_TotalPickupsCollected = 0;
	#endregion

	//Some kind of class or struct which inherits from IlevelData, this will be used to 
	//record specific level data based on the level the players are in

	#endregion

	/// <summary>
	/// 
	/// </summary>
}

[System.Serializable]
public class DataForever // Data forever
{
	#region // Data

	public float m_TotalPlayTime = 0.0f;

	#region // Level Completion
	[Header("Level Completion")]
	public int m_StomachLevelCompletions = 0;
	public int m_HeartLevelCompletions = 0;
	public int m_BrainLevelCompletions = 0;
	public int m_TotalLevelCompletions = 0;
	public float m_BestCompletionTimeStomach = 0.0f;
	public float m_BestCompletionTimeHeart = 0.0f;
	public float m_BestCompletionTimeBrain = 0.0f;
	#endregion

	#region // Damage Taken
	[Header("Damage Taken")]
	public int m_DamageTakenFromBlasterface = 0;
	public int m_DamageTakenFromLaserface = 0;
	public int m_DamageTakenFromLeech = 0;
	public int m_DamageTakenFromMacrophage = 0;
	public int m_DamageTakenFromMinelayer = 0;
	public int m_DamageTakenFromMonocyte = 0;
	public int m_DamageTakenFromMortar = 0;
	public int m_DamageTakenFromNeutrophil = 0;

	public int m_DamageTakenFromDys = 0;
	public int m_DamageTakenFromFunctional = 0;
	public int m_DamageTakenFromParcell = 0;
	public int m_DamageTakenFromBrainstorm = 0;

	public long m_TotalDamageTaken = 0; //Damage dealt to HP, not Shields
	public long m_TotalDamageAbsorbed = 0; //by mech shields
	public long m_TotalHealthRestored = 0;
	#endregion

	#region // Deaths
	[Header("Deaths")]
	public int m_DeathsFromBlasterface = 0;
	public int m_DeathsFromLaserface = 0;
	public int m_DeathsFromLeech = 0;
	public int m_DeathsFromMacrophage = 0;
	public int m_DeathsFromMinelayer = 0;
	public int m_DeathsFromMonocyte = 0;
	public int m_DeathsFromMortar = 0;
	public int m_DeathsFromNeutrophil = 0;

	public int m_DeathsFromDys = 0;
	public int m_DeathsFromFunctional = 0;
	public int m_DeathsFromParcell = 0;
	public int m_DeathsFromBrainstorm = 0;

	public long m_TotalDeaths = 0;
	public long m_TotalRevives = 0;
	#endregion

	#region // Damage Dealt
	[Header("Damage Dealt")]
	public int m_DamageDealtToBlasterface = 0;
	public int m_DamageDealtToLaserface = 0;
	public int m_DamageDealtToLeech = 0;
	public int m_DamageDealtToMacrophage = 0;
	public int m_DamageDealtToMinelayer = 0;
	public int m_DamageDealtToMonocyte = 0;
	public int m_DamageDealtToMortar = 0;
	public int m_DamageDealtToNeutrophil = 0;

	public int m_DamageDealtToDys = 0;
	public int m_DamageDealtToFunctional = 0;
	public int m_DamageDealtToParcell = 0;
	public int m_DamageDealtToBrainstorm = 0;

	public long m_TotalDamageDealt = 0;
	#endregion

	#region // Kills
	[Header("Kills")]
	public int m_KillsBlasterface = 0;
	public int m_KillsLaserface = 0;
	public int m_KillsLeech = 0;
	public int m_KillsMacrophage = 0;
	public int m_KillsMinelayer = 0;
	public int m_KillsMonocyte = 0;
	public int m_KillsMortar = 0;
	public int m_KillsNeutrophil = 0;

	public int m_KillsDys = 0;
	public int m_KillsFunctional = 0;
	public int m_KillsParcell = 0;
	public int m_KillsBrainstorm = 0;

	public long m_TotalEnemiesKilled = 0;
	#endregion

	#region // Module Info
	[Header("Combat Module Info")]
	public int m_UseCountAcidThrower = 0;
	public int m_UseCountGrenadeLauncher = 0;
	public int m_UseCountLaser = 0;
	public int m_UseCountPulse = 0;
	public int m_UseCountRifle = 0;
	public int m_UseCountShotgun = 0;
	public int m_UseCountTaser = 0;
	public int m_UseCountTentacle	= 0;

	public float m_AccuracyAcidThrower = 0;
	public float m_AccuracyGrenadeLauncher = 0;
	public float m_AccuracyLaser = 0;
	public float m_AccuracyPulse = 0;
	public float m_AccuracyRifle = 0;
	public float m_AccuracyShotgun = 0;
	public float m_AccuracyTaser = 0;
	public float m_AccuracyTentacle = 0;

	public long m_TotalCombatModuleUseCount = 0;
	public float m_TotalCombatModuleAccuracy = 0;

	[Header("Synergy Info")]
	public float m_TotalAccumulatedSynergy = 0.0f;
	public float m_AverageAccumulatedSynergyPerSecond = 0.0f;

	public int m_UseCountCyVirus = 0;
	public int m_UseCountSwap = 0;
	public int m_UseCountTether = 0;

	public long m_TotalSynergyModuleUseCount = 0;

	[Header("Boost Info")]
	public int m_UseCountBipod = 0;
	public int m_UseCountBlink = 0;
	public int m_UseCountDash = 0;
	public int m_UseCountEvasion = 0;

	public long m_TotalBoostModuleUseCount = 0;

	[Header("Core Info")]
	public int m_UseCountEMP = 0;
	public int m_UseCountInfest = 0;
	public int m_UseCountMirror = 0;
	public int m_UseCountShield = 0;

	public long m_TotalCoreModuleUseCount = 0;

	public long m_TotalModuleUseCount = 0;
	#endregion

	#region // Pickups Collected
	[Header("Pickups Collected")]
	public int m_HealthPickupsCollected = 0;
	public int m_TotalPickupsCollected = 0;
	#endregion
	
	#region // Misc Level Info
	[Header("Misc Level Info")]
	public int stuff;
	#endregion

	#region // Misc Boss Info
	[Header("Misc Boss Info")]
	public int thing;
	#endregion

	#endregion

	//Functions...
	public void Something()
	{

	}
}

public class MetricsManager
{
	//public Member Variables
	public DataPerLife m_DataPerLife;
	public DataPerLevel m_DataPerLevel;
	public DataForever m_DataForever;

	//INSTANCE!!!
	private static MetricsManager instance;
	public static MetricsManager Instance
	{
		get
		{
			if (instance == null) { instance = new MetricsManager(); }
			return instance;
		}
	}

	private MetricsManager()
	{

	}
}