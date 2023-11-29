# Clone-Virtual World
  Tomorrow Learning Camp

## **Essential Requirements**

### 1) Creat Character - Complete

### 2) Character Movement - Complete

### 3) Creat Room - Complete

### 4) Follow Camera - Complete

<br/>
<br/>

***

<br/>
<br/>

## **Selection Requirements**

### 1) Character Animation - Complete

### 2) Input Name System - Complete

### 3) Character Choice System - Complete

### 4) Number Of Attendees UI - Complete

### 5) InGame Character Choice - Complete

### 6) InGame Name Chanage - Complete

### 7) Time Mark - Complete

### 8) NPC Conversation - Complete




![1111](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/18280ae3-f5e7-44d0-978b-1c746972191c)


📌 캐릭터 애니메이션 추가

![image](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/27f6988b-8a50-4c56-adac-5edae4fdd854)


Animator에서 float값으로 0.1을 기준으로 0.1보다 크거나 작으면 Run 애니메이션이 동작하고 멈추게 하였다.

    private void FixedUpdate()
    {
        // 이동 로직 실행
        ApllyMovement(_movementDirection);

        // Player Animation is Run Check
        playerAnim.SetFloat("Move", _movementDirection.magnitude);
    }
저번 글에서 했던거의 연장선이다.

ApllyMovement(_movementDirection); 는 안에 _movementDirection가 이벤트에 등록되어 있어 키 입력이 들어올 경우만 값이 들어가고 입력이 멈추면 0이 들어가기 때문에 _movementDirection을 .magnitude하여 float값으로 변환하여 애니메이션에 이용했다.





📌 이름 입력 시스템
Input Field를 사용하였다.

![image (1)](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/5e57c386-290d-4e03-8eb5-e0dcd7c7f698)


위 처럼 Input Field를 사용하여 입력값을 받는다.

public class PlayerInformation : MonoBehaviour
{
    [SerializeField] private InputField playerinputName;
    [SerializeField] private SceneMovement sceneMove;

    private string playerName = null;

    private void Awake()
    {
        playerName = playerinputName.GetComponent<InputField>().text;
    }

    // 플레이어 이름 저장
    public void PlayerInputNameSave()
    {
        // Player Name 2 ~ 10 글자 사이 제한
        if (playerinputName.text.Length > 1 && playerinputName.text.Length < 11)
        {
            // 조건 충족시 이름 저장
            playerName = playerinputName.text;
            // 게임 매니저에 이름 저장
            GameManager.instance.SettingPlayerName(playerName);
            // 씬 이동
            sceneMove.GoMainScene();
        }
    }

}


위에서 입력을 받으면 GameManager에 저장하여 이름 값을 중앙에서 관리하도록 하였다.

public class GameManager : MonoBehaviour
{
    #region Instance
    public static GameManager instance = null;

