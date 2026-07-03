## BaguetteMod

Mod BepInEx pour R.E.P.O. qui ajoute la Baguette, une arme de mêlée entièrement fonctionnelle spawnée en jeu via un AssetBundle.

# Fonctionnalités


Chargement d'un AssetBundle custom (baguette_assets) contenant le prefab Baguette
Spawn automatique de la baguette dans les niveaux via un patch Harmony sur LevelGenerator.ItemSetup
Objet ramassable et physique (Rigidbody + PhysGrabObject) intégré au système d'items de R.E.P.O.
Système d'attaque au clic gauche avec cooldown, détection par raycast/overlap sphere
Base d'un système réseau client → host pour la synchronisation des coups (NetMessages)

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
