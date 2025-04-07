- Setting The Dev Env
	- .net core sdk 9.0
	- Visual Studio / VS Code / Rider
	- Postgres [ https://www.postgresql.org/download/windows/ ]
	- DbExplorer (DBeaver) [ https://dbeaver.io/download/ ]
	
- App Stack
	- Asp.Net Core MVC
	- Custom Authentication
	- Dapper [Data Access Layer]
		❌ Ef-Core
	- html, css, javascript
		- bootstrap
	- Template Integration
	
## Steps
1. Setup visual studio
	- Select Web Development
	- If you missed:
		- Open Visual studio installer
		- Modify
		- Select Web Development
2. Create a new project
	- Select a template: Asp.Net Core Model View Controller
3. Exploring the code: Solution Explorer
	- If solution explorer is not visible:
		View > Solution Explorer OR Alt + 1

> If you get "Insecure connection" error:
run this command: dotnet dev-certs https --trust

4. Create a new page:
	- URL: /user/single
	- Controller: UserController
	- Action: Single
	- Create a controller:
		-> Add a class: Controllers/UserController.cs
		-> UserController : Controller [UserController extends Controller]
	-> Add an action:
		public IActionResult Single()
		{
			
		}
	-> Add a view file:
		Views / [Controller] / [Action].cshtml
		Views / User / Single.cshtml
	
	-> Send data to view