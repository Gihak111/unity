using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Player_State
{
    
    public class Player_State : MonoBehaviour
    {
        int Player_HP = 100;
        bool Player_Gkill = false;




        public static Player_State instance;
        private void Awake()
        {
            instance = this;
            
        }
      
        
        void Start()
        {

        }

        
        void Update()
        {

        }
    }
}
