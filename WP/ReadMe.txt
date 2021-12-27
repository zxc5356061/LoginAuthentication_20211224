1.	利用FormsAuthentication根據使用者的登入身分做驗證，特定頁面僅限特定身分存取。
2.	在interface中利用entity暫存資料，而非直接在service中使用EFmodel的物件，
	以保有變換存取資料庫方式的彈性。
3.	利用FormsAuthenticationTicket存取Cookie:
		>必須在Global.asax建立以下內容(ASP.NET Application Lifecycle
		>>protected void Application_AuthenticateRequest(){}
		>>IPrincipal obj
4.	利用NUnit.Framework & NSubstitute 進行單元測試，記得建立資料庫相依性。
