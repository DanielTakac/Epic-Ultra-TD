using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine;

public class DebugController : MonoBehaviour {

    bool commandFound;
    bool showConsole;
    bool showHelp;

    string input;

    public static DebugCommand KILL_ALL;
    public static DebugCommand DESTROY_TURRETS;
    public static DebugCommand SPAWN_ENEMY;
    public static DebugCommand SPAWN_COIN;
    public static DebugCommand END_GAME;
    public static DebugCommand GET_MONEY;
    public static DebugCommand QUIT_APP;
    public static DebugCommand RESTART;
    public static DebugCommand PAUSE;
    public static DebugCommand RESUME;
    public static DebugCommand SHIELD_ENEMIES;
    public static DebugCommand SHIELD_TURRETS;
    public static DebugCommand SHIELD_ALL;
    public static DebugCommand BREAK_SHIELD_ENEMIES;
    public static DebugCommand BREAK_SHIELD_TURRETS;
    public static DebugCommand BREAK_SHIELD_ALL;
    public static DebugCommand FPS_ENABLE;
    public static DebugCommand FPS_DISABLE;
    public static DebugCommand GET_BOOST;
    public static DebugCommand LOSE_BOOST;
    public static DebugCommand BOOST;
    public static DebugCommand RESET_LEVEL_PROGRESS;
    public static DebugCommand FINISH_ALL_LEVELS;
    public static DebugCommand SPAWN_VOYAGER;
    public static DebugCommand SPAWN_MONEY;
    public static DebugCommand SPAWN_TESLA;
    public static DebugCommand SPAWN;
    public static DebugCommand SPAWN_MINIGUN;
    public static DebugCommand HELP;

    public List<object> commandList;

    public void OnToggleDebug(InputAction.CallbackContext context){

        if (context.performed){

            showConsole = !showConsole;

            Debug.Log("Dev Console Opened");
        
        }

    }

    public void OnReturn(InputAction.CallbackContext context){

        if (context.performed){

            if (showConsole){

                HandleInput();
                input = "";

            }

        }

    }

