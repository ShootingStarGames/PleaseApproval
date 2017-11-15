using UnityEngine;
using System.Collections;

namespace Event
{
    public class EventClass : MonoBehaviour
    {
        private int []data = new int[5];
        private string dialog;
        private Sprite img;
        public void addAll(int []data,string dialog, Sprite img)
        {
            this.data = data;
            this.dialog = dialog;
            this.img = img;
        }

        public Sprite getImg()
        {
            return img;
        }

        public string getDialog()
        {
            return dialog;
        }
        
        public int[] getDate()
        {
            return data;
        }
    }
}