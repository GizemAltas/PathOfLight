using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionDetector : MonoBehaviour
{
    private Movement movement; 
    private NavigationMaker navMake;
    [SerializeField] AudioSource boxMovement;
    [SerializeField] AudioSource instant;
    [SerializeField] AudioSource buttonClick;
    [SerializeField] AudioSource finish;

    GameObject but1;
    GameObject but2;
    GameObject but3;
    GameObject but4;
    GameObject but5;

    [SerializeField] GameObject box1;
    [SerializeField] GameObject box2;
    [SerializeField] GameObject box3;
    [SerializeField] GameObject box4;
    [SerializeField] GameObject box5;

    [SerializeField] GameObject firefly;
    [SerializeField] GameObject star;


    Vector3[] bug_positions = new[] { new Vector3(-15, 30, 25 ),        // LEVEL 1 DE ATE�B�CE��N�N INSTANTIATE POZ�SYONLARI
                                      new Vector3(0.65f, 65, 44.5f),
                                      new Vector3(36.5f,39.5f,3.3f)};
    Vector3[] bug_positions1 = new[] { new Vector3(-11.8f, -0.58f, 65f) };


    //BURASO


    Vector3 target, target2, target3,target4,target5;
    Vector3 refpos;

    public bool isTouch = false, isClick= false;
    
    private void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        navMake = GameObject.FindGameObjectWithTag("NavMake").GetComponent<NavigationMaker>();
        but1 = GameObject.FindGameObjectWithTag("But1");
        but2 = GameObject.FindGameObjectWithTag("But2");
        but3 = GameObject.FindGameObjectWithTag("But3");
        but4 = GameObject.FindGameObjectWithTag("But4");
        but5 = GameObject.FindGameObjectWithTag("But5");
        target = new Vector3(8, 0.1f, 0);   // Box1  ve 2 nin yeni konumlarr� harita �zerinden                                                                                                                      
        target2 = new Vector3(0,0.1f,-8);   // hesplamalar� yap�larak targte olarak tan�mlan�yor.
        target3 = new Vector3(0, 0, 50);
        target5 = new Vector3(0, 0, 21);
        target5 = new Vector3(0, 0, 21);
        

    }

    private void OnTriggerStay(Collider other)
    {
        //--------------------------------------- LEVEL 1 COLLISION STAY -------------------------------------------------------------
        if (other.gameObject.CompareTag("But1") && isTouch)
        {
            if (!isClick)
            {
                isClick = true;
                playSounds();
            }
            if (box1.transform.position.y >= 0)                                        // condition
            {
                navMake.navMeshBake();
                but1.transform.position = new Vector3(-20.4f, -16, -12);               // duvar�n i�ine g��s�n
                isTouch = false;
                but1.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                but1.gameObject.GetComponent<Renderer>().material.color = Color.black; // siyah ve dokunulamaz olsun
                but1.gameObject.tag = "Untagged";                                      // tekrar t�klama ihtimaline kar�� is touch true olmas�n diyetag�n� de�i�tiriyoruz.                                                                  
                Instantiate(firefly, bug_positions[0], Quaternion.Euler(90,0,90));
                boxMovement.Stop();                                                    // ate�b�ce�i olu�turma sesi ve hareket sonland� sesi 
                instant.Play();
            }
           
            box1.transform.position = Vector3.SmoothDamp(box1.transform.position, target, ref refpos, 1.25f,1.25f);

            }
            else if (other.gameObject.CompareTag("But2") && isTouch)
            {
                if (isClick)
                {
                    isClick = false;
                    playSounds();
                }
            if (box2.transform.position.y >= 0){  // condition
                        navMake.navMeshBake();
                        but2.transform.position = new Vector3(10.25f,-21,-31);
                        isTouch = false;
                        but2.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                        but2.gameObject.GetComponent<Renderer>().material.color = Color.black;
                        but2.gameObject.tag = "Untagged";
                        firefly.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);          // son b�ce�in boyutu yak�ndan oldugu i�in �ok b�y�k duruyor onu yar� yar�ya indirdim. 
                        Instantiate(firefly, bug_positions[1], Quaternion.Euler(90, 90, 45));
                        boxMovement.Stop();
                        instant.Play();
            }

             box2.transform.position = Vector3.SmoothDamp(box2.transform.position, target2, ref refpos, 1.25f,1.25f);

            }

        // -------------------------------------- LEVEL 1 collision.stay SON ---------------------------------------------------------------------
        //--------------------------------------- LEVEL 2 ---------------------------------------------------------------------------------------
        if (other.gameObject.CompareTag("But3") && isTouch)
        {
            if (!isClick)
            {
                isClick = true;
                playSounds();
            }
            if (box3.transform.position.z <= 5)                                        // condition
            {
                navMake.navMeshBake();
                but3.transform.position = new Vector3(-14, 17, -54);               // duvar�n i�ine g��s�n
                isTouch = false;
                but3.gameObject.GetComponent<BoxCollider>().isTrigger = false;
                but3.gameObject.GetComponent<Renderer>().material.color = Color.black; // siyah ve dokunulamaz olsun
                but3.gameObject.tag = "Untagged";                                      // tekrar t�klama ihtimaline kar�� is touch true olmas�n diyetag�n� de�i�tiriyoruz.                                                                  
                Instantiate(star,bug_positions1[0], Quaternion.Euler(90, 0, 90));
                boxMovement.Stop();                                                    // y�ld�z olu�turma sesi ve hareket sonland� sesi 
                instant.Play();
            }

            box3.transform.position = Vector3.SmoothDamp(box3.transform.position, target3, ref refpos, 1.25f, 1.25f);


        }
       

        //---------------------------------------- LEVEL 2 SON ------------------------------------------------------------------------------------
    }

    private void OnTriggerEnter(Collider other)
    {
        //----------------------------------------------- LEVEL 1 COLLISION ENTER ---------------------------------------------------------------------
        if (other.gameObject.CompareTag("Spot1"))
        {
            Destroy(other.gameObject);
            firefly.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);                  // ate�b�ce�i boyutu de�i�ti.
            Instantiate(firefly, bug_positions[2], Quaternion.Euler(90, -45, 180));        // ate�b�ce�i olu�tu.
            instant.Play();
        }
        else if (other.gameObject.CompareTag("finishBox") && movement.score == 5)          // e�er finishe geldiyse ve score 5 ise ana mape d�ns�n
        {
            
            finish.Play();
            StartCoroutine(waitForLoad(2.5f, 0));
        }
        //----------------------------------------------- LEVEL 1 collision.enter SON -----------------------------------------------------------------------------
        //----------------------------------------------- LEVEL 2 ---------------------------------------------------------------------------------

        if (other.gameObject.CompareTag("Spot2"))
        {
            Destroy(other.gameObject);
            star.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);                  // y�ld�z boyutu de�i�ti.
            Instantiate(star, bug_positions1[0], Quaternion.Euler(90, -45, 180));        // y�ld�z  olu�tu.
            instant.Play();
        }

        //---------------------------------------------- LEVEL 2 SON --------------------------------------------------------------------------------
    }

    private void OnTriggerExit(Collider other)      // oyunda bug olmamas� i�in e�er player bas�p ��kt�ysa s�rt�nme sesi sussun diye.
    {
        //------------------------------------------------- LEVEL 1 COLLISION EXIT ---------------------------------------------------------------------
        if (other.gameObject.CompareTag("But1") && isTouch)
        {
            stopSounds();
            isClick = false;
        }
        else if (other.gameObject.CompareTag("But2") && isTouch)
        {
            stopSounds();
            isClick = false;
        }
        //---------------------------------------------- LEVEL 1 collision.exit SON -------------------------------------------------------------------------------
        //---------------------------------------------- LEVEL 2 -----------------------------------------------------------------------------------

        if (other.gameObject.CompareTag("But3") && isTouch)
        {
            stopSounds();
            isClick = false;
        }





        //--------------------------------------------- LEVEL 2 SON ---------------------------------------------------------------------------------
    }

    void playSounds() {             // kutu hareketi m�ziklerini oynatma fonksiyonu
        buttonClick.Play();
        StartCoroutine(waitFunc(2));
        boxMovement.Play();
    }

    void stopSounds() {             // s�rt�nme sesi durdurma fonksiyonu
        boxMovement.Stop();
    }

    IEnumerator waitFunc(float a)          // bekleme coroutine fonksiyonu (a = saniye)
    {   
        yield return new WaitForSeconds(a);
    }
    IEnumerator waitForLoad(float a, int index)          // bekleme coroutine fonksiyonu (a = saniye)
    {
        yield return new WaitForSeconds(a);
        SceneManager.LoadScene(index);
    }



}
