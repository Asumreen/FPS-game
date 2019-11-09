using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class gamecontroller : MonoBehaviour {
    [Tooltip("the text that show the player scoure")]
    public Text scoureText;
    [Tooltip("the text that show the amount of ammo that the player have to the active gun")]
    public Text shootsText;
    [Tooltip("the text that show the amount of ammo remained on the player active gun")]
    public Text onGunText;
    [Tooltip("the health bar image , show how muvh the player remained")]
    public Image PlayerHealthBar;
    [Tooltip("an object that hold the relode sound clip")]
    public GameObject relodeSounds;
    [Tooltip("the 9Mm gun for the player")]
    public GameObject gun;
    [Tooltip("the Ak-47 gun for t he player")]
    public GameObject AK;
    [Tooltip("list have all the doors of the rooms that open whene the player scour amount of points")]
    public List<GameObject> Doors;
    public RawImage ScreenFalsh;
    [Tooltip("the object refer to the gun that the player hold currently")]
    public GameObject activeGun;
    [Tooltip("an array of sound sources that have the hurt sounds")]
    public AudioSource[] hert;
    [Tooltip("a object that control loding and unloding levels ")]
    public GameObject levelLoder;
    // a list on the guns that the player have 
    List<GameObject> guns;
    //player start amount of health
    int PlayerHealth = 10;
    //the start amount of ammos for the guns
    int shoots9m=0;
    int shootsAk47 = 0;
    //the start amuont of ammos on the guns 
    int ongun9m=0;
    int ongunAk47=0;
    //the start value of scour;
    int scour=0;
    //flags to holde the state of the guns are they in reloding state or not   
    bool reloding9m = false;
    //Vector that hold the position of our player
    Vector3 PlayerPosition;
    bool relodingAk=false;
    //flags to holde the state of the doors are they closed or not
    bool Door1Closed = true;
    bool Door2Closed = true;
    bool Door3Colsed = true;
    //a fleg to holde the state of the enemys are they attacking or not
    bool isAttacking = false;
    // the object for singleton 
    public static gamecontroller ins;
    // Use this for initialization
    void Start () {
        //set the singleton object to this 
        ins = this;
        //call the updateScoure function on the start of the game to give it an start value 
        updateScore();
        //declere the List guns
        guns = new List<GameObject>();
        //get the AudioSources that has been inserted to the gamecontroller object in the editer 
        hert= GetComponents<AudioSource>();
        
    }
    
    // Update is called once per frame
    void Update () {
        //chick if the player preesed the change button and he have more than one gun  
        if (CrossPlatformInputManager.GetButtonDown("change")&&guns.Count>1) {
            //get the index of the current active gun on the listr guns and set the object on the next index as the active cun if the current have the last index in the list then set the object in the first index as the active gun 
            int i=guns.IndexOf(activeGun);
            if(i==guns.Count-1){
                i = 0;
            }
            else{
                i++;
            }
            changeGun(guns[i]);
        }
        //Door1 is the Door for the Room 2 it's open whene the player get scour of 300 or more 
        if(scour>=300&&Door1Closed){
            //to make sure that the door only open ones then stay open
            Door1Closed = false;
          //  levels[1].gameObject.SetActive(true);
            Doors[0].SendMessage("open");
        }
        /* if(!Door1Closed&&levels[0].active){
             if(PlayerPosition.x<-17.75){
                Door1Closed=true;
                Doors[0].SendMessage("close");              
            }*/
        
        //Door2 is the Door for the Room 3 it's open whene the player get scour of 3000 or more
        if (scour>=3000&&Door2Closed){
            //to make sure that the door only open ones then stay open
            Door2Closed = false;
            Doors[1].GetComponent<Animation>().Play();
        }
        //Door4 is the Door for the Room 4 it's open whene the player get scour 6000 or more
        if (scour>=6000&&Door3Colsed){
            //to make sure that the door only open ones then stay open
            Door3Colsed = false;
            Doors[2].GetComponent<Animation>().Play();
        }
        //update the plyer healthBar according to the amount of health the player have left
        PlayerHealthBar.fillAmount=(PlayerHealth/ 10f);
       
    }
    //to keep track of the player position 
    public void updatePlayerPos(Vector3 pp){
        PlayerPosition=pp;
    }
    //function addToScour is called from out of the class from the target classs and the enemy classes passing the value to add to the scour 
    public void addToScour(int inc){
        scour += inc;
        updateScore();
    }
    //function updateOnGun called from out and in the class chick which is the acrive gun when it call and update the onGunText 
    public void updateOnGun()
    {
        if (activeGun.name == "M9")
            onGunText.text = "" + ongun9m;
        else
            onGunText.text = "" + ongunAk47;
    }
    public void updateShoots(){
        if (activeGun.name == "M9")
            shootsText.text = "" + shoots9m;
        else
            shootsText.text = "" + shootsAk47;
    }
    void updateScore()
    {
        scoureText.text = "Scour :" + scour;

    }
    public void addAmmo(int i,string name)
    {
       
        if (name == "9m")
        {
            shoots9m += i;
        }
        else{
            shootsAk47 += i;
        }
        updateShoots();
    }
    public bool canShoot()
    {
        if (activeGun.name == "M9")
        {
            return ongun9m > 0 && !reloding9m;
        }
        else{
            return ongunAk47 > 0 && !relodingAk && !AKScript.shooting;
        }

    }
  
    public bool isReloding9m()
    {
        return reloding9m;
    }
    public int getOnGun9m(){
        return ongun9m;
    }
    public int getOnGunAK(){
        return ongunAk47;
    }
    public void shoot9m(){
        ongun9m--;
        updateOnGun();
    }
    public void shootAK(){
        AK.GetComponent<Animation>().Play("AK");
        ongunAk47--;
        updateOnGun();
    }
    public IEnumerator relode9m()
    {
        if (shoots9m > 0)
        {
            reloding9m = true;
            gun.GetComponent<Animation>().Play("RelodeAnimation");
            relodeSounds.GetComponent<AudioSource>().PlayOneShot(relodeSounds.GetComponent<AudioSource>().clip);
            int need = 12 - ongun9m;
            if (shoots9m >= need)
            {
                ongun9m += need;
                shoots9m -= need;
            }
            else if (shoots9m > 0)
            {
                ongun9m += shoots9m;
                shoots9m = 0;
            }
        }
        else
        {
            noAmmo();
        }
        updateOnGun();
        updateShoots();
        yield return new WaitForSeconds(1);
        reloding9m = false;
    }
    public IEnumerator relodeAK(){
        if(shootsAk47>0){
            relodingAk = true;
            AK.GetComponent<Animation>().Play("relodeAK");
            relodeSounds.GetComponent<AudioSource>().PlayOneShot(relodeSounds.GetComponent<AudioSource>().clip);
            int need = 30 - ongunAk47;
            if(shootsAk47>=need){
                ongunAk47 += need;
                shootsAk47 -= need;
            }
            else if(shootsAk47>0){
                ongunAk47 += shootsAk47;
                shootsAk47 = 0;
            }
        }
        else{
            noAmmo();
        }
        updateOnGun();
        updateShoots();
        yield return new WaitForSeconds(2);
        relodingAk = false;
    }
    void noAmmo()
    {
        Debug.Log("you need more ammo");
    }
    void changeGun(GameObject actGun){
        actGun.SetActive(true);
        activeGun = actGun;
        foreach(GameObject a in guns){
            if(a!= actGun)
            {
                a.SetActive(false);
            }
        }
        updateOnGun();
        updateShoots();
    }
    public void pickupGun(GameObject newGun){
        guns.Add(newGun);
        changeGun(newGun);

    }
    public string getActiveGun(){
        return activeGun.name;
    }
    public IEnumerator playerDamged(){
        isAttacking = true;
        int index = Random.Range(0, hert.Length);
        yield return new WaitForSeconds(0.9f);
        ScreenFalsh.gameObject.SetActive(true);
        PlayerHealth--;
        hert[index].PlayOneShot(hert[index].clip);
        yield return new WaitForSeconds(0.05f);
        ScreenFalsh.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
    public bool GetisAttacking() {
        return isAttacking;
    }
}
