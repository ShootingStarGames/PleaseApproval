using System;

namespace Paper
{
	public class PaperContentClass
	{
		private PaperCharEnumeration char_type;
		private string char_name;

		private string[] contents= new string[0];
		private string[] dialogs=new string[0];
		private int[] datas=new int[0];

		public PaperContentClass (PaperCharEnumeration char_type, string char_name)
		{
			this.char_type = char_type;
			this.char_name = char_name;
		}

		public PaperCharEnumeration GetCharType(){
//			char_type = PaperCharEnumeration.O_WOMAN;
			return this.char_type;
		}
		public string GetCharName(){
			return this.char_name;
		}
		public string GetContent(int idx){
			return contents[idx];
		}
		public string GetDialog(int idx){
			return dialogs[idx];
		}
		public int[] GetDatas(int idx){
            
			int[] d = new int[10]{datas[idx*10], datas[idx*10+1], datas[idx*10+2], datas[idx*10+3], 
				datas[idx*10+4], datas[idx*10+5], datas[idx*10+6], datas[idx*10+7],
                datas[idx*10+8],datas[idx*10+9]};
			return d;
		}
		public int GetCount(){
			return contents.Length;
		}
		public void AddAll(string contents, string dialogs, int[] datas){
			AddContents(contents);
			AddDialogs (dialogs);
            AddDatas(datas);
        }
        public void AddContents(string s){
			Array.Resize(ref contents, contents.Length+1);
			contents [contents.Length-1] = (string)s.Clone ();
		}
		public void AddDialogs(string s){
			Array.Resize(ref dialogs, dialogs.Length+1);
			dialogs [dialogs.Length-1] = (string)s.Clone ();
		}
		public void AddDatas(int[] d){
			int len = datas.Length;
			Array.Resize(ref datas, len+10);
			datas [len] = d[0];//수락 돈
            datas [len+1] = d[1];//수락 직원
			datas [len+2] = d[2];//수락 업무량
			datas [len+3] = d[3];//수락 점유율
            datas [len+4] = d[4];//수락 해외점유율
            datas [len+5] = d[5];//거절
			datas [len+6] = d[6];//거절
			datas [len+7] = d[7];//거절
            datas [len+8] = d[8];//겆ㄹ
            datas [len+9] = d[9];//거절
        }
	}
}

