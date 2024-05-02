 using UnityEngine;
 using UnityEngine.UI;

 public class TextFontExample : MonoBehaviour
 {
     Text m_Text;
    
     //Attach your own Font in the Inspector
   


    public GameObject Counter;
    ObjectCounter Count;

    

    void Start()
     {
         //Fetch the Text component from the GameObject
         m_Text = GetComponent<Text>();
        Count = Counter.GetComponent<ObjectCounter>();
    }

     void Update()
     {

        m_Text.text = "Score: " + Count.GetCount();

     }
 }