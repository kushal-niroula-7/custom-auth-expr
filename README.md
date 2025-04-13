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



Using ViewModel
-> Send view model to view: return View(vm);4
-> Assing view model to view:
	@model UserCreateVm
-> use asp-for in input and label
                if(!ModelState.IsValid)
                {
                    return View(vm);
                }
				
<input type="text" name="Username"
	value="user-15"
/>

input
radio
checkbox
textbox
button
select

## For Select
1. Add GetSelectList method to your vm
public SelectList UserTypeSelectItems()
       => new SelectList(userTypes, nameof(UserType.Id),
           nameof(UserType.Name),
           SelectedUserType
           );
2. Add list items to your vm
        public List<UserType> userTypes;
3. Set data in your vm list in your action
var userTypes = GetUserTypes();
vm.userTypes = userTypes;

4. Show select box in view
<div class="form-group">
    <label asp-for="SelectedUserType"></label>
    <select asp-for="SelectedUserType"
            asp-items="@Model.UserTypeSelectItems()"
            required>
        <option>--SELECT--</option>
    </select>
    <span class="text-danger" asp-validation-for="SelectedUserType"></span>
</div>


## Database

1. Install package
	- npgsql
	- dapper
2. Ability to create a connection
	-> Static class
3. Create a model class. Models/Product.cs
	-> Column name and property name must match
4. Create query