    private void Awake() {

        KILL_ALL = new DebugCommand("kill all", "Removes all enemies", "kill all", (string[] parameters) => {

            Debug.Log("KILL_ALL");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ghoul");

            for (int i = 0; i < enemies.Length; i++){

                Destroy(enemies[i]);

            }

        });

        DESTROY_TURRETS = new DebugCommand("destroy turrets", "Removes all turrets", "destroy turrets", (string[] parameters) => {

            Debug.Log("DESTROY_TURRETS");

            GameObject[] turrets = GameObject.FindGameObjectsWithTag("Tower");

            for (int i = 0; i < turrets.Length; i++){

                Destroy(turrets[i]);

            }

        });

        SPAWN_ENEMY = new DebugCommand("spawn enemy", "Spawns an enemy", "spawn enemy", (string[] parameters) => {

            Debug.Log("SPAWN_ENEMY");

            GameObject.FindGameObjectWithTag("Spawners").GetComponent<Spawner>().SpawnEnemy(Random.Range(1, 6));

        });

        SPAWN_COIN = new DebugCommand("spawn coin", "Spawns a coin", "spawn coin", (string[] parameters) => {

            Debug.Log("SPAWN_COIN");

            GameObject.FindGameObjectWithTag("TurretShop").GetComponent<SunSpawner>().SpawnCoin();

        });

        END_GAME = new DebugCommand("end game", "Game Over", "end game", (string[] parameters) => {

            Debug.Log("END_GAME");

            GameManager.lives = 0;

        });

        GET_MONEY = new DebugCommand("get money", "Gives the player money", "get money", (string[] parameters) => {

            Debug.Log("GET_MONEY");

            GameManager.money = 10000;

        });

        QUIT_APP = new DebugCommand("quit app", "Closes the application", "quit app", (string[] parameters) => {

            Debug.Log("QUIT_APP");

            Application.Quit();

        });

        RESTART = new DebugCommand("restart", "Reopens the current scene", "restart", (string[] parameters) => {

            Debug.Log("RESTART");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        });

        PAUSE = new DebugCommand("pause", "Disables the enemy movement", "pause", (string[] parameters) => {

            Debug.Log("PAUSE");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ghoul");

            for (int i = 0; i < enemies.Length; i++){

                enemies[i].GetComponent<Ghoul>().StartIdle();
                enemies[i].GetComponent<Ghoul>().paused = true;

            }

        });

        RESUME = new DebugCommand("resume", "Enables the enemy movement", "resume", (string[] parameters) => {

            Debug.Log("RESUME");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ghoul");

            for (int i = 0; i < enemies.Length; i++){

                enemies[i].GetComponent<Ghoul>().StartWalking();
                enemies[i].GetComponent<Ghoul>().paused = false;

            }

        });

        SHIELD_ENEMIES = new DebugCommand("shield enemies", "Makes the enemies invincible", "shield enemies", (string[] parameters) => {

            Debug.Log("SHIELD_ENEMIES");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ghoul");

            for (int i = 0; i < enemies.Length; i++){

                enemies[i].GetComponent<Ghoul>().GetShield();

            }

        });

        SHIELD_TURRETS = new DebugCommand("shield turrets", "Makes the turrets invincible", "shield turrets", (string[] parameters) => {

            Debug.Log("SHIELD_TURRETS");

            GameObject[] turrets = GameObject.FindGameObjectsWithTag("Tower");

            for (int i = 0; i < turrets.Length; i++){

                turrets[i].GetComponent<TowerHealth>().GetShield();

            }

        });

        SHIELD_ALL = new DebugCommand("shield all", "Makes all objects invincible", "shield all", (string[] parameters) => {

            Debug.Log("SHIELD_ALL");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ghoul");

            for (int i = 0; i < enemies.Length; i++){

                enemies[i].GetComponent<Ghoul>().GetShield();

            }

            GameObject[] turrets = GameObject.FindGameObjectsWithTag("Tower");

            for (int i = 0; i < turrets.Length; i++){

                turrets[i].GetComponent<TowerHealth>().GetShield();

            }

        });

        BREAK_SHIELD_ENEMIES = new DebugCommand("break shield enemies", "Makes the enemies damagable", "break shield enemies", (string[] parameters) => {

            Debug.Log("BREAK_SHIELD_ENEMIES");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ghoul");

            for (int i = 0; i < enemies.Length; i++){

                enemies[i].GetComponent<Ghoul>().BreakShield();

            }

        });

        BREAK_SHIELD_TURRETS = new DebugCommand("break shield turrets", "Makes the turrets damagable", "break shield turrets", (string[] parameters) => {

            Debug.Log("BREAK_SHIELD_TURRETS");

            GameObject[] turrets = GameObject.FindGameObjectsWithTag("Tower");

            for (int i = 0; i < turrets.Length; i++){

                turrets[i].GetComponent<TowerHealth>().BreakShield();

            }

        });

        BREAK_SHIELD_ALL = new DebugCommand("break shield all", "Makes all objects damagable", "break shield all", (string[] parameters) => {

            Debug.Log("BREAK_SHIELD_ALL");

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Ghoul");

            for (int i = 0; i < enemies.Length; i++){

                enemies[i].GetComponent<Ghoul>().BreakShield();

            }

            GameObject[] turrets = GameObject.FindGameObjectsWithTag("Tower");

            for (int i = 0; i < turrets.Length; i++){

                turrets[i].GetComponent<TowerHealth>().BreakShield();

            }

        });

        FPS_ENABLE = new DebugCommand("fps enable", "Enables the FPS counter", "fps enable", (string[] parameters) => {

            Debug.Log("FPS_ENABLE");

            GameObject.FindGameObjectWithTag("FPSCounter").GetComponent<FrameCounter>().EnableFPS();

        });

        FPS_DISABLE = new DebugCommand("fps disable", "Disables the FPS counter", "fps disable", (string[] parameters) => {

            Debug.Log("FPS_DISABLE");

            GameObject.FindGameObjectWithTag("FPSCounter").GetComponent<FrameCounter>().DisableFPS();

        });

        GET_BOOST = new DebugCommand("get boost", "Gives the player infinite boosts", "get boost", (string[] parameters) => {

            Debug.Log("GET_BOOST");

            BoostShop.boosts = 10000;

            PlayerPrefs.SetInt("boost", 10000);

        });

        LOSE_BOOST = new DebugCommand("lose boost", "Sets the boosts to 0", "lose boost", (string[] parameters) => {

            Debug.Log("LOSE_BOOST");

            BoostShop.boosts = 0;

            PlayerPrefs.SetInt("boost", 0);

        });

        BOOST = new DebugCommand("boost", "Boosts all towers", "boost", (string[] parameters) => {

            Debug.Log("BOOST");

            MoneyBoost[] money = FindObjectsOfType<MoneyBoost>();

            VoyagerBoost[] voyager = FindObjectsOfType<VoyagerBoost>();

            TeslaBoost[] tesla = FindObjectsOfType<TeslaBoost>();

            MinigunBoost[] minigun = FindObjectsOfType<MinigunBoost>();

            MissileBoost[] missile = FindObjectsOfType<MissileBoost>();

            for (int i = 0; i < money.Length; i++){

                money[i].Activate();

            }

            for (int i = 0; i < voyager.Length; i++){

                voyager[i].Activate();

            }

            for (int i = 0; i < tesla.Length; i++){

                tesla[i].Activate();

            }

            for (int i = 0; i < minigun.Length; i++){

                minigun[i].Activate();

            }

            for (int i = 0; i < missile.Length; i++){

                missile[i].Activate();

            }

        });

        RESET_LEVEL_PROGRESS = new DebugCommand("reset level progress", "Resets all finished levels", "reset level progress", (string[] parameters) => {

            Debug.Log("RESET_LEVEL_PROGRESS");

            for (int i = 1; i <= 10; i++) PlayerPrefs.SetInt($"level{i}", 0);

        });

        FINISH_ALL_LEVELS = new DebugCommand("finish all levels", "Finishes all levels", "finish all levels", (string[] parameters) => {

            Debug.Log("FINISH_ALL_LEVELS");

            for (int i = 1; i <= 10; i++) PlayerPrefs.SetInt($"level{i}", 1);

        });

        SPAWN = new DebugCommand("spawn", "Spawns an object - 2 parameter: string object name (voyager, money, tesla, missile, minigun, enemy, coin), int amount of objects to spawn", "spawn", (string[] parameters) => {

            // Returns if the second parameter isn't a number
            if (!int.TryParse(parameters[1], out int amount)) return;

            bool parameterIsTurret = false;

            foreach (string turretName in GameObject.FindObjectOfType<TurretShop>().turretPrefabs.Keys)
                if (parameters[0] == turretName)
                    parameterIsTurret = true;

            if (parameters[0] == "enemy") {



            } else if (parameters[0] == "coin") {



            } else if (parameterIsTurret) {

                var turretShop = FindObjectOfType<TurretShop>();

                turretShop.turretsClicked[parameters[0]] = true;

                foreach (Transform child in GameObject.FindGameObjectWithTag("TileParent").transform) {

                    if (amount <= 0) break;

                    turretShop.SpawnTurret(child);

                    amount--;

                }

                turretShop.turretsClicked[parameters[0]] = false;

            }

        });

        HELP = new DebugCommand("help", "Shows a list of commands", "help", (string[] parameters) => {

            showHelp = true;

        });

        commandList = new List<object>{

            KILL_ALL,
            DESTROY_TURRETS,
            SPAWN_ENEMY,
            SPAWN_COIN,
            END_GAME,
            GET_MONEY,
            QUIT_APP,
            RESTART,
            PAUSE,
            RESUME,
            SHIELD_ENEMIES,
            SHIELD_TURRETS,
            SHIELD_ALL,
            BREAK_SHIELD_ENEMIES,
            BREAK_SHIELD_TURRETS,
            BREAK_SHIELD_ALL,
            FPS_ENABLE,
            FPS_DISABLE,
            GET_BOOST,
            LOSE_BOOST,
            BOOST,
            RESET_LEVEL_PROGRESS,
            FINISH_ALL_LEVELS,
            SPAWN_VOYAGER,
            SPAWN_MONEY,
            SPAWN_TESLA,
            SPAWN,
            SPAWN_MINIGUN,
            HELP

        };
        
    }

    Vector2 scroll;

    private void OnGUI(){

        if (!showConsole) return;

        float y = 0f;

        if (showHelp){

            GUI.Box(new Rect(0, y, Screen.width, 100), "");

            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);

            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

            for (int i = 0; i < commandList.Count; i++){

                DebugCommandBase command = commandList[i] as DebugCommandBase;

                string label = $"{command.commandFormat} - {command.commandDescription}";

                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);

                GUI.Label(labelRect, label);

            }

            GUI.EndScrollView();

            y += 100;

        }

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);

    }

    private void HandleInput(){

        commandFound = false;

        for (int i = 0; i < commandList.Count; i++){

            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if (input.Contains(commandBase.commandId)){

                if (commandList[i] as DebugCommand != null){

                    int startPos = input.IndexOf((commandList[i] as DebugCommand).commandId);
                    int endPos = startPos + (commandList[i] as DebugCommand).commandId.Length;

                    string substring = input.Remove(startPos, endPos).Trim();

                    string[] arguments = substring.Split();


                    (commandList[i] as DebugCommand).Invoke(arguments);

                }

                commandFound = true;

            }

        }

        if (commandFound == false){

            Debug.Log("Command not found!");

        }

    }

}
