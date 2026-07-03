## BaguetteMod

Mod BepInEx pour R.E.P.O. qui ajoute la Baguette, une arme de mêlée entièrement fonctionnelle spawnée en jeu via un AssetBundle.

# Fonctionnalités


Chargement d'un AssetBundle custom (baguette_assets) contenant le prefab Baguette
Spawn automatique de la baguette dans les niveaux via un patch Harmony sur LevelGenerator.ItemSetup
Objet ramassable et physique (Rigidbody + PhysGrabObject) intégré au système d'items de R.E.P.O.
Système d'attaque au clic gauche avec cooldown, détection par raycast/overlap sphere
Base d'un système réseau client → host pour la synchronisation des coups (NetMessages)


# Structure du projet

MeleeWeaponMod/
├── MeleeWeaponMod.cs      # Plugin principal (BepInPlugin), chargement de l'AssetBundle
├── MeleeWeapon.cs         # Composant d'attaque générique (input + envoi réseau)
├── BaguetteSpawner.cs     # Arme Baguette (dégâts, swing) + patch Harmony de spawn
├── WeaponSpawner.cs       # Utilitaire de spawn de l'arme dans une main/parent donné
├── NetMessages.cs         # Gestion des messages d'attaque client → host
├── baguette_assets        # AssetBundle Unity contenant le prefab de la baguette
├── Libs/                  # Références BepInEx / UnityEngine (non redistribuées)
└── MeleeWeaponMod.csproj  # Projet .NET Framework 4.8

# Prérequis


BepInEx installé sur R.E.P.O.
.NET Framework 4.8 (SDK) pour compiler
HarmonyLib (fourni avec BepInEx)


# Compilation

bashdotnet build MeleeWeaponMod.csproj

Le build copie automatiquement baguette_assets dans le dossier de sortie (bin/Debug/net48/).

# Installation


Compiler le mod (ou récupérer MeleeWeaponMod.dll)
Copier MeleeWeaponMod.dll et baguette_assets dans le dossier :


   R.E.P.O/BepInEx/plugins/BaguetteMod/


Lancer le jeu — le log [BaguetteMod] Loaded ! doit apparaître dans la console BepInEx
