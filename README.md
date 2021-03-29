# 건설 현장 관리 시스템
- 건설현장을 총괄 관리하는 프로그램입니다. 
- 회원사들 마다 DB가 제공되고 회사의 메인DB와 연결해서 쓰는 형식입니다. 
- 메인DB와 회원사DB를 나눈 이유는 건설현장의 상황은 매우 다양하기 때문에 새로운 코드, 권한, 업체, 팀, 현장, 장비, 등을 생성해 유연하게 현장에 대응하도록 만들기 위해서 입니다. 
<br></br>

# 개발환경 
- 개발 언어 : C#(Winform)
- 개발 DB : MS-SQL
- 개발 인원 : 2명

# 기능상세 
> ### 근로자 검색
![근로자 검색 확장](https://user-images.githubusercontent.com/60722292/112794421-d275c500-90a1-11eb-9145-9b27c992c144.png)
- 근로자 검색은 많은 기능들이 공통적으로 사용하는 기능으로서 위의 구역, 공종, 업체, 팀, 추가정보, 형식, 항목 등의 콤보 박스를 User Control로 구현하여 동료들이 사용하기 쉽도록 구현하였습니다.
- 각 콤보 박스들의 쿼리에는 권한이 함께 적용되기 때문에 자신이 소속한 구역, 업체, 현장에 따라 보이는 항목들을 제한해 두었습니다. 
- 오른쪽 상단의 추가 버튼을 누르게 되면 근로자 추가 기능이 실행되고, 권한이 있어야만 실행됩니다. 
- 하단에 있는 셀을 더블클릭하게 되면 해당 근로자의 정보를 수정할 수 있도록 팝업이 실행됩니다. 근로자 수정 역시 권한이 있어야만 실행됩니다.
<br></br>

> ### 근로자 추가/수정
![근로자 관리](https://user-images.githubusercontent.com/60722292/112794422-d3a6f200-90a1-11eb-8b34-b324c647d3b3.png)
- 이번 개발의 핵심 기능은 추가정보 기능입니다. 
- 건설현장은 여러 국적, 세대, 성별, 질병, 규칙, 건설사, 협력업체 등의 변수가 다양합니다. 모든 예외에 대해서 새로운 메뉴를 만들거나 코드를 새로 만들어야 한다면 사용자도 업무가 지체되어 힘들고 유지보수 또한 상당히 어려워집니다. 
- 새롭게 개발한 이 솔루션은 현장의 사용자가 자유롭게 추가정보 그룹을 추가할 수 있으며, 추가정보 항목들도 체크박스 형식, 텍스트 박스 형식, 날짜 형식, 콤보 박스 형식으로 나누어 추가할 수 있습니다. 각각의 T코드들 또한 읽기, 쓰기, 수정 권한을 따로 설정할 수 있어 세분화된 건설현장의 책임/감독 문화에 대응할 수 있게 만들었습니다.
- 추가정보 밑의 콤보박스에는 건강관리, 차량관리, 당직 등의 다양한 그룹들이 존재하며 항목이 바뀌어도 추가했던 모든 정보들은 기억되고 한 번에 저장됩니다.  
- 오렌지 색 배경 라벨을 클릭하면 구역, 업체, 팀, 직종, 추가정보 각각의 팝업이 뜨며 즉시 새로운 정보를 추가할 수 있습니다.
- 근로자 관리 기능은 검색, 수정, 등록 뿐만 아니라 건설현장의 핵심 요소가 되는 구역, 업체, 팀, 직종, 추가정보 까지 한 곳에서 관리할 수 있는 솔루션의 핵심 기능입니다. 
<br></br>

> ### 권한설정
![권한관리](https://user-images.githubusercontent.com/60722292/112794424-d43f8880-90a1-11eb-8846-52dd6225103a.png)
![공통코드권한관리현장](https://user-images.githubusercontent.com/60722292/112794426-d43f8880-90a1-11eb-8a1e-8459d964d0aa.png)
![공통코드그룹권한설정현장](https://user-images.githubusercontent.com/60722292/112794430-d570b580-90a1-11eb-9d3a-a42401c1f19a.png)
![추가정보코드권한설정](https://user-images.githubusercontent.com/60722292/112794432-d570b580-90a1-11eb-810f-d25d52f7c920.png)
- 왼쪽 상단에 보이는 콤보 박스에는 시스템 관리자, 구역 관리자, 근로자 등 다양한 권한들을 선택할 수 있고, 권한 별로 각 코드들에 대한 보기, 추가, 수정, 삭제, 보고서, 프린트, 다운로드 기능을 실행할 수 있는 FLAG들을 만들었습니다. 
- 사내에서 꼼꼼한 저의 성격을 인정 받아 시스템 모든 곳에 사용되는 권한 시스템을 맡고 구현하게 되었습니다. 
- 제가 만든 쿼리들은 동료들의 버튼으로도 쓰이고, 로그인 시 사용자의 권한을 가져오는 클래스로도 활용 되었습니다. 
- 메뉴 권한 설정 현장, 시스템 권한 메인 DB, 시스템 권한 회원사, 시스템 권한 현장, 추가 코드 권한 설정 등을 만들었습니다.   
<br></br>


> ### 코드관리 
![시스템 코드](https://user-images.githubusercontent.com/60722292/112794427-d4d81f00-90a1-11eb-9b6c-e7ff31ff66f6.png)
![시스템 코드 그룹](https://user-images.githubusercontent.com/60722292/112794428-d4d81f00-90a1-11eb-8daa-6519eefb7683.png)
- 시스템 구축의 근간이 되는 코드관리 기능을 구현했습니다. 
- 건설현장의 ERD는 매우 복잡하여 코드와 코드그룹으로 묶여 관리됩니다. 
- 모든 코드 관리는 권한이 엄격하게 제한되어야 하는 기능이기에, 권한 설정을 만든 제가 모든 코드를 구현했습니다. 
 <br></br>
 
 
> ### 회원사 관리
![회원사관리](https://user-images.githubusercontent.com/60722292/112794434-d6094c00-90a1-11eb-96e1-57a140a01579.png)
- 건설을 주관하는 회원사를 관리하는 기능입니다.
- 주거래처를 관리하는 곳 이기에 시스템관리자(연구원)가 관리하는 페이지입니다. 
<br></br>


> ### 현장관리
![현장관리](https://user-images.githubusercontent.com/60722292/112794435-d6094c00-90a1-11eb-8d3e-eff26260afbe.png)
- 회원사가 현재 진행하고 있는 현장을 총 관리할 수 있는 페이지입니다.
- 현장 등록, 수정, 삭제의 기능이 있는 페이지이고, 회원사 관리자가 사용하게 됩니다. 
<br></br>


> ### 업체관리 
![업체관리](https://user-images.githubusercontent.com/60722292/112794437-d6a1e280-90a1-11eb-87f5-a29e399bde91.png)
- 해당 현장에 있는 업체들을 총 관리할 수 있는 페이지입니다. 
- 한 건설 현장에는 100개 이상의 크고 작은 협력 업체들이 있습니다. 공정을 살펴보면서 사용자는 협력 업체와 연락할 일이 굉장히 많습니다. 
- 왼쪽 상단 콤보 박스는 사용/미사용을 선택하는 곳이고, 셀에서 사용 체크박스를 해제하면 미사용으로 가게 함으로써 삭제 기능을 대신하게 만들었습니다. 
- CRUD 형태는 간단해 보이지만, 건설현장의 ERD는 매우 복잡하고, 메인 DB뿐 아니라 회사별로 DB가 존재해서 메인 DB와 업체 DB를 JOIN 해야 하는 경우가 많습니다. 그래서 JOIN이 조금만 잘못되면 정보가 누락되는 경우가 많았기에 코딩 보다는 쿼리에 신경을 많이 써야하는 부분이었습니다.
- 중요하게 관리 감독 해야하는 기능이기 때문에 입력값이 가장 많은 페이지입니다. 
- 회원사 관리자는 열람의 기능만 있습니다. 재량에 따라 조금은 변경될 수 있으나 현장 관리자가 사용하게 됩니다. 
<br></br>


> ### 팀관리 
![팀관리](https://user-images.githubusercontent.com/60722292/112794438-d6a1e280-90a1-11eb-8dd4-c29289f56f70.png)
- 한 업체에는 매우 많은 팀이 존재합니다. 
- 도장, 배선, 전기, 미장, 목공 등 많은 팀을 등록하고 관리하는 페이지입니다. 
<br></br>


> ### 출입장비관리 
![출입장비관리](https://user-images.githubusercontent.com/60722292/112794439-d73a7900-90a1-11eb-9867-032d47ccd977.png)
- 홍체 인식, 체온 측정, 손 혈관 인식등 여러가지의 장비들을 추적하기 위해서 만든 페이지입니다.
- 장비의 문제가 생겼을 시 빠르게 CS하기 위해 만들어진 페이지입니다. 
- 시스템관리자(연구원)들이 사용하는 페이지입니다. 
<br></br>

# 리뷰 
- 건설현장의 ERD는 복잡하기로 유명합니다. 이번에 개발한 솔루션은 시스템 관리, 근로자 관리, 위험성 평가, 근로자 교육, 생체 등록 등 여러가지 파트로 나눠서 관리되고 메인DB와 회사별로 DB를 한 개씩 사용하는 설계로 DB와 DB를 JOIN해야 하는 경우가 많았습니다. 조금만 쿼리를 잘못 짜면 자료가 누락되는 경우가 많았기에 항상 세심하게 쿼리를 짜야 했습니다. 또한, 업체, 현장, 팀, 메인DB가 유기적으로 연결되어 있고, 입력, 수정, 삭제를 한 사람을 추적하기 위해 Log테이블을 같이 운영했기 때문에 프로시저를 직접 작성해 볼 기회가 많았습니다. 
- 프로시저가 가장 유용했던 경우는 Log테이블을 운영할 때 였습니다. 어떤 테이블에 대한 로그를 남기려면 INSERT 테이블의 자동 증가 값을 가져와야 하는 경우가 많았는데 이런 경우 프로시저를 통해 자동 증가 값(대부분 PK)을 손쉽게 다음 실행될 쿼리의 파라미터로 쓸 수 있어 편리하다는 것을 깨달았습니다. 
- 프로시저 사용을 남발하는 것은 DB에 머무르는 시간이 길어 만약 다수의 사용자가 프로그램을 사용하게 된다면 DB에 부하가 걸릴 수 있다는 것을 배웠고, 최대한 짧게 DB에 머물도록 했으며, 어쩔 수 없는 경우에만 프로시저를 쓰도록 노력했습니다. 
- 인턴 기간에 직접 쿼리를 짜며 깨달은 것은 CRUD라는 기술 자체를 근간으로 프로그램이 만들어지지만, 중요한 것은 올바른 쿼리를 생각해 데이터의 누락이나 변형이 없이 플랫폼이 잘 돌아가게 만들어야 한다는 것입니다. 
- ERP 시스템은 현재 모바일 앱을 동반하는 경우가 대부분이기 때문에 인턴 후 모바일 앱 연구를 할 계획입니다.
<br></br>

# 라이센스
- (주)엘다임
