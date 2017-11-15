using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Paper
{
	public class PaperContentList
	{
		private PaperCharEnumeration charType;

		private Queue<PaperContentClass> qPaperClasses = new Queue<PaperContentClass>();
		private PaperContentClass paperClass_Cur;

		/**
		 *
		**/
		private Queue<PaperCharEnumeration> qCharType = new Queue<PaperCharEnumeration>();

		private int charIdx;
		private int paperIdx;
		//private string content;
		//private string dialog;
		//private int[] data;

		// 생성자
		public PaperContentList ()
		{
			InitPaperContentList ();
			ResetPaperContentList ();
		}
		/**
			class 들을 모두 세팅합시다. -start-
		**/
		// 트럼프 클래스 만듦
		// 돈, 직원, 프로젝트, 점유율
		private PaperContentClass GetTrumpClass(){
			PaperContentClass _class = new PaperContentClass (PaperCharEnumeration.TRUMP, "하얀집에 사는 트럼프");
			_class.AddAll("단합대회 개최", "여직원들과 흐흐.. 알지?", new int[]{0, -8, 0, 0, 0, 0, 8, 0, 0, 0});
			_class.AddAll("명예퇴직", "돈만 먹는 애들은 잘라버려라.", new int[]{3, -5, 0, 0,0, -9, 0, 0, 0, 0 });
			_class.AddAll("하청업체 불리한 계약 조건 제시", "하청 그냥 부려먹고 버림 되지", new int[]{12, 0, -10, -3, 0, -9, 0, 12, 5, 0 });
			_class.AddAll("단체 등산", "여직원들 많이 데려와야해?", new int[]{0, -10, 0, 0, 0, 0, 10, 0, 0, 0 });
			_class.AddAll("사내 헬스장 개설", "여직원들 헬스하면 좋잖아?", new int[]{-10, 7, 0, 0, 0,10, -7, 0, 0, 0 });

			return _class;
		}
		// 순시리 클래스 만듦
		private PaperContentClass GetSunsilClass(){
			PaperContentClass _class = new PaperContentClass (PaperCharEnumeration.SUNSIL, "권력자 순시리");
			_class.AddAll("고사 지내기", "우주의 힘으로 프로젝트를 성사시켜주겠어요.", new int[]{-11, -12, -14, 0, 0, 11, 13, 14, 0, 0 });
			_class.AddAll("원가가 저렴한 자재로 변경", "저렴한 자재를 써야 뭐좀 남길거 아니에요?", new int[]{10, 0, -10, 0, 0,-13, 0, 10, 0, 0 });
			_class.AddAll("단톡방 개설", "할말이 있으니 단톡방좀 하나 만들어줘요!", new int[]{0, -10, 10, 0, 0, 0, 5, -5, 0, 0 });
			_class.AddAll("내 딸 입사", "우리 딸이 취직할 자리가 좀 필요한데?", new int[]{9, -2, -3, 3, 0, 0, 0, -8, -5, 0 });
			_class.AddAll("고위층에게 줄 선물 준비", "XX그룹 회장님이 좀 보자네요? 준비는 해 놨죠?", new int[]{-10, 0, 8, 3 ,0 , 5, 5, 0, -5, 0 });

			return _class;
		}
		// 노란머리 여직원
		private PaperContentClass GetYellowWomanClass(){
			PaperContentClass _class = new PaperContentClass (PaperCharEnumeration.Y_WOMAN, "불만 많은 겸대리");
			_class.AddAll("사내 연애 금지", "아니, 나도 못하고 있는데 옆에서 꺄르륵꺄르륵 거린다니까요?!", new int[]{0, -9, -8, 0, 0, 0, 10, 7, 0, 0 });
			_class.AddAll("외부 강사 초청", "직원들 질을 높혀야죠. 강사 불러줘요.", new int[]{-10, 10, -2, 0, 0,10, 0, 0, 0, 0 });
			_class.AddAll("난방 가동", "추워 죽겠어요! 난방 좀 켜줘요!", new int[]{-10, 11, 0, 0, 0,10, -10, 0, 0, 0 });
			_class.AddAll("불우이웃 돕기", "아니...회사의 이미지도 좋아지고! 아무튼! 하는 게 어때요?", new int[]{0, -10, -10, 5, 0,0, 10, 12, -7, 0 });
			_class.AddAll("아침식사 제공", "아침마다 배고파 죽겠어요.", new int[]{-10, 10, 10, 0, 0,11, -10, -10, 0, 0 });
			_class.AddAll("성희롱 예방 교육 실시", "그 아저씨가 좀 불편하네요!", new int[]{-10, 13, 8, 0, 0, 10, -11, -13, 0, 0 });

			return _class;
		}
		// 주황머리 여직원
		private PaperContentClass GetOrangeWomanClass(){
			PaperContentClass _class = new PaperContentClass (PaperCharEnumeration.O_WOMAN, "신입사원 신사원");
			_class.AddAll("직원용 의자 구입", "의자가 불편해요!", new int[]{-10, 12, 10, 0, 0, 7, -9, -10, 0, 0 });
			_class.AddAll("제품 광고 필요", "우리끼리만 알면 그게 장사가 되나요~", new int[]{-12, 0, 0, 5, 0,0, 0, 0, -5, 0 });
			_class.AddAll("요즘 유행하는 수평관계 지향", "사장님~ 부탁해요~", new int[]{0, 10, 0, 0, 0,0, -10, 0, 0, 0 });
			_class.AddAll("제품 하자 보상", "고객들 불만이 많아서 어쩔수 없어요", new int[]{-13, 0, 0, 7,0, 10, 0, 0, -7, 0 });

			return _class;
		}
		// 대머리 과장님
		private PaperContentClass GetBaldManClass(){
			PaperContentClass _class = new PaperContentClass (PaperCharEnumeration.B_MAN, "소심한 고과장");
			_class.AddAll("할인 이벤트 개시", "할인..해도..되겠습니까..?", new int[]{-10, 0, 10, 3,0, 10, 0, -10, -5, 0 });
			_class.AddAll("신제품 공개 날짜 연기", "불량품이.. 너무 많습니다.. 시간이 필요합니다...", new int[]{-12, 0, 10, 0,0, 10, 0, -10, -5, 0 });
			_class.AddAll("경쟁사 소송", "경쟁사가..저희 제품 표절했습니다... 소송할까요...?", new int[]{-10, 0, 10, 3,0, 10, 0, -13, -5, 0 });
			_class.AddAll("정부 하청 수락", "정부에서 하청이.. 들어왔습니다.. 수락할까요...?", new int[]{10, 0, 10, 7,0, -10, 0, -10, -7, 0 });
			_class.AddAll("노조와의 협상", "저는..아닌데...직원들이...불만이 많다고 합니다...", new int[]{0, 10, 6, 0,0, 0, -10, -6, 0, 0 });
			_class.AddAll("가격 담합 승낙", "기업들이 하자고 하는데.. 안 하는게 낫다고 생..각..합니다...", new int[]{12, 0, 0, 0,0, -12, 0, 0, 0, 0 });

			return _class;
		}
		// 정은이
		private PaperContentClass GetJungManClass(){
			PaperContentClass _class = new PaperContentClass (PaperCharEnumeration.J_MAN, "독단적인 정은씨");
			_class.AddAll("럽무량 늘림", "럽무량을 늘리자우!", new int[]{10, -10, 12, 0, 0, -10, 10, -10, 0, 0 });
			_class.AddAll("련봉 협상", "련봉좀 올려 달라우", new int[]{-5, 10, 0, 0, 0, 10, -10, 0, 0, 0 });
			_class.AddAll("대학생 학교린턴", "학교 린턴들 전부 부려먹자우!", new int[]{12, 10, 0, 0, 0, -8, -12, 0, 0, 0});
			_class.AddAll("주말 보장", "쉬는 날이 필요하다우!!", new int[]{0, 10, -12, 0, 0, 0, -10, 10, 0, 0 });
			_class.AddAll("림금의 릴부를 재고로 대체", "재고 처리는 해야할거 아니우?", new int[]{10, -12, 0, 0, 0, -10, 12, 0, 0, 0, });

			return _class;
		}

        private PaperContentClass GetYoungManClass()
        {
            PaperContentClass _class = new PaperContentClass(PaperCharEnumeration.YO_MAN, "고과장 동생");
            _class.AddAll("정시 퇴근 보장", "정시 퇴근좀 보장해 주세요.", new int[] { 0, 10, 8, 0, 0, 0, -12, -7, 0, 0 });
            _class.AddAll("휴가 보장", "정해진 휴가는 보장해 주세요.", new int[] { 0, 10, 8, 0, 0, 0, -10, -5, 0, 0 });
            _class.AddAll("해외 연수", "글로벌 경쟁력을 위해서 필수 아니겠습니까?", new int[] { 0, 10, 10, 0, 0, 0, -10, -10, 0, 0, });
            _class.AddAll("부서 인원 충당", "우리 부서가 업무량이 좀 많은거 같은데..", new int[] { 0, 10, -10, 0, 0, 0, -10, 8, 0, 0, });
            _class.AddAll("프로젝트 연기", "시간이 좀 부족할 것 같습니다.", new int[] { 0, 10, -10, -8, 0, 0, -10, 10, 0, 0, });

            return _class;
        }

        private PaperContentClass GetBlackManClass()
        {
            PaperContentClass _class = new PaperContentClass(PaperCharEnumeration.BL_MAN, "미국 바이어");
            _class.AddAll("하청", "당신한테 맡기고 싶은 일이 있습니다.", new int[] { 20, 0, 12, 0, 5, 0, 0, 0, 0, -5 });
            _class.AddAll("거래", "당신네들 물건을 좀 사고 싶습니다.", new int[] { 18, 0, 0, 0, 5, -10, 0, 0, 0, -6 });

            return _class;
        }

        private PaperContentClass GetEventManClass()
        {
            PaperContentClass _class = new PaperContentClass(PaperCharEnumeration.EV_MAN, "수수깨끼의 사내");
            _class.AddAll("???", "....", new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }); // 랜덤 확률로 이벤트 발생

            return _class;
        }



        /**
			class 들을 모두 세팅합시다. -end-
		**/

        // init set class
        private void InitPaperContentList(){
			qPaperClasses.Enqueue (GetTrumpClass());
			qPaperClasses.Enqueue (GetSunsilClass());
			qPaperClasses.Enqueue (GetYellowWomanClass ());
			qPaperClasses.Enqueue (GetBaldManClass ());
			qPaperClasses.Enqueue (GetOrangeWomanClass ());
			qPaperClasses.Enqueue (GetJungManClass ());
            qPaperClasses.Enqueue(GetYoungManClass());
            qPaperClasses.Enqueue(GetBlackManClass());
            qPaperClasses.Enqueue(GetEventManClass());
        }

		// 결재서류 가져올 애를 랜덤으로 고르고 스크립트를 골라줌.
		public void ResetPaperContentList(){

            int ran = Random.Range(0, 200);
            if (ran >= 196) // 이벤트 인물
                charIdx = 8;
            else if (ran >= 187) //해외 점유율 인물.
                charIdx = 7;
            else
                charIdx = Random.Range(0, qPaperClasses.Count - 2);
            paperClass_Cur = qPaperClasses.ToArray () [charIdx];

			paperIdx = Random.Range (0, paperClass_Cur.GetCount());
		}

		// 캐릭터 가져오기
		public int getCharIdx()
		{
			return charIdx;
		}

		// 캐릭터 이름
		public string getName()
		{
			string s = paperClass_Cur.GetCharName ();
			return s;
		}

		// 서류 내용 가져오기
		public string getContent(){
			return paperClass_Cur.GetContent (paperIdx);
		}
		// 말푸ㅇㅓㄴ 내용
		public string getDialog(){
			return paperClass_Cur.GetDialog (paperIdx);
		}
		// 승인시
		public int getTrueMoney(){
			return paperClass_Cur.GetDatas(paperIdx)[0];
		}
		public int getTrueEmp(){
			return paperClass_Cur.GetDatas(paperIdx)[1];
		}
		public int getTrueProj(){
			return paperClass_Cur.GetDatas(paperIdx)[2];
		}
		public int getTrueO(){
			return paperClass_Cur.GetDatas(paperIdx)[3];
		}
        public int getTrueG()
        {
            return paperClass_Cur.GetDatas(paperIdx)[4];
        }
        //거절시
        public int getFalseMoney(){
			return paperClass_Cur.GetDatas(paperIdx)[5];
		}
		public int getFalseEmp(){
			return paperClass_Cur.GetDatas(paperIdx)[6];
		}
		public int getFalseProj(){
			return paperClass_Cur.GetDatas(paperIdx)[7];
		}
		public int getFalseO(){
			return paperClass_Cur.GetDatas(paperIdx)[8];
		}
        public int getFalseG()
        {
            return paperClass_Cur.GetDatas(paperIdx)[9];
        }
    }
}