    private void Awake()
    {
        // instance가 null이라면
        if (instance == null)
        {
            // 자기 자신을 intance에 넣는다.
            instance = this;
            //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
            DontDestroyOnLoad(gameObject);
        }
        // 이미 존재한다면
        else 
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    
    // 플레이어 이름
    private string playerName;
    // 플레이어 이름 저장
    public void SettingPlayerName(string name)
    {
        playerName = name;
    }

    // 플레이어 이름 불러오기
    public string OutputPlayerName()
    {
        return playerName;
    }




📌 캐릭터 선택 시스템

![image](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/370dc0a0-e146-4be2-9fe2-aafafafd7384)

// GameManager.cs
// 생략

    private void Start()
    {
        Initalize();
    }

    // 캐릭터 정보
    private GameObject kngiht;
    private GameObject wizzard;

    // 캐릭터 선택 정보
    private int characterIndex = 0;
    
    private void Initalize()
    {
        kngiht = Resources.Load<GameObject>("Prefabs/PlayerKnight");
        wizzard = Resources.Load<GameObject>("Prefabs/PlayerWizzard");
    }
    #endregion

    // 플레이어 이름 저장
    public void SettingPlayerName(string name)
    {
        playerName = name;
    }

    // 플레이어 이름 불러오기
    public string OutputPlayerName()
    {
        return playerName;
    }

    // Knight 선택
    public void KnightChoice()
    {
        characterIndex = 0;
    }

    // Wizzard 선택
    public void WizzardChoice()
    {
        characterIndex = 1;
    }

    public void InvokeCharacter()
    {
        if (characterIndex == 0) 
        {
            Instantiate(kngiht);
            //Destroy(wizzard);
        }
        else if (characterIndex == 1) 
        {
            Instantiate(wizzard);
            //Destroy(kngiht);
        }
    }
캐릭터를 선택하고 그 정보를 가지고 다음 씬으로 넘어가면 Prefab화 해둔 캐릭터를 그 고른 값에 맞게 Instantiate하여 클론을 찍어내도록 하였다. ( 나중에 MainScene에서 캐릭터 변경을 위한 설계 )

Resources.Load를 이용하여 드래그&드롭 으로 할당하는게 아닌 스크립트로 정보를 얻게했다.






public class CameraTransform : MonoBehaviour
{
    [SerializeField] private GameObject player;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
캐릭터는 MainScene에 넘어가면 CharacterIndex를 가지고 클론은 찍어내기에 prefab에 태그를 걸어주어 메인씬이 셋팅될 때 camerafollow에 할당해주고 player를 따라다니게 하였다.





📌 참석 인원 UI

![image (3)](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/1e2d3f9c-ff03-4e8b-8f35-77ccbcd89ff0)

public class MainSceneSetting : MonoBehaviour
{
    // 접속자 명단 리스트
    [SerializeField] private List<GameObject> personnel = new List<GameObject>();

    private void Awake()
    {
        // 선택한 캐릭터 생성
        GameManager.instance.InvokeCharacter();
    }

    private void Start()
    {
        for (int i = 0; i < personnel.Count; i++)
        {
            // GameManager에 NPC이름 저장
            GameManager.instance.NPCNameSave(personnel[i].transform.GetChild(0).GetComponent<TextMesh>().text);
        }
    }
}
MainSceneSetting.cs에서 npc들의 이름을 GameManager로 옮겨 저장했다.






// GameManager.cs
// 생략

    // NPC 이름
    private List<string> npcNames = new List<string>();
    
    // NPC 이름 저장
    public void NPCNameSave(string name)
    {
        npcNames.Add(name);
    }

    // NPC 이름 불러내기
    public string[] OutPutNPCName()
    {
        string[] outName = new string[npcNames.Count];
        for(int i = 0; i < npcNames.Count; i++)
        {
            outName[i] = npcNames[i];
        }
        return outName;
    }
GameManager에서 Npc의 이름을 관리하고 뿌릴수 있게 해두었다.






public class MainUIManager : MonoBehaviour
{
    public Text personUI;

    //private void Awake()
    //{
    //    personUI = GetComponent<Text>();
    //}

    private void LateUpdate()
    {
        
    }

    // 접속자 명단 업데이트
    public void NameSetting()
    {
        string[] npcNames = GameManager.instance.OutPutNPCName();
        string playerName = GameManager.instance.OutputPlayerName();

        // 명단 초기화
        personUI.text = "";

        personUI.text += " ::접속자 명단:: \n\n";
        
        foreach (string npcName in npcNames) 
        {
            personUI.text += " " + npcName + "\n\n";
        }

        personUI.text += " " + playerName;
    }
}
MainUIManager에서 GameManager에 있는 NPC의 이름들을 가져와 표시할 Text에 함수가 불릴 때 마다 호출하도록 하였다.

NPC들을 Prefab화 하여 관리하고 씬이 불려올 때 List를 셋팅해주고 싶은데 시간이 없어서 시간이 남으면 해볼려고 한다.





📌 인게임 캐릭터 선택

![image (4)](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/b1a88508-9dd3-4414-9c45-63982cdd6678)

// MainUIManager.cs
// 생략

    // 캐릭터 재선택
    public void KnightSelect()
    {
        GameManager.instance.KnightChoice();
    }

    public void WizzardSelect()
    {
        GameManager.instance.WizzardChoice();
    }

    public void SelectCharacter()
    {
        GameManager.instance.InvokeCharacter();
        Invoke("PlayerNameSetting", 0.1f);
    }

    // 바뀐 캐릭터에 이름 적용
    public void PlayerNameSetting()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.GetChild(1).GetComponent<TextMesh>().text = GameManager.instance.OutputPlayerName();
    }

    // 원래 캐릭터 파괴
    public void CheckDestory()
    {
        beforeCharacter = GameObject.FindGameObjectWithTag("Player");
        Destroy(beforeCharacter);
    }
각각 메서드들을 캐릭터 선택에 맞는 버튼에 넣어 원래 있던 오브젝트는 파괴시키고 카메라 및 이름을 다시 달아주게 하였다.





📌 인게임 이름 바꾸기

![image (5)](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/ee188d0b-b261-4127-8d50-09fcf0cd389b)

![image (6)](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/e3cac741-15d2-450b-9839-cac8d46b08b9)



위처럼 이름바꾸기 버튼을 눌러 이름을 입력한 뒤에 Chanage버튼을 누르면 이름이 바뀌게 하였다.

원래 StartScene에서 사용했던 패널을 그대로 들고와 씬이동같은 필요없는 기능만 빼고 이름을 바꾸면 이름을 다시 로드해주는 식으로 사용하였다.

한가지 문제점으로 이름을 바꾸려고 입력을 할 때에 뉴인풋시스템 때문에 입력이 들어가 캐릭터가 움직였는데, 이름 바꾸기 버튼을 누르면 Time.timeScale을 0으로 만들고 창을 끄거나 체인지를 하면 Time.timeScale을 1로 만들어주어 입력을 방지했다.





📌 시간 표시

![image (7)](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/dc9a9255-19c0-488f-a63d-a3dbea00ea79)

좌측 상단에 현재 시간과 동일한 시간이 표시되게 해줬다.

public class DeltaTimeNow : MonoBehaviour
{
    private Text timeText;

    private void Awake()
    {
        timeText = transform.GetComponent<Text>();
    }

    private void Update()
    {
        timeText.text = GetCurrentDate();
    }

    public static string GetCurrentDate()
    {
        return DateTime.Now.ToString(("HH : mm"));
    }
}
text UI를 만들어 위에 스크립트를 넣어줘서 시간과 분까지 나오는 현재시간이 나오게 했다.

📌 NPC대화

![112233](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/c668fa3a-fbeb-463a-a8f0-8582d18a35e3)

![12333](https://github.com/GreatJun/Clone-Virtual-World/assets/127035454/a5c7da21-2827-47b7-bb3e-ea86cd8669b1)


위 처럼 가까이 다가가면 팝업이 뜨고 대화하기를 누르면 밑에 대화 팝업이 뜨게 하였다.

대화는 딕셔너리를 사용했는데. 벨류값에 배열을 써서 대화를 더 만들려 했지만 시간이 부족하여 하지 못하였다.

public class NPCCollision : MonoBehaviour
{
    public GameObject NPCPopupPanel;
    public GameObject NPCConversationPanel;

    public int npcKeyValue;

    // NPC 대화 정보
    protected Dictionary<int, string> talkDate;
    protected Dictionary<int, Sprite> npcProfile;

    private void Awake()
    {
        // 초기화
        talkDate = new Dictionary<int, string>();
        npcProfile = new Dictionary<int, Sprite>();
        TalkDateSetting();
    }
    void TalkDateSetting()
    {
        // NPC 대사
        talkDate.Add(1000, "안녕하세요~ 오정호 튜터 입니다!ㅎㅎ");
        talkDate.Add(2000, "안녕하세요! 송지원 튜터 입니다.");
        talkDate.Add(3000, "안녕하세요. 이성언 튜터 입니다!");
        talkDate.Add(4000, "안녕하세요~! 강성훈 튜터 입니다.");
        talkDate.Add(5000, "안녕하세요. 김하연 튜터 입니다.!");
        talkDate.Add(6000, "안녕하세용 정승호 매니저 입니당.");
        talkDate.Add(7000, "한효승 매니저 입니다~~ 공부하세요.");
        talkDate.Add(8000, "안녕하세욤! 장윤서 매니저 입니다~");
        talkDate.Add(9000, "안녕하세요! 박준영 매니저 입니다~");

        // NPC Image
        npcProfile.Add(1000, Resources.Load<Sprite>("Image/OH Tuter"));
        npcProfile.Add(2000, Resources.Load<Sprite>("Image/Song Tuter"));
        npcProfile.Add(3000, Resources.Load<Sprite>("Image/Lee tuter"));
        npcProfile.Add(4000, Resources.Load<Sprite>("Image/Kang tuter"));
        npcProfile.Add(5000, Resources.Load<Sprite>("Image/White Tuter"));
        npcProfile.Add(6000, Resources.Load<Sprite>("Image/Jung Manager"));
        npcProfile.Add(7000, Resources.Load<Sprite>("Image/Han Manager"));
        npcProfile.Add(8000, Resources.Load<Sprite>("Image/Jang Manager"));
        npcProfile.Add(9000, Resources.Load<Sprite>("Image/Park Manager"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 판넬 켜주기
        NPCPopupPanel.SetActive(true);
        // 접촉한 npc 이름으로 판넬 텍스트 설정
        NPCPopupPanel.transform.GetChild(0).GetComponent<Text>().text = GameManager.instance.ContactNPCNameOutput();
        // Npc 대화 text에 만난 NPC의 Key값으로 Value받아오기
        NPCConversationPanel.transform.GetChild(0).GetComponent<Text>().text = talkDate[npcKeyValue];
        NPCConversationPanel.transform.GetChild(2).GetComponent<Image>().sprite = npcProfile[npcKeyValue];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 판넬 꺼주기
        NPCPopupPanel.SetActive(false);
        // 대화 판넬도 꺼주기
        NPCConversationPanel.SetActive(false);
    }
}
NPC마다 Key값을 넣어놔서 그 key값에 해당하는 대화가 나오도록 하였다. 설계를 잘못해서 한곳에 기능이 너무 모여있는데 나중에는 설계를 더 세분화해서 해야겠다.

    // Player가 접촉한 NPC 이름 저장
    public void ContactNPCNameSave(string name)
    {
        contactName = name;
    }

    // Player가 접촉한 NPC 이름 내보내기
    public string ContactNPCNameOutput()
    {
        return contactName;
    }
GameManager에서 접촉한 NPC의 정보를 저장하여 불러오며 활용하였다.

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // NPC 이름을 가져온다.
        GameManager.instance.ContactNPCNameSave(collision.transform.parent.transform.GetComponent<TextMesh>().text);
    }
}
